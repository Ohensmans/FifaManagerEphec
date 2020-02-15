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
        public List<FifaModeles.GoalsModele> ListAll()
        {
            List<FifaModeles.GoalsModele> lGoals = new List<FifaModeles.GoalsModele>() ;

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (Goals_GetAll_Result oGoal in ctx.Goals_GetAll())
                    {
                        FifaModeles.GoalsModele goal = new FifaModeles.GoalsModele();
                        goal.goalId = oGoal.goalId;
                        goal.joueurId = oGoal.joueurId;
                        goal.matchId = oGoal.matchId;
                        goal.lastUpdate = oGoal.lastUpdate;
                        goal.minuteMarque = oGoal.minuteMarque;
                        goal.equipeId = oGoal.equipeId;
                        lGoals.Add(goal);
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
            return lGoals;
        }
    }
}
