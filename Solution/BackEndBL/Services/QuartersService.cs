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
    public class QuartersService : BackEndService
    {
        public void enregistrerNewQuarter(DateTime dateDebut, DateTime dateFin, Guid championnatId)
        {
            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                try
                {
                    // crée un nouveau quarter
                    QuartersModele oQuarter = new QuartersModele(dateDebut, dateFin, championnatId);
                    ctx.Quarters.Add(oQuarter);

                    using (TransactionScope scope = new TransactionScope())
                    {
                        ctx.SaveChanges();
                        scope.Complete();
                    }
                }

                catch (SqlException exsql)
                {
                    CustomsError oErreur = new CustomsError(exsql);
                    throw oErreur;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public List<QuartersModele> ListAll()
        {
            try
            {
                List<QuartersModele> lQuarters;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lQuarters = ctx.Quarters.ToList();
                }
                return lQuarters;
            }
            catch (SqlException exsql)
            {
                CustomsError oErreur = new CustomsError(exsql);
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}
