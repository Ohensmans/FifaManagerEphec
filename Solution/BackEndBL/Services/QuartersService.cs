using FifaDAL.BackEndDBF;
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

        public Boolean checkPasDansQuarter (DateTime date)
        {

            try
            {
                // obtient la liste des quarters
                List<QuartersModele> lQuarters = this.ListAll();

                foreach (QuartersModele quarter in lQuarters)
                {
                    if (date <= quarter.dateFin && date >= quarter.dateDebut)
                    {
                        // retourne un BusinessError si on trouve un quarter dans lequel la date se trouve
                        BusinessError bErreur = new BusinessError("La date encodée est dans un quarter");
                        throw bErreur;
                    }
                }
                // si il n'a trouvé de quarter qui corresponde renvoie true
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

        public void enregistrerNewQuarter(DateTime dateDebut, DateTime dateFin, Guid championnatId)
        {
            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    // crée un nouveau quarter
                    ctx.Quarters_Add(dateDebut, dateFin, championnatId);

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

        public List<QuartersModele> ListAll()
        {
            try
            {
                List<QuartersModele> lQuarters = new List<QuartersModele>();

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (dynamic dyn in ctx.Quarters_GetAll())
                    {
                        QuartersModele quarter = new QuartersModele();
                        quarter = dyn;
                        lQuarters.Add(quarter);
                    }
                }
                return lQuarters;
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

        public List<QuartersModele> ListOneChampionnat(ChampionnatsModele championnat)
        {
            try
            {
                List<QuartersModele> lQuarters;

                lQuarters = this.ListAll().Where(xx => xx.championnatId == championnat.championnatId)
                                        .ToList();

                return lQuarters;
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
