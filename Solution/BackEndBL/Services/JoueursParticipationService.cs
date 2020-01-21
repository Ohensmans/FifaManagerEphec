using FifaDAL.BackEnd;
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
        public List<JoueursParticipationModele> ListAll()
        {
            try
            {
                List<JoueursParticipationModele> lJoueursParticipation;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lJoueursParticipation = ctx.JoueursParticipation.ToList();
                }
                return lJoueursParticipation;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    CustomsError oErreur = new CustomsError((SqlException)ex.InnerException.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }
        }




        // renvoie vrai si le joueur à joueur un match après la date fournie
        public Boolean checkJoueurParticipation(Guid joueurId, DateTime date)
        {
            try
            {
                int countJoueursParticipation;
                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    countJoueursParticipation = ctx.JoueursParticipation
                                               .Where(xx => xx.joueurId == joueurId)
                                               .Include("FeuillesDeMatch.Matchs")
                                               .Where(yy => yy.FeuillesDeMatch.Matchs.matchDate > date)
                                               .Count();
                }
                if (countJoueursParticipation>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    CustomsError oErreur = new CustomsError((SqlException)ex.InnerException.InnerException);
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
