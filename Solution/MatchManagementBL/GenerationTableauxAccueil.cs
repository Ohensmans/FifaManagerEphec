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

                DataView mv = ms.loadAllData();
                DataView ev = es.loadAllData();
                DataView gv = gs.loadAllData();

                DataTable tableNettoyee = new TableAccueilMatchs().getTable();
                DataRow row;

                foreach (DataRowView dr in mv)
                {
                    DateTime dt = (DateTime)dr["matchDate"];
                    if (dt.Year == annee)
                    {
                        row = tableNettoyee.NewRow();
                        row[0] = dr["matchDate"];

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

                        int goalA = 0;
                        int goalB = 0;

                        for (int j = 0; j < gv.Count; j++)
                        {
                            if (dr["matchId"] == gv[j]["matchId"])
                            {
                                if (gv[j]["equipeId"] == dr["equipe1Id"])
                                {
                                    goalA++;
                                }
                            }
                        }

                        for (i = 0; i < gv.Count; i++)
                        {
                            if (dr["matchId"] == gv[i]["matchId"])
                            {
                                if (gv[i]["equipeId"] == dr["equipe2Id"])
                                {
                                    goalB++;
                                }
                            }
                        }

                        row[3] = goalA + " - " + goalB;

                        row[4] = dr["isPlayed"];

                        row[5] = dr["matchId"];

                        tableNettoyee.Rows.Add(row);
                    }
                }

                return tableNettoyee;


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
