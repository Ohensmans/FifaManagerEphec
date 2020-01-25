using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    class EquipesService : MatchManagementService
    {
        public EquipesService()
        {
            this.name = "Equipes";
        }

        public List<EquipesModele> GetListeObject()
        {
            try
            {
                List<EquipesModele> listeEquipes = new List<EquipesModele>();
                return listeEquipes = ConvertDataTable<EquipesModele>(this.loadAllData().ToTable());
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
