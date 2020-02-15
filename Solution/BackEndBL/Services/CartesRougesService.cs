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
    public class CartesRougesService : BackEndService
    {
        public List<CartonsRougesModele> ListAll()
        {
            List<CartonsRougesModele> lcr = new List<CartonsRougesModele>() ;

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (dynamic dyn in ctx.CartonsRouges_GetAll())
                    {
                        CartonsRougesModele cr = new CartonsRougesModele();
                        cr = dyn;
                        lcr.Add(cr);
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
            return lcr;
        }
    }
}
