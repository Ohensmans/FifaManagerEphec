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
    public class EquipesParticipationService : BackEndService
    {
        public List<EquipesParticipationModele> ListAll()
        {
            try
            {
                List<EquipesParticipationModele> lEquParti;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lEquParti = ctx.EquipesParticipation.ToList();
                }
                return lEquParti;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    CustomsError oErreur = new CustomsError((SqlException)ex.InnerException.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public void enregistrerEquipesParticipation (List<EquipesModele> lEquipe, Guid championnatId)
        {
            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                try
                {
                    foreach (EquipesModele equipe in lEquipe)
                    {
                        EquipesParticipationModele epm = new EquipesParticipationModele(equipe.equipeId, championnatId);
                        ctx.EquipesParticipation.Add(epm);
                    }

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
                        CustomsError oErreur = new CustomsError((SqlException)ex.InnerException.InnerException);
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
