using FifaDAL.BackEnd;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.Services
{
    public class JoueursService : BackEndService
    {
        public List<JoueursModele> ListAll()
        {
            try
            {
                List<JoueursModele> lJoueurs;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lJoueurs = ctx.Joueurs.ToList();
                }
                return lJoueurs;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }
        }

        // retourne l'objet joueur qui correspond à un nom complet ou une business Error si il n'existe pas
        public JoueursModele GetJoueurs (string nomCompletJoueur)
        {
            try
            {
                List<JoueursModele> lJoueurs = this.ListAll();

                foreach (JoueursModele joueur in lJoueurs)
                {
                    if ((joueur.prenom+" "+joueur.nom).Equals(nomCompletJoueur))
                    {
                        return joueur;
                    }
                }

                BusinessError oErreur = new BusinessError("Ce joueur n'existe pas");
                throw oErreur;
                
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }
        }

    }
}
