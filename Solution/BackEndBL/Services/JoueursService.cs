using FifaDAL.BackEndDBF;
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
        public List<FifaModeles.JoueursModele> ListAll()
        {
            try
            {
                List<FifaModeles.JoueursModele> lJoueurs = new List<FifaModeles.JoueursModele>() ;

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (Joueurs_GetAll_Result oJou in ctx.Joueurs_GetAll())
                    {
                        FifaModeles.JoueursModele joueur = new FifaModeles.JoueursModele();
                        joueur.joueurId = oJou.joueurId;
                        joueur.nom = oJou.nom;
                        joueur.prenom = oJou.prenom;
                        joueur.lastUpdate = oJou.lastUpdate;
                        lJoueurs.Add(joueur);
                    }
                }
                return lJoueurs;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }
        }

        // retourne l'objet joueur qui correspond à un nom complet ou une business Error si il n'existe pas
        public FifaModeles.JoueursModele GetJoueurs (string nomCompletJoueur)
        {
            try
            {
                List<FifaModeles.JoueursModele> lJoueurs = this.ListAll();

                foreach (FifaModeles.JoueursModele joueur in lJoueurs)
                {
                    if ((joueur.prenom+" "+ joueur.nom).Equals(nomCompletJoueur))
                    {
                        return joueur;
                    }
                }

                BusinessError oErreur = new BusinessError("Ce joueur n'existe pas");
                throw oErreur;
                
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public List<FifaModeles.JoueursModele> getListeJoueurs(List<Guid> lId)
        {
            try
            {
                List<FifaModeles.JoueursModele> lJoueurs = new List<FifaModeles.JoueursModele>();

                foreach (Guid joueur in lId)
                {
                    lJoueurs.Add(this.GetJoueurs(joueur));
                }
                return lJoueurs;


            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }
        }



        public FifaModeles.JoueursModele GetJoueurs(Guid joueurId)
        {
            try
            {
                List<FifaModeles.JoueursModele> lJoueurs = this.ListAll();

                foreach (FifaModeles.JoueursModele joueur in lJoueurs)
                {
                    if (joueur.joueurId == joueurId)
                    {
                        return joueur;
                    }
                }

                BusinessError oErreur = new BusinessError("Ce joueur n'existe pas");
                throw oErreur;

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException);
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
