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

        public List<FifaModeles.TransfertsModele> ListAll()
        {
            try
            {
                List<FifaModeles.TransfertsModele> lTransferts = new List<FifaModeles.TransfertsModele>() ;

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (Transferts_GetAll_Result oTrans in ctx.Transferts_GetAll())
                    {
                        FifaModeles.TransfertsModele transfert = new FifaModeles.TransfertsModele();
                        transfert.joueurId = oTrans.joueurId;
                        transfert.equipeId = oTrans.equipeId;
                        transfert.dateDebut = oTrans.dateDebut;
                        transfert.dateFin = oTrans.dateFin;
                        transfert.lastUpdate = oTrans.lastUpdate;
                        lTransferts.Add(transfert);
                    }
                }
                return lTransferts;
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

        public List<FifaModeles.EquipesModele> getEquipesDatees (FifaModeles.JoueursModele joueur, FifaModeles.ChampionnatsModele championnat)
        {
            List<FifaModeles.EquipesModele> lEquipe = new List<FifaModeles.EquipesModele>();
            List<FifaModeles.EquipesModele> lEquipeAll = new EquipesService().ListAll();

            foreach (FifaModeles.TransfertsModele transfert in this.ListAll())
            {
                if (transfert.joueurId == joueur.joueurId && transfert.dateDebut.Year <= championnat.annee && (!transfert.dateFin.HasValue || transfert.dateFin.Value.Year>= championnat.annee))
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
        public List<Guid> getListeJoueurChampionnat(FifaModeles.ChampionnatsModele championnat)
        {
            try
            {
                List<FifaModeles.EquipesParticipationModele> LEquipeParticipation = new EquipesParticipationService().ListeEquipeChampionnat(championnat);

                List<Guid> lJoueurs = new List<Guid>();

                List<FifaModeles.TransfertsModele> lAllTransferts = this.ListAll();

                foreach (FifaModeles.TransfertsModele transfert in lAllTransferts)
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
        
        public List<FifaModeles.TransfertsModele> ListAllWithEquipeJoueurs()
        {
            try
            {
                List<FifaModeles.TransfertsModele> lJoueursTransferts;

                // donne la liste des transfert avec entités joueurs et équipes pour lesquels il n'y pas eu de sortie (participation en cours)
                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    /*
                    lJoueursTransferts = ctx.Transferts.Include("Equipes")
                                                       .Include("Joueurs")
                                                       .Where(xx => xx.dateFin.HasValue == false)
                                                       .ToList();
                                                       */
                    lJoueursTransferts = this.ListAll().Where(xx => xx.dateFin.HasValue == false).ToList();
                                                                           
                }
                return lJoueursTransferts;
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

        // vérifie si la date n'est pas dans un quarter ou si le joueur n'est pas déjà inscrit dans une feuille de match postérieure
        public Boolean checkDateTransfert(string nomCompletJoueur, DateTime date)
        {
            try
            {
                //récupère l'objet qui correspond au joueur
                JoueursService js = new JoueursService();
                FifaModeles.JoueursModele joueur = js.GetJoueurs(nomCompletJoueur);

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

        public Boolean checkMatchEstApresChampionnat(DateTime dateTransfert)
        {
            try
            {
                MatchsService ms = new MatchsService();
                List<MatchsModele> lMatchs = ms.ListAll();

                if (lMatchs.Any(x => x.matchDate.Year == dateTransfert.Year
                                && x.matchDate>dateTransfert))
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public Boolean checkMatchsAllPlayedBefore (DateTime dateTransfert, EquipesModele equipeNew, EquipesModele equipeOld)
        {
            try
            {
                MatchsService ms = new MatchsService();
                List<MatchsModele> lMatchs = ms.ListAll();
                DateTime debutChampionnat = new DateTime(dateTransfert.Year, 1, 1);

                if (equipeNew != null)
                {
                    if (lMatchs.Any(x => x.isPlayed == false
                    && (x.equipe1Id == equipeNew.equipeId
                    || x.equipe2Id == equipeNew.equipeId)
                    && x.matchDate < dateTransfert
                    && x.matchDate >= debutChampionnat))
                    {
                        return false;
                    }
                }

                if (equipeOld != null)
                {
                    if (lMatchs.Any(x => x.isPlayed == false
                                        && (x.equipe1Id == equipeOld.equipeId
                                        || x.equipe2Id == equipeOld.equipeId)
                                        && x.matchDate < dateTransfert
                                        && x.matchDate >= debutChampionnat))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean checkNoMatchswithFeuilleAfter(DateTime dateTransfert, EquipesModele equipeNew, EquipesModele equipeOld)
        {
            try
            {
                FeuillesDeMatchService fms = new FeuillesDeMatchService();
                List<FeuillesDeMatchModele> lFeuilleMatch = fms.ListAll();

                if (equipeNew != null)
                {
                    if (lFeuilleMatch.Any(x => x.Matchs.matchDate > dateTransfert
                    && (x.Matchs.equipe1Id == equipeNew.equipeId
                    || x.Matchs.equipe2Id == equipeNew.equipeId)))
                   
                    {
                        return false;
                    }
                }

                if (equipeOld != null)
                {
                    if (lFeuilleMatch.Any(x => x.Matchs.matchDate > dateTransfert
                    && (x.Matchs.equipe1Id == equipeOld.equipeId
                    || x.Matchs.equipe2Id == equipeOld.equipeId)))
                    {
                        return false;
                    }
                }
                return true;
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
                        FifaModeles.JoueursModele joueur = js.GetJoueurs(row["Joueur :"].ToString());


                        EquipesService es = new EquipesService();

                        //obtient l'équipe et le nombre de joueur avant transfert et le nombre de transfert pour l'équipeNew si elle existe
                        int nbTransfertsIn = 0;
                        int nbJoueurNew = NOMBREMINJOUEUR;
                        EquipesModele equipeNew = new EquipesModele();
                        EquipesModele equipeOld = new EquipesModele();

                        if (row["combo"].ToString() != "")
                        {
                            //obtient l'équipe et le nombre de joueur avant transfert et le nombre de transfert pour l'équipeNew
                            equipeNew = es.getEquipe(row["combo"].ToString());
                            //obtient le nombre de transfert 
                            nbTransfertsIn = nombreTransfertEquipeNew(oView, equipeNew.nom);
                            //obtient le nombre de joueur avant transfert
                            nbJoueurNew = nombreJoueurEquipe(equipeNew.equipeId, (DateTime)row["Date du transfert :"]);
                        }

                        //obtient l'équipe et le nombre de joueur avant transfert et le nombre de transfert pour l'équipeOld si elle existe
                        int nbTransfertsOut = 0;
                        int nbJoueur = NOMBREMINJOUEUR;
                        if (row["Equipe :"].ToString() != "")
                        {
                            equipeOld = es.getEquipe(row["Equipe :"].ToString());

                            //obtient le nombre de transfert 
                            nbTransfertsOut = nombreTransfertEquipeOld(oView, equipeOld.nom);
                            //obtient le nombre de joueur avant transfert
                            nbJoueur = nombreJoueurEquipe(equipeOld.equipeId, (DateTime)row["Date du transfert :"]);
                        }


                        IntersaisonsService inter = new IntersaisonsService();

                        //vérifie si tous les matchs antérieurs sont jouées
                        if (checkMatchsAllPlayedBefore((DateTime)row["Date du transfert :"], equipeNew, equipeOld))
                        {
                            if (checkNoMatchswithFeuilleAfter((DateTime)row["Date du transfert :"], equipeNew, equipeOld))
                            {
                                if ((nbJoueurNew + nbTransfertsIn) <= NOMBREMAXJOUEUR)
                                {

                                    //vérifie si l'équipe d'arrivée est bien les x derniers du championnat à la date xx 
                                    //si l'équipe d'arrivée n'est pas inscrite dans le championnat renvoie également true
                                    //sinon renvoie une Business erreur

                                    if (!inter.checkPasDansIntersaison((DateTime)row["Date du transfert :"]))
                                    {
                                        if ((nbJoueur - nbTransfertsOut) >= NOMBREMINJOUEUR)
                                        {
                                            if (equipeNew != null)
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


                                }
                                else
                                {
                                    // retourne un BusinessError si il y aurait trop de joueurs
                                    BusinessError bErreur = new BusinessError("Il y a trop de transferts d'entrée pour l'équipe d'arrivée");
                                    throw bErreur;
                                }
                            }
                            else
                            {
                                // retourne un BusinessError si il y a des matchs joués postérieurs
                                BusinessError bErreur = new BusinessError("Une des équipes a déjà rempli une feuille de match après la date de transfert");
                                throw bErreur;
                            }
                        }
                        else
                        {
                            // retourne un BusinessError si il y a des matchs antérieurs non joués
                            BusinessError bErreur = new BusinessError("Tous les matchs antérieurs (de la saison) des équipes sélectionnées doivent être joués");
                            throw bErreur;
                        }

                    }

                    
                }
                else
                {
                    // retourne un BusinessError si il n'y aurait plus assez de joueurs
                    BusinessError bErreur = new BusinessError("Toutes les cellules de date de transfert ne sont pas remplies");
                    throw bErreur;
                }
                
                return true;

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
                List<FifaModeles.TransfertsModele> lTransferts = this.ListAll();

                foreach (FifaModeles.TransfertsModele transfert in lTransferts)
                {
                    if (transfert.equipeId == equipeId && (transfert.dateDebut <= date) &&((transfert.dateFin == null)||(transfert.dateFin >= date)))
                    {
                        count++;
                    }
                }

                return count;
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

        //vérifie que les cellules nécessaires (équipe arrivée) soient bien remplies
        public Boolean checkTableTransfert(DataView oView)
        {
            foreach (DataRowView row in oView)
            {
                if (row["Date du transfert :"].ToString() == "")
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

                            //mets fin au précedent transfert si il existe et rajoute un jour à la date du transfert
                            if (row["Date arrivee :"].ToString() != ""&& row["Equipe :"].ToString()!="")
                            {
                                ctx.Transferts_UpdateDateFin(joueurId, (DateTime)row["Date arrivee :"], dateTransfert, DateTime.Now);

                                dateTransfert = dateTransfert.AddDays(1);
                            }

                            //crée un nouveau transfert
                            if (row["combo"].ToString() != "")
                            {
                                Guid equipeInId = new EquipesService().getEquipe(row["combo"].ToString()).equipeId;
                                ctx.Tansferts_Add(joueurId, equipeInId, dateTransfert, DateTime.Now);
                            }

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

    }
}
