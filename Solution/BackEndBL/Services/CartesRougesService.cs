using FifaDAL.BackEndDBF;
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
        public List<FifaModeles.CartonsRougesModele> ListAll()
        {
            List<FifaModeles.CartonsRougesModele> lcr = new List<FifaModeles.CartonsRougesModele>() ;

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (CartonsRouges_GetAll_Result oCarte in ctx.CartonsRouges_GetAll())
                    {
                        FifaModeles.CartonsRougesModele cr = new FifaModeles.CartonsRougesModele();
                        cr.carteRougeId = oCarte.carteRougeId;
                        cr.joueurId = oCarte.joueurId;
                        cr.nombreSuspensionsRestantes = oCarte.nombreSuspensionsRestantes;
                        cr.matchId = oCarte.matchId;
                        cr.minuteRecue = oCarte.minuteRecue;
                        cr.equipeId = oCarte.equipeId;
                        lcr.Add(cr);
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
            return lcr;
        }
    }
}
