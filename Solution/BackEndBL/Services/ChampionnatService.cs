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

namespace BackEndBL
{
    public class ChampionnatService : BackEndService
    {

        //renvoie l'année d'un championnat
        public int getAnnee (Guid championnatId)
        {
            try
            {
                return this.ListAll().Where(xx => xx.championnatId == championnatId).FirstOrDefault().annee;
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

        //renvoie un championnat selon une année
        public ChampionnatsModele getChampionnat(int annee)
        {
            try
            {
                return this.ListAll().Where(xx => xx.annee == annee).FirstOrDefault();
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

        public List<ChampionnatsModele> ListAll()
        {
            List<ChampionnatsModele> lch = new List<ChampionnatsModele>();

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (dynamic dyn in ctx.Championnats_GetAll())
                    {
                        ChampionnatsModele ch = new ChampionnatsModele();
                        ch = dyn;
                        lch.Add(ch);
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
            return lch;
        }

        //renvoie true si il a pu créer le championnat et en out le guid de ce nouveau championnat
        public Boolean enregistrerNewChampionnat(int annee, out Guid championnatId)
        {
            Boolean _return = false;
            championnatId = Guid.Empty;

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    //vérifie si un championnat existe déjà pour l'année annee et la crée si non.
                    if (this.ListAll().Where(x => x.annee == annee).FirstOrDefault() == null)
                    {
                        ctx.Championnats_Add(annee);

                        using (TransactionScope scope = new TransactionScope())
                        {
                            ctx.SaveChanges();
                            championnatId = this.getChampionnat(annee).championnatId;
                            scope.Complete();
                        }

                        _return = true;
                    }                  
                    if (!_return)
                    {
                        BusinessError oErreur = new BusinessError("Ce championnat existe déjà");
                        throw oErreur;
                    }
                    return _return;
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
}
