using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public class GoalsService : MatchManagementService
    {
        public GoalsService()
        {
            this.name = "Goals";
        }

        public List<GoalsModele> GetListeObject()
        {
            try
            {
                List<GoalsModele> listeJoueurs = new List<GoalsModele>();
                return listeJoueurs = ConvertDataTable<GoalsModele>(this.loadAllData().ToTable());
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

