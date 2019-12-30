using FifaError;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public static class GenerationTableaux
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

                DataTable tableNettoyee = new DataTable();
                DataRow row;


                DataColumn date = new DataColumn();
                date.DataType = System.Type.GetType("System.DateTime");
                date.ColumnName = "Date du Match :";
                tableNettoyee.Columns.Add(date);

                DataColumn equipeA = new DataColumn();
                equipeA.DataType = System.Type.GetType("System.String");
                equipeA.ColumnName = "Equipe A :";
                tableNettoyee.Columns.Add(equipeA);

                DataColumn equipeB = new DataColumn();
                equipeB.DataType = System.Type.GetType("System.String");
                equipeB.ColumnName = "Equipe B :";
                tableNettoyee.Columns.Add(equipeB);

                DataColumn resultat = new DataColumn();
                resultat.DataType = System.Type.GetType("System.String");
                resultat.ColumnName = "Résultat :";
                tableNettoyee.Columns.Add(resultat);

                DataColumn matchJoue = new DataColumn();
                matchJoue.DataType = System.Type.GetType("System.Boolean");
                matchJoue.ColumnName = "Match Joué : ";
                tableNettoyee.Columns.Add(matchJoue);

                DataColumn matchId = new DataColumn();
                matchId.DataType = System.Type.GetType("System.Guid");
                matchId.ColumnName = "matchId";
                tableNettoyee.Columns.Add(matchId);


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
