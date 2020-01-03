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
    public class MatchsService : MatchManagementService
    {
        public MatchsService()
        {
            this.name = "Matchs";
        }

        public List<MatchsModele> GetListeObject()
        {
            try
            {
                List<MatchsModele> listeMatchs= new List<MatchsModele>();
                return listeMatchs = ConvertDataTable<MatchsModele>(this.loadAllData().ToTable());
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

        public DateTime getMatchDate(Guid matchId)
        {
            try
            {
                DataView mv = this.loadAllData();

                int i = 0;

                while ((Guid)mv[i]["matchId"] != matchId || i <= mv.Count)
                {
                    i++;
                }

                return (DateTime)mv[i]["matchDate"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
