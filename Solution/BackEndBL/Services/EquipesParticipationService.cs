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
    public class EquipesParticipationService : BackEndService
    {
        public List<FifaModeles.EquipesParticipationModele> ListAll()
        {
            try
            {
                List<FifaModeles.EquipesParticipationModele> lEquParti = new List<FifaModeles.EquipesParticipationModele>() ;

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (EquipesParticipation_GetAll_Result equipe in ctx.EquipeParticipation_GetAll())
                    {
                        FifaModeles.EquipesParticipationModele ep = new FifaModeles.EquipesParticipationModele();
                        ep.equipeId = equipe.equipeId;
                        ep.championnatId = equipe.championnatId;
                        ep.lastUpdate = equipe.lastUpdate;
                        lEquParti.Add(ep);
                    }
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
        public List<FifaModeles.EquipesParticipationModele> ListeEquipeChampionnat(FifaModeles.ChampionnatsModele championnat)
        {
            try
            {
                List<FifaModeles.EquipesParticipationModele> lEquParti = this.ListAll().Where(xx => xx.championnatId == championnat.championnatId)
                                                                            .ToList();
                
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




        public void enregistrerEquipesParticipation (List<FifaModeles.EquipesModele> lEquipe, Guid championnatId)
        {
            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (FifaModeles.EquipesModele equipe in lEquipe)
                    {
                        if (checkPasTransfertAvantParticipation(equipe, championnatId))
                        {
                            ctx.EquipeParticipation_Add(equipe.equipeId, championnatId);
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
        public Boolean checkPasTransfertAvantParticipation(FifaModeles.EquipesModele equipe, Guid championnatId)
        {
            try
            {
                //récupère la liste des transferts
                TransfertsService ts = new TransfertsService();
                List<FifaModeles.TransfertsModele> lTransferts = ts.ListAll();

                //récupère l'année du championnat
                ChampionnatService cs = new ChampionnatService();
                int annee = cs.getAnnee(championnatId);

                foreach (FifaModeles.TransfertsModele transfert in lTransferts )
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
    public Boolean isParticipation (FifaModeles.EquipesModele equipe, DateTime date)
        {
            try
            {
                ChampionnatService cs = new ChampionnatService();
                List<FifaModeles.ChampionnatsModele> lChampionnat = cs.ListAll();

                //récupère le bon championnat
                int i = 0;
                FifaModeles.ChampionnatsModele championnat = null;
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

                List<FifaModeles.EquipesParticipationModele> lParticipation = this.ListAll();
                
                //vérifie si il y a une participation de l'équipe avec le championant correspondant à la date
                foreach (FifaModeles.EquipesParticipationModele participation in lParticipation)
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
