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
    public class JoueursService : MatchManagementService
    {
        public JoueursService()
        {
            this.name = "Joueurs";
        }

        public List<JoueursModele> GetListeObject()
        {
            try
            {
                List<JoueursModele> listeJoueurs = new List<JoueursModele>();
                return listeJoueurs = ConvertDataTable<JoueursModele>(this.loadAllData().ToTable());
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

        public List<JoueursModele> GetListeObject(DataTable oTable)
        {
            try
            {
                List<JoueursModele> listeJoueurs = new List<JoueursModele>();
                return listeJoueurs = ConvertDataTable<JoueursModele>(oTable);
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
