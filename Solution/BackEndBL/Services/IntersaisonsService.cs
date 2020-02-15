
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
    public class IntersaisonsService : BackEndService
    {
        public void enregistrerNewIntersaison(DateTime dateDebut, DateTime dateFin, Guid championnatId)
        {
            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    // crée une nouvelle intersaison
                    ctx.Intersaisons_Add(dateDebut, dateFin, championnatId);

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
                List<FifaModeles.IntersaisonsModele> lIntersaison = this.ListAll();

                foreach (FifaModeles.IntersaisonsModele intersaison in lIntersaison)
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

        public List<FifaModeles.IntersaisonsModele> ListAll()
        {
            try
            {
                List<FifaModeles.IntersaisonsModele> lIntersaison = new List<FifaModeles.IntersaisonsModele>() ;

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (Intersaisons_GetAll_Result oInter in ctx.Intersaisons_GetAll())
                    {
                        FifaModeles.IntersaisonsModele inter = new FifaModeles.IntersaisonsModele();
                        inter.intersaisonID = oInter.intersaisonID;
                        inter.dateDebut = oInter.dateDebut;
                        inter.dateFin = oInter.dateFin;
                        inter.lastUpdate = oInter.lastUpdate;
                        inter.championnatId = oInter.championnatId;
                        lIntersaison.Add(inter);
                    }
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
