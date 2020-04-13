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
        public void Delete(Guid championnatId)
        {

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    ctx.Quarters_Delete(championnatId);

                    using (TransactionScope scope = new TransactionScope())
                    {
                        ctx.SaveChanges();
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }


        public Boolean checkPasDansQuarter (DateTime date)
        {

            try
            {
                // obtient la liste des quarters
                List<FifaModeles.QuartersModele> lQuarters = this.ListAll();

                foreach (FifaModeles.QuartersModele quarter in lQuarters)
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
                if (ex.InnerException != null && ex.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException);
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
                    if (ex.InnerException != null && ex.InnerException is SqlException)
                    {
                        TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException);
                        throw oErreur;
                    }
                    else
                    {
                        throw ex;
                    }
                }

            }
        }

        public List<FifaModeles.QuartersModele> ListAll()
        {
            try
            {
                List<FifaModeles.QuartersModele> lQuarters = new List<FifaModeles.QuartersModele>();

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (Quarters_GetAll_Result oQuart in ctx.Quarters_GetAll())
                    {
                        FifaModeles.QuartersModele quarter = new FifaModeles.QuartersModele();
                        quarter.quartersId = oQuart.quartersId;
                        quarter.dateDebut = oQuart.dateDebut;
                        quarter.dateFin = oQuart.dateFin;
                        quarter.lastUpdate = oQuart.lastUpdate;
                        quarter.championnatId = oQuart.championnatId;
                        lQuarters.Add(quarter);
                    }
                }
                return lQuarters;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }


        }

        public List<FifaModeles.QuartersModele> ListOneChampionnat(FifaModeles.ChampionnatsModele championnat)
        {
            try
            {
                List<FifaModeles.QuartersModele> lQuarters;

                lQuarters = this.ListAll().Where(xx => xx.championnatId == championnat.championnatId)
                                        .ToList();

                return lQuarters;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is SqlException)
                {
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException);
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
