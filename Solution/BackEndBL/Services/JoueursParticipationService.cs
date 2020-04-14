using FifaDAL.BackEndDBF;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.Services
{
    public class JoueursParticipationService : BackEndService
    {


        public List<FifaModeles.JoueursParticipationModele> ListAll()
        {
            try
            {
                List<FifaModeles.JoueursParticipationModele> lJoueursParticipation = new List<FifaModeles.JoueursParticipationModele>() ;

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (JoueursParticipation_GetAll_Result joueur in ctx.JoueursParticipation_GetAll())
                    {
                        FifaModeles.JoueursParticipationModele jpm = new FifaModeles.JoueursParticipationModele();
                        jpm.joueurId = joueur.joueurId;
                        jpm.feuilleId = joueur.feuilleId;
                        jpm.lastUpdate = joueur.lastUpdate;
                        lJoueursParticipation.Add(jpm);
                    }
                }
                return lJoueursParticipation;
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




        // renvoie true si le joueur n'a pas joué un match après la date fournie
        public Boolean checkJoueurSiPasParticipation(Guid joueurId, DateTime date)
        {
            try
            {
                int countJoueursParticipation;
                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    countJoueursParticipation = ctx.NombreParticipationJoueurApresDate(joueurId, date);
                }
                if (countJoueursParticipation>0)
                {
                    BusinessError oBusiness = new BusinessError("Le joueur a été inscrit sur une feuille de match à une date postérieure");
                    throw oBusiness;
                }
                else
                {
                    return true;
                }

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
