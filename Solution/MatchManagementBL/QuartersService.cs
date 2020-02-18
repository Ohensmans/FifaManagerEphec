using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public class QuartersService : MatchManagementService
    {
        public QuartersService()
        {
            this.name = "Quarters";
        }

        public List<QuartersModele> GetListeObject()
        {
            try
            {
                List<QuartersModele> listeJoueurs = new List<QuartersModele>();
                return listeJoueurs = ConvertDataTable<QuartersModele>(this.loadAllData().ToTable());
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

        public QuartersModele getAQuarter (DateTime matchDate)
        {
            try
            {
                List<QuartersModele> lQuarters = this.GetListeObject();
                QuartersModele quarter = lQuarters.Where(xx => xx.dateDebut <= matchDate)
                                                  .Where(xx => xx.dateFin >= matchDate)
                                                  .FirstOrDefault();
                return quarter;
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
