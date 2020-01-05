using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchManagementBL
{
    public static class GenerationTablesResults
    {

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

                return fillInGoals((Guid)mv[i]["equipe1Id"], matchId);
            }
            catch (CustomsError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        // récupère l'ID de l'équipeB et renvoie le dataTable correspondant à la table du match
        public static DataView getFeuilleB(Guid matchId, out Guid EquipeBID)
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
                EquipeBID = (Guid)mv[i]["equipe2Id"];

                return fillInGoals((Guid)mv[i]["equipe2Id"], matchId);
            }
            catch (CustomsError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        // renvoie la table des joueurs ayant marqués lors d'un match pour une équipe
        public static DataView fillInGoals(Guid equipeId, Guid matchId)
        {
            try
            {
                GoalsService gs = new GoalsService();
                DataView gv = gs.loadAllData();

                JoueursService js = new JoueursService();
                DataView jv = js.loadAllData();

                TableResultats tabResult = new TableResultats();

                DataTable tableResults = tabResult.getTableResultats();

                DataRow row;

                foreach (DataRowView dr in gv)
                {
                    

                    if ((Guid)dr["matchId"] == matchId && (Guid)dr["equipeId"] == equipeId)
                    {
                        row = tableResults.NewRow();

                        row[0] = (Guid)dr["joueurId"];

                        row[1] = "";

                        int i = 0;

                        while (((Guid)dr["joueurId"] != (Guid)jv[i]["joueurId"]) && i < jv.Count)
                        {
                            i++;
                        }
                        if (i != jv.Count)
                        {
                            row[1] = jv[i]["prenom"] + " " + jv[i]["nom"];
                        }

                        row[2] = dr["minuteMarque"];

                        row[3] = (Guid)dr["goalId"];

                        DateTime date = DateTime.Now;

                        row[4] = date;

                        tableResults.Rows.Add(row);
                    }
                    
                }
                tableResults.AcceptChanges();
                return tableResults.DefaultView;
            }
            catch (CustomsError ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // renvoie la table des joueurs ayant marqués lors d'un match pour une équipe
        public static DataView fillInCartesJaunes(Guid equipeId, Guid matchId)
        {
            try
            {
                CartesJaunesService cjs = new CartesJaunesService();
                DataView cjv = cjs.loadAllData();

                JoueursService js = new JoueursService();
                DataView jv = js.loadAllData();

                TableResultats tabResult = new TableResultats();

                DataTable tableResults = tabResult.getTableResultats();

                DataRow row;

                foreach (DataRowView dr in cjv)
                {


                    if ((Guid)dr["matchId"] == matchId && (Guid)dr["equipeId"] == equipeId)
                    {
                        row = tableResults.NewRow();

                        row[0] = (Guid)dr["joueurId"];

                        row[1] = "";

                        int i = 0;

                        while (((Guid)dr["joueurId"] != (Guid)jv[i]["joueurId"]) && i < jv.Count)
                        {
                            i++;
                        }
                        if (i != jv.Count)
                        {
                            row[1] = jv[i]["prenom"] + " " + jv[i]["nom"];
                        }

                        row[2] = dr["minuteRecue"];

                        row[3] = (Guid)dr["carteJauneId"];

                        DateTime date = DateTime.Now;

                        row[4] = date;

                        tableResults.Rows.Add(row);
                    }

                }
                tableResults.AcceptChanges();
                return tableResults.DefaultView;
            }
            catch (CustomsError ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataView fillInCartesRouges(Guid equipeId, Guid matchId)
        {
            try
            {
                CartesRougesService crs = new CartesRougesService();
                DataView crv = crs.loadAllData();

                JoueursService js = new JoueursService();
                DataView jv = js.loadAllData();

                TableResultats tabResult = new TableResultats();

                DataTable tableResults = tabResult.getTableResultats();

                DataRow row;

                foreach (DataRowView dr in crv)
                {
                    if ((Guid)dr["matchId"] == matchId && (Guid)dr["equipeId"] == equipeId)
                    {
                        row = tableResults.NewRow();

                        row[0] = (Guid)dr["joueurId"];

                        row[1] = "";

                        int i = 0;

                        while (((Guid)dr["joueurId"] != (Guid)jv[i]["joueurId"]) && i < jv.Count)
                        {
                            i++;
                        }
                        if (i != jv.Count)
                        {
                            row[1] = jv[i]["prenom"] + " " + jv[i]["nom"];
                        }

                        row[2] = dr["minuteRecue"];

                        row[3] = (Guid)dr["carteRougeId"];

                        DateTime date = DateTime.Now;

                        row[4] = date;

                        tableResults.Rows.Add(row);
                    }

                }
                tableResults.AcceptChanges();
                return tableResults.DefaultView;
            }
            catch (CustomsError ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<JoueursModele> getJoueurs(Guid matchId, Guid equipeId)
        {
            try
            {
                FeuillesMatchService fms = new FeuillesMatchService();
                DataView fmv = fms.loadAllData();

                JoueursParticipationService jps = new JoueursParticipationService();
                DataView jpv = jps.loadAllData();

                JoueursService js = new JoueursService();
                DataView jv = js.loadAllData();


                TableResultats tabResult = new TableResultats();
                DataTable tableResults = tabResult.getTableResultatsCombo();
                DataRow row;


                for(int i = 0;i<fmv.Count;i++)
                {
                    if ((Guid)fmv[i]["matchId"] == matchId && (Guid)fmv[i]["equipeId"] == equipeId)
                    {
                        for (int j = 0; j < jpv.Count; j++)
                        {
                            if ((Guid)fmv[i]["feuilleId"] == (Guid)jpv[j]["feuilleId"])

                            {
                                int k = 0;

                                while ((Guid)jpv[j]["joueurid"] != (Guid)jv[k]["joueurId"] && k < jv.Count)
                                {
                                    k++;
                                }

                                row = tableResults.NewRow();

                                row[0] = (jv[k]["joueurId"]);
                                row[1] = (jv[k]["nom"]);
                                row[2] = (jv[k]["prenom"]);
                                row[3] = (jv[k]["lastUpdate"]);

                                tableResults.Rows.Add(row);
                            }
                        }
                    }
                }

                tableResults.AcceptChanges();
                return js.GetListeObject(tableResults);
            }
            catch (CustomsError ce)
            {
                throw ce;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}


