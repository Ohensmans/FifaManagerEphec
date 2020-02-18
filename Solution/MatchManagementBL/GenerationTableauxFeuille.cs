using FifaDAL.MatchManagement;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public static class  GenerationTableauxFeuille
    {
        public static int DureeQuartersJours = 42;  


        // récupère l'ID de l'équipeA et renvoie le dataTable correspondant à la table du match
        public static DataView getFeuilleA(Guid matchId, out Guid EquipeAID)
        {
            try
            {
                MatchsService ms = new MatchsService();
                DataView mv = ms.loadAllData();

                int i = 0;
                while ((Guid)mv[i]["matchId"] != matchId)
                {
                    i++;
                }
                EquipeAID = (Guid)mv[i]["equipe1Id"];

                return getMatchEquipe((Guid)mv[i]["equipe1Id"], matchId, (DateTime)mv[i]["matchDate"]).DefaultView;
            }
            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        // récupère l'ID de l'équipeB et renvoie le dataTable correspondant à la feuille de match
        public static DataView getFeuilleB(Guid matchId, out Guid EquipeBID)
        {
            try
            {
                MatchsService ms2 = new MatchsService();
                DataView mv = ms2.loadAllData();

                int i = 0;
                while ((Guid)mv[i]["matchId"] != matchId)
                {
                    i++;
                }
                EquipeBID = (Guid)mv[i]["equipe2Id"];
                return getMatchEquipe((Guid)mv[i]["equipe2Id"], matchId, (DateTime)mv[i]["matchDate"]).DefaultView;
            }
            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        // A partir de l'equipeID et du matchID renvoie la feuille de match existante ou un vide si jamais elle n'existe pas
        public static DataTable getMatchEquipe(Guid equipeId, Guid matchId, DateTime matchDate)
        {
            try
            {
                // récupère feuilleID si il existe ou en crée un
                FeuillesMatchService fms = new FeuillesMatchService();
                Guid feuilleId = fms.UpdateFeuille(matchId, equipeId);

                // récupère les joueurs déjà inscrits
                List<dynamic> lstDy = new List<dynamic>();
                lstDy.Add(feuilleId);
                JoueursParticipationService jps = new JoueursParticipationService();
                DataView jpv = jps.loadWithParameter("JoueursInscrits", lstDy);

                //récupère les joueurs dans l'équipe au moment du match
                List<dynamic> lstDy2 = new List<dynamic>();
                lstDy2.Add(equipeId);
                lstDy2.Add(matchDate);
                TransfertsHistoryService ths = new TransfertsHistoryService();
                DataView thv = ths.loadWithParameter("JoueursEquipe", lstDy2);

                JoueursService js = new JoueursService();
                DataView jv = js.loadAllData();

                CartesJaunesService cjs = new CartesJaunesService();
                DataView cjv = cjs.loadAllData();

                CartesRougesService crs = new CartesRougesService();
                DataView crv = crs.loadAllData();

                QuartersService qs = new QuartersService();
                QuartersModele quarter = qs.getAQuarter(matchDate);

                //obtient la liste de match de l'équipe pour le quarter et triée par date ascendante
                MatchsService ms = new MatchsService();
                DataView mv = ms.loadAllData();
                List<MatchsModele> lMatchs = ms.getMatchsEquipe(equipeId, quarter);

                

                DataTable feuille = new TableFeuilleMatch().getTable();
                DataRow row;

                foreach (DataRowView dr in thv)
                {
                    row = feuille.NewRow();

                    //va chercher le prénom et le nom du joueur
                    int i = 0;
                    while ((Guid)dr["joueurId"] != (Guid)jv[i]["joueurId"])
                    {
                        i++;
                    }

                    row[0] = (String)jv[i]["prenom"] + " " + (String)jv[i]["nom"];

                    //va chercher le nombre de cartons jaunes actifs dans le quarter
                    int count = 0;
                    for (i = 0; i < cjv.Count; i++)
                    {
                        if ((Guid)dr["joueurId"] == (Guid)cjv[i]["joueurId"] && (Boolean)cjv[i]["isActive"] == true
                            && ((DateTime)(cjv[i]["matchDate"]) <= matchDate.AddDays(DureeQuartersJours))
                            && ((DateTime)(cjv[i]["matchDate"])).AddDays(DureeQuartersJours) >= matchDate)
                        {
                            count++;
                        }
                    }

                    row[1] = count;

                    //va chercher le nombre de suspensions restantes à un carton rouge dans le quarter
                    row[2] = 0;

                    //récupère la liste de cartons rouge du joueur pour le quarter
                    List<Guid> lMatchsAvecCartons = crs.getMatchsCartonsRouges((Guid)dr["joueurId"], quarter);
                    //vérifie si il en a reçu
                    if (lMatchsAvecCartons.Any())
                    {
                        int positionMatch = lMatchs.IndexOf(lMatchs.Where(xx => xx.matchDate == matchDate)
                                                                       .FirstOrDefault());
                        foreach (Guid Id in lMatchsAvecCartons)
                        {
                            int positionCarton = lMatchs.IndexOf(lMatchs.Where(xx => xx.matchId == Id)
                                                                        .FirstOrDefault());
                            //vérifie que le match en cours est affecté par le carton
                            if (positionMatch-positionCarton>0 && positionMatch-positionCarton<3)
                            {
                                row[2] = 4 - positionMatch - positionCarton;
                            }
                        }
                    }

                    //va chercher le nombre de match restants pour l'équipe ce quarter
                    row[3] = lMatchs.Where(xx => xx.isPlayed == false)
                                    .Count();


                    // va voir si le joueur est déjà sur la feuille de match
                    row[4] = false;

                    for (i = 0; i < jpv.Count; i++)
                    {
                        if ((Guid)dr["joueurId"] == (Guid)jpv[i]["joueurId"])
                        {
                            row[4] = true;
                        }
                    }

                    // rajoute le joueurId pour contrôle
                    row[5] = (Guid)dr["joueurId"];

                    feuille.Rows.Add(row);
                }
                feuille.AcceptChanges();
                return feuille;
            }

            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        //


    }
}
