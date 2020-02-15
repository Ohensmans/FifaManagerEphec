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
    public class GoalsService : BackEndService
    {
        public List<GoalsModele> ListAll()
        {
            List<GoalsModele> lGoals = new List<GoalsModele>() ;

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (dynamic dyn in ctx.Goals_GetAll())
                    {
                        GoalsModele goal = new GoalsModele();
                        goal = dyn;
                        lGoals.Add(goal);
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
            return lGoals;
        }
    }
}
