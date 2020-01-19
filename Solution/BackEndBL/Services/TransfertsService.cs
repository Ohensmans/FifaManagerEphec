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
    public class TransfertsService : BackEndService
    {
        public List<TransfertsModele> ListAll()
        {
            try
            {
                List<TransfertsModele> lTransferts;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lTransferts = ctx.Transferts.ToList();
                }
                return lTransferts;
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
