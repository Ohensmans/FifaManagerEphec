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
                        TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException.InnerException);
                        throw oErreur;
                    }
                    else
                    {
                        throw ex;
                    }
                }

            }
        }

        public Boolean checkPasDansIntersaison(DateTime date)
        {

            try
            {
                // obtient la liste des intersaisons
                List<IntersaisonsModele> lIntersaison = this.ListAll();

                foreach (IntersaisonsModele intersaison in lIntersaison)
                {
                    if (date <= intersaison.dateFin && date >= intersaison.dateDebut)
                    {
                        // retourne false si la date est dans une intersaison
                        return false;
                    }
                }
                // si il n'a trouvé d'intersaison qui corresponde renvoie true
                return true;

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

        public List<IntersaisonsModele> ListAll()
        {
            try
            {
                List<IntersaisonsModele> lIntersaison;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lIntersaison = ctx.Intersaisons.ToList();
                }
                return lIntersaison;
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
    }
}
