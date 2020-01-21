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
