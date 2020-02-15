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
    public class CartesJaunesService : BackEndService
    {
        //retourne la liste des cartons jaunes
        public List<CartonsJaunesModele> ListAll()
        {
            List<CartonsJaunesModele> lcj = new List<CartonsJaunesModele>();

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (dynamic dyn in ctx.CartonsJaunes_GetAll())
                    {
                        CartonsJaunesModele cj = new CartonsJaunesModele();
                        cj = dyn;
                        lcj.Add(cj);
                    }
                     
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
            return lcj;
        }
    }
}
