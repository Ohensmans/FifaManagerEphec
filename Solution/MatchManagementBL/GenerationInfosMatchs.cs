using FifaError;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public static class  GenerationInfosMatchs
    {
        public static String getEquipeAName(Guid matchid)
        {
            try
            {
                MatchsService ms = new MatchsService();
                DataView mv = ms.loadAllData();

                EquipesService es = new EquipesService();
                DataView ev = es.loadAllData();


                int i = 0;
                while ((Guid)mv[i]["matchId"] != matchid)
                {
                    i++;
                }

                int j = 0;
                while ((Guid)ev[j]["equipeId"] != (Guid)mv[i]["equipe1Id"])
                {
                    j++;
                }
                return ev[j]["nom"].ToString();
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

        public static String getEquipeBName(Guid matchid)
        {
            try
            {
                MatchsService ms = new MatchsService();
                DataView mv = ms.loadAllData();

                EquipesService es = new EquipesService();
                DataView ev = es.loadAllData();


                int i = 0;
                while ((Guid)mv[i]["matchId"] != matchid)
                {
                    i++;
                }

                int j = 0;
                while ((Guid)ev[j]["equipeId"] != (Guid)mv[i]["equipe2Id"])
                {
                    j++;
                }
                return ev[j]["nom"].ToString();
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

        public static DateTime getDateMatch(Guid matchid)
        {
            try
            {
                MatchsService ms = new MatchsService();
                DataView mv = ms.loadAllData();

                int i = 0;
                while ((Guid)mv[i]["matchId"] != matchid)
                {
                    i++;
                }

                return (DateTime)mv[i]["matchDate"];


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

        public static String getlogoEquipeA(Guid matchid)
        {
            try
            {
                MatchsService ms = new MatchsService();
                DataView mv = ms.loadAllData();

                EquipesService es = new EquipesService();
                DataView ev = es.loadAllData();


                int i = 0;
                while ((Guid)mv[i]["matchId"] != matchid)
                {
                    i++;
                }

                int j = 0;
                while ((Guid)ev[j]["equipeId"] != (Guid)mv[i]["equipe1Id"])
                {
                    j++;
                }
                return ev[j]["logoPath"].ToString();
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

        public static String getlogoEquipeB(Guid matchid)
        {
            try
            {
                MatchsService ms = new MatchsService();
                DataView mv = ms.loadAllData();

                EquipesService es = new EquipesService();
                DataView ev = es.loadAllData();


                int i = 0;
                while ((Guid)mv[i]["matchId"] != matchid)
                {
                    i++;
                }

                int j = 0;
                while ((Guid)ev[j]["equipeId"] != (Guid)mv[i]["equipe2Id"])
                {
                    j++;
                }
                return ev[j]["logoPath"].ToString();
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
