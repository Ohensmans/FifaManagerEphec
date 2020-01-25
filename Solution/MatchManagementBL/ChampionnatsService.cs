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
    public class ChampionnatsService : MatchManagementService
    {

        public ChampionnatsService()
        {
            this.name = "Championnats";
        }

        public List <ChampionnatsModele> GetListeObject ()
        {
            try 
            { 
                List<ChampionnatsModele> listeChampionnats = new List<ChampionnatsModele>();
                return listeChampionnats = ConvertDataTable<ChampionnatsModele>(this.loadAllData().ToTable());
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
