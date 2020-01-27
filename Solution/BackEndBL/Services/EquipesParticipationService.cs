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
                    TechnicalError oErreur = new TechnicalError((SqlException)ex.InnerException.InnerException);
                    throw oErreur;
                }
                else
                {
                    throw ex;
                }
            }
        }

        //renvoie la liste des équipes participants à un championnat
        public List<EquipesParticipationModele> ListeEquipeChampionnat(ChampionnatsModele championnat)
        {
            try
            {
                List<EquipesParticipationModele> lEquParti;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lEquParti = ctx.EquipesParticipation.Where(xx => xx.championnatId == championnat.championnatId)
                                                        .ToList();
                }
                return lEquParti;
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




        public void enregistrerEquipesParticipation (List<EquipesModele> lEquipe, Guid championnatId)
        {
            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                try
                {
                    foreach (EquipesModele equipe in lEquipe)
                    {
                        if (checkPasTransfertAvantParticipation(equipe, championnatId))
                        {
                            EquipesParticipationModele epm = new EquipesParticipationModele(equipe.equipeId, championnatId);
                            ctx.EquipesParticipation.Add(epm);
                        }
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

        //vérifie si il y n'a pas eu un transfert encodé d'un joueur lors de la saison avant la création de la participation de l'équipe
        public Boolean checkPasTransfertAvantParticipation(EquipesModele equipe, Guid championnatId)
        {
            try
            {
                //récupère la liste des transferts
                TransfertsService ts = new TransfertsService();
                List<TransfertsModele> lTransferts = ts.ListAll();

                //récupère l'année du championnat
                ChampionnatService cs = new ChampionnatService();
                int annee = cs.getAnnee(championnatId);

                foreach (TransfertsModele transfert in lTransferts )
                {
                    //vérfie pour chaque transfert si il y a eu déjà un transfert pour l'équipe l'année du championnat en création ou renvoie une businessError
                    if ((transfert.dateDebut.Year == annee || (transfert.dateFin.HasValue && transfert.dateFin.Value.Year == annee))&&(transfert.equipeId == equipe.equipeId))
                    {
                        BusinessError oBusiness = new BusinessError("Il y a déjà eu des transferts de joueurs enregistrés cette année, l'équipe ne peut pas être inscrite dans le championnat");
                        throw oBusiness;
                    }
                }

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

    
    // vérifie si une équipe participe bien à un championnat
    public Boolean isParticipation (EquipesModele equipe, DateTime date)
        {
            try
            {
                ChampionnatService cs = new ChampionnatService();
                List<ChampionnatsModele> lChampionnat = cs.ListAll();

                //récupère le bon championnat
                int i = 0;
                ChampionnatsModele championnat = null;
                while (i < lChampionnat.Count && championnat == null)
                {
                    if (date.Year == lChampionnat[i].annee)
                    {
                        championnat = lChampionnat[i];
                    }
                    i++;
                }

                //vérification, mais ne devrait jamais arrivé car il faut tester avant si il y a une intersaison qui existe
                if (championnat == null)
                {
                    BusinessError oBusiness = new BusinessError("Il n'y a pas de championnat à cette date");
                    throw oBusiness;
                }

                List<EquipesParticipationModele> lParticipation = this.ListAll();
                
                //vérifie si il y a une participation de l'équipe avec le championant correspondant à la date
                foreach (EquipesParticipationModele participation in lParticipation)
                {
                    if (participation.championnatId == championnat.championnatId && participation.equipeId == equipe.equipeId)
                    {
                        return true;
                    }
                }

                return false;


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
