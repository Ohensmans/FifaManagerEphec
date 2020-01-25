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
    public static class GenerationTableauxAccueil
    {

        public static DataTable getMatchEquipe(int annee)
        {
            try {
                MatchsService ms = new MatchsService();
                EquipesService es = new EquipesService();
                GoalsService gs = new GoalsService();
                JoueursParticipationService jps = new JoueursParticipationService();
                FeuillesMatchService fms = new FeuillesMatchService();

                DataView mv = ms.loadAllData();
                DataView ev = es.loadAllData();
                DataView gv = gs.loadAllData();
                DataView fmv = fms.loadAllData();

                DataTable tableNettoyee = new TableAccueilMatchs().getTable();
                DataRow row;

                foreach (DataRowView dr in mv)
                {
                    DateTime dt = (DateTime)dr["matchDate"];
                    if (dt.Year == annee)
                    {
                        row = tableNettoyee.NewRow();

                        // rempli la colonne des dates de match
                        row[0] = dr["matchDate"];


                        // rempli la colonne du nom de l'équipe A
                        Boolean trouve = false;
                        int i = 0;
                        while (trouve == false)
                        {
                            if ((Guid)dr["equipe1Id"] == (Guid)ev[i]["equipeId"])
                            {
                                row[1] = ev[i]["nom"];
                                trouve = true;
                            }
                            i++;
                        }

                        // rempli la colonne du nom de l'équipe B
                        trouve = false;
                        i = 0;
                        while (trouve == false)
                        {
                            if ((Guid)dr["equipe2Id"] == (Guid)ev[i]["equipeId"])
                            {
                                row[2] = ev[i]["nom"];
                                trouve = true;
                            }
                            i++;
                        }


                        // rempli la colonne du nombre de goal (en string)
                        int goalA = 0;
                        int goalB = 0;

                        for (int j = 0; j < gv.Count; j++)
                        {
                            if ((Guid)dr["matchId"] == (Guid)gv[j]["matchId"])
                            {
                                if ((Guid)gv[j]["equipeId"] == (Guid)dr["equipe1Id"])
                                {
                                    goalA++;
                                }
                            }
                        }

                        for (i = 0; i < gv.Count; i++)
                        {
                            if ((Guid)dr["matchId"] == (Guid)gv[i]["matchId"])
                            {
                                if ((Guid)gv[i]["equipeId"] == (Guid)dr["equipe2Id"])
                                {
                                    goalB++;
                                }
                            }
                        }

                        row[3] = goalA + " - " + goalB;

                        // rempli la colonne pour savoir si les feuilles de matchs sont bien remplies
                        row[4] = false;

                        int countA = 0;
                        int countB = 0;

                        List<dynamic> lstParamA = new List<dynamic>();
                        List<dynamic> lstParamB = new List<dynamic>();


                        for (i = 0; i<fmv.Count; i++)
                        {
                            if ((Guid)dr["matchId"] == (Guid)fmv[i]["matchId"])
                            {
                                if ((Guid)dr["equipe1Id"] == (Guid)fmv[i]["equipeId"])
                                {
                                    lstParamA.Add((Guid)fmv[i]["feuilleId"]);
                                    DataView oView = jps.loadWithParameter("PartA", lstParamA);
                                    countA = oView.Count;
                                }

                                if ((Guid)dr["equipe2Id"] == (Guid)fmv[i]["equipeId"])
                                {
                                    lstParamB.Add((Guid)fmv[i]["feuilleId"]);
                                    DataView oView = jps.loadWithParameter("PartB", lstParamB);
                                    countB = oView.Count;
                                }
                            }
                        }


                        if (countA >4 && countB>4)
                        {
                            row[4] = true;
                        }

                        // rempli la colonne pour savoir si les matchs sont joués ou forfaits
                        row[5] = dr["isPlayed"];

                        // rempli la colonne des matchId
                        row[6] = dr["matchId"];

                        tableNettoyee.Rows.Add(row);
                    }
                }

                return tableNettoyee;


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

    }
}
