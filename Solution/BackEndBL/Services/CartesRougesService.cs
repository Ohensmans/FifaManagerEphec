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
    public class CartesRougesService : BackEndService
    {
        public List<CartonsRougesModele> ListAll()
        {
            List<CartonsRougesModele> lcr;

            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                try
                {
                    lcr = ctx.CartonsRouges.ToList();
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
