using FifaDAL.BackEndDBF;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BackEndBL.Services
{
    public class TransfertsService : BackEndService
    {
        private int NOMBREMINJOUEUR = 5;
        private int NOMBREMAXJOUEUR = 10;

        public List<TransfertsModele> ListAll()
        {
            try
            {
                List<TransfertsModele> lTransferts = new List<TransfertsModele>() ;

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (dynamic dyn in ctx.Transferts_GetAll())
                    {
                        TransfertsModele transfert = new TransfertsModele();
                        transfert = dyn;
                        lTransferts.Add(transfert);
                    }
                }
                return lTransferts;
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

        public List<EquipesModele> getEquipesDatees (JoueursModele joueur, ChampionnatsModele championnat)
        {
            List<EquipesModele> lEquipe = new List<EquipesModele>();
            List<EquipesModele> lEquipeAll = new EquipesService().ListAll();

            foreach (TransfertsModele transfert in this.ListAll())
            {
                if (transfert.joueurId == joueur.joueurId && transfert.dateDebut.Year <= championnat.annee && (!transfert.dateFin.HasValue || transfert.dateFin.Value.Year>=championnat.annee))
                {
                    int i = 0;
                    while (i < lEquipeAll.Count&& lEquipeAll[i].equipeId != transfert.equipeId)
                    {
                        i++;
                    }
                    lEquipe.Add(lEquipeAll[i]);
                }
            }
            return lEquipe;
        }

        // renvoie la liste de tous les guid de joueurs participants à un championnat
        public List<Guid> getListeJoueurChampionnat(ChampionnatsModele championnat)
        {
            try
            {
                List<EquipesParticipationModele> LEquipeParticipation = new EquipesParticipationService().ListeEquipeChampionnat(championnat);

                List<Guid> lJoueurs = new List<Guid>();

                List<TransfertsModele> lAllTransferts = this.ListAll();

                foreach (TransfertsModele transfert in lAllTransferts)
                {
                    if (transfert.dateDebut.Year <= championnat.annee && (!transfert.dateFin.HasValue || transfert.dateFin.Value.Year >= championnat.annee))
                    {                       
                        int i = 0;
                        while (i < LEquipeParticipation.Count && LEquipeParticipation[i].equipeId != transfert.equipeId)
                        {
                            i++;
                        }
                        if (!lJoueurs.Contains(transfert.joueurId))
                        {
                            lJoueurs.Add(transfert.joueurId);
                        }
                    }

                }
                return lJoueurs;
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

        public List<TransfertsModele> ListAllWithEquipeJoueurs()
        {
            try
            {
                List<TransfertsModele> lJoueursTransferts;

                // donne la liste des transfert avec entités joueurs et équipes pour lesquels il n'y pas eu de sortie (participation en cours)
                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    lJoueursTransferts = ctx.Transferts.Include("Equipes")
                                                       .Include("Joueurs")
                                                       .Where(xx => xx.dateFin.HasValue == false)
                                                       .ToList();
                }
                return lJoueursTransferts;
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

        // vérifie si la date n'est pas dans un quarter ou si le joueur n'est pas déjà inscrit dans une feuille de match postérieure
        public Boolean checkDateTransfert(string nomCompletJoueur, DateTime date)
        {
            try
            {
                //récupère l'objet qui correspond au joueur
                JoueursService js = new JoueursService();
                JoueursModele joueur = js.GetJoueurs(nomCompletJoueur);

                //vérifie si le joueur n'a pas joué un match à une date postérieure à celle du transfert
                JoueursParticipationService jps = new JoueursParticipationService();
                if (jps.checkJoueurSiPasParticipation(joueur.joueurId, date))
                {
                    //vérifie si la date n'est pas dans un quarter
                    QuartersService qs = new QuartersService();
                    if (qs.checkPasDansQuarter(date))
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean checkTransferts (DataTable oTable)
        {
            try
            {
                //transforme la table en vue et applique un filtre pour n'avoir que les lignes modifiées
                DataView oView = oTable.DefaultView;
                oView.RowStateFilter = DataViewRowState.ModifiedCurrent;

                if (checkTableTransfert(oView))
                {
                    foreach (DataRowView row in oView)
                    {

                        //obtient le joueur
                        JoueursService js = new JoueursService();
                        JoueursModele joueur = js.GetJoueurs(row["Joueur :"].ToString());

                        
                        EquipesService es = new EquipesService();

                        //obtient l'équipe et le nombre de joueur avant transfert et le nombre de transfert pour l'équipeNew
                        EquipesModele equipeNew = es.getEquipe(row["combo"].ToString());
                        //obtient le nombre de transfert 
                        int nbTransfertsIn = nombreTransfertEquipeNew(oView, equipeNew.nom);
                        //obtient le nombre de joueur avant transfert
                        int nbJoueurNew = nombreJoueurEquipe(equipeNew.equipeId, (DateTime)row["Date du transfert :"]);

                        //obtient l'équipe et le nombre de joueur avant transfert et le nombre de transfert pour l'équipeOld si elle existe
                        int nbTransfertsOut = 0;
                        int nbJoueur = NOMBREMINJOUEUR;
                        if (row["Equipe :"].ToString() != "")
                        {
                            EquipesModele equipeOld = es.getEquipe(row["Equipe :"].ToString());

                            //obtient le nombre de transfert 
                            nbTransfertsOut = nombreTransfertEquipeOld(oView, equipeOld.nom);
                            //obtient le nombre de joueur avant transfert
                            nbJoueur = nombreJoueurEquipe(equipeOld.equipeId, (DateTime)row["Date du transfert :"]);
                        }

                        //vérifie si le transfert est lors d'une intersaison
                        IntersaisonsService inter = new IntersaisonsService();


                        if ((nbJoueurNew + nbTransfertsIn) <= NOMBREMAXJOUEUR)
                        {
                            if ((nbJoueur - nbTransfertsOut) >= NOMBREMINJOUEUR)
                            {
                                //vérifie si l'équipe d'arrivée est bien les x derniers du championnat à la date xx 
                                //si l'équipe d'arrivée n'est pas inscrite dans le championnat renvoie également true
                                //sinon renvoie une Business erreur

                                if (!inter.checkPasDansIntersaison((DateTime)row["Date du transfert :"]))
                                {

                                    ClassementEquipe classement = new ClassementEquipe();
                                    if (classement.isLastThree(equipeNew, (DateTime)row["Date du transfert :"]))
                                    {
                                    }
                                }
                            }
                            else
                            {
                                // retourne un BusinessError si il n'y aurait plus assez de joueurs
                                BusinessError bErreur = new BusinessError("Il y a trop de transferts de sortie pour l'équipe de départ");
                                throw bErreur;
                            }
                        }
                        else
                        {
                            // retourne un BusinessError si il n'y aurait plus assez de joueurs
                            BusinessError bErreur = new BusinessError("Il y a trop de transferts d'entrée pour l'équipe d'arrivée");
                            throw bErreur;
                        }
                        
                    }
                    return true;
                }
                else
                {
                    // retourne un BusinessError si il n'y aurait plus assez de joueurs
                    BusinessError bErreur = new BusinessError("Toutes les cellules de date de transfert et d'équipes d'arrivée ne sont pas remplies");
                    throw bErreur;
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

        //obtient le nombre de joueurs qui partent de l'équipe
        public int nombreTransfertEquipeOld (DataView oView, string nomEquipe)
        {
            int count = 0;
            foreach (DataRowView row in oView)
            {
                if (row["Equipe :"].ToString().Equals(nomEquipe))
                {
                    count++;
                }
            }
            return count;
        }

        public int nombreTransfertEquipeNew(DataView oView, string nomEquipe)
        {
            int count = 0;
            foreach (DataRowView row in oView)
            {
                if (row["combo"].ToString().Equals(nomEquipe))
                {
                    count++;
                }
            }
            return count;
        }

        public int nombreJoueurEquipe(Guid equipeId, DateTime date)
        {
            int count = 0;

            try
            {
                List<TransfertsModele> lTransferts = this.ListAll();

                foreach (TransfertsModele transfert in lTransferts)
                {
                    if (transfert.equipeId == equipeId && (transfert.dateDebut<=date)&&((transfert.dateFin == null)||(transfert.dateFin<=date)))
                    {
                        count++;
                    }
                }

                return count;
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

        //vérifie que les cellules nécessaires (date transfert et équipe arrivée) soient bien remplies
        public Boolean checkTableTransfert(DataView oView)
        {
            foreach (DataRowView row in oView)
            {
                if (row["Date du transfert :"].ToString() == "" || row["combo"].ToString() == "")
                {
                    return false;
                }
            }
            return true;
        }

        public void enregistrerTransferts(DataTable oTable)
        {
            try
            {
                if (checkTransferts(oTable))
                {
                    using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                    {
                        //transforme la table en vue et applique un filtre pour n'avoir que les lignes modifiées
                        DataView oView = oTable.DefaultView;
                        oView.RowStateFilter = DataViewRowState.ModifiedCurrent;


                        foreach (DataRowView row in oView)
                        {
                            //récupère l'id du joueur
                            Guid joueurId = new JoueursService().GetJoueurs(row["Joueur :"].ToString()).joueurId;
                            DateTime dateTransfert = (DateTime)row["Date du transfert :"];
                            Guid equipeInId = new EquipesService().getEquipe(row["combo"].ToString()).equipeId;

                            if (row["Date arrivee :"].ToString() != "")
                            {
                                //récupère l'ancien transfert et le modifie
                                DateTime dateArrivee = (DateTime)row["Date arrivee :"];
                                TransfertsModele transfertOld = ctx.Transferts.Where(xx => xx.joueurId == joueurId)
                                                                           .Where(yy => yy.dateDebut == dateArrivee)
                                                                           .FirstOrDefault();
                                if (transfertOld != null)
                                {
                                    transfertOld.dateFin = dateTransfert;
                                    transfertOld.lastUpdate = DateTime.Now;
                                }

                                dateTransfert = dateTransfert.AddDays(1);
                            }

                            ctx.Tansferts_Add(joueurId, equipeInId, dateTransfert, DateTime.Now);                      
                        }
                        using (TransactionScope scope = new TransactionScope())
                        {
                            ctx.SaveChanges();
                            scope.Complete();
                        }
                    }

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
}
