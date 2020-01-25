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

namespace BackEndBL
{
    public class ChampionnatService : BackEndService
    {

        //renvoie l'année d'un championnat ou un businessError si il n'existe pas
        public int getAnnee (Guid championnatId)
        {
            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                try
                {
                    return ctx.Championnats.Where(xx => xx.championnatId == championnatId).FirstOrDefault().annee;
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

        //renvoie l'année d'un championnat ou un businessError si il n'existe pas
        public ChampionnatsModele getChampionnat(int annee)
        {
            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                try
                {
                    return ctx.Championnats.Where(xx => xx.annee == annee).FirstOrDefault();
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

        public List<ChampionnatsModele> ListAll()
        {
            List<ChampionnatsModele> lChamp;

            using (FifaManagerContext ctx =  new FifaManagerContext(_Connection))
            {
                try
                {
                    lChamp = ctx.Championnats.ToList();
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
            return lChamp;
        }

        //renvoie true si il a pu créer le championnat et en out le guid de ce nouveau championnat
        public Boolean enregistrerNewChampionnat(int annee, out Guid championnatId)
        {
            Boolean _return = false;
            championnatId = Guid.Empty;

            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                try
                {

                    //vérifie si un championnat existe déjà pour l'année annee et la crée si non.
                    if (ctx.Championnats.Where(x => x.annee == annee).FirstOrDefault() == null)
                    {
                        ChampionnatsModele oChamp = new ChampionnatsModele(annee);
                        ctx.Championnats.Add(oChamp);

                        using (TransactionScope scope = new TransactionScope())
                        {
                            ctx.SaveChanges();
                            championnatId = oChamp.championnatId;
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
