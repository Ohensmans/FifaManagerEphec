using FifaDAL.BackEnd;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BackEndBL.Services
{
    public class IntersaisonsService : BackEndService
    {
        public void enregistrerNewIntersaison(DateTime dateDebut, DateTime dateFin, Guid championnatId)
        {
            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                try
                {
                    // crée une nouvelle intersaison
                    IntersaisonsModele oInter = new IntersaisonsModele(dateDebut, dateFin, championnatId);
                    ctx.Intersaisons.Add(oInter);

                    using (TransactionScope scope = new TransactionScope())
                    {
                        ctx.SaveChanges();
                        scope.Complete();
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
}
