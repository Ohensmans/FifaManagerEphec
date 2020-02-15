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
    public class CartesJaunesService : BackEndService
    {
        //retourne la liste des cartons jaunes
        public List<CartonsJaunesModele> ListAll()
        {
            List<CartonsJaunesModele> lcj = new List<CartonsJaunesModele>();

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (CartonsJaunes_GetAll_Result oCarte in ctx.CartonsJaunes_GetAll())
                    {
                        CartonsJaunesModele cj = new CartonsJaunesModele();

                        cj.carteJauneId = oCarte.carteJauneId;
                        cj.joueurId = oCarte.joueurId;
                        cj.isActive = oCarte.isActive;
                        cj.matchId = oCarte.matchId;
                        cj.minuteRecue = oCarte.minuteRecue;
                        cj.equipeId = oCarte.equipeId;

                        lcj.Add(cj);
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
            return lcj;
        }
    }
}
