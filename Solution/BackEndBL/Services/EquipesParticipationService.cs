﻿using FifaDAL.BackEnd;
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
            List<EquipesParticipationModele> lEquParti;

            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                lEquParti = ctx.EquipesParticipation.ToList();
            }
            return lEquParti;
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

                catch (SqlException exsql)
                {
                    CustomsError oErreur = new CustomsError(exsql);
                    throw oErreur;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

    }


}