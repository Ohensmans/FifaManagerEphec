using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public class IntersaisonsService : MatchManagementService
    {
        public IntersaisonsService()
        {
            this.name = "Intersaisons";
        }

        public List<IntersaisonsModele> GetListeObject()
        {
            try
            {
                List<IntersaisonsModele> listeIntersaisons = new List<IntersaisonsModele>();
                return listeIntersaisons = ConvertDataTable<IntersaisonsModele>(this.loadAllData().ToTable());
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

        public DateTime GetDateDebut(int annee)
        {
            try
            {
                List<IntersaisonsModele> listeIntersaisons = this.GetListeObject();
                return listeIntersaisons.First(x => x.dateDebut.Year == annee).dateDebut;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime GetDateFin(int annee)
        {
            try
            {
                List<IntersaisonsModele> listeIntersaisons = this.GetListeObject();
                return listeIntersaisons.First(x => x.dateDebut.Year == annee).dateFin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
