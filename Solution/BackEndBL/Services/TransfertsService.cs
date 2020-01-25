using FifaDAL.BackEnd;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.Services
{
    public class TransfertsService : BackEndService
    {
        private int NOMBREMINJOUEUR = 5;

        public List<TransfertsModele> ListAll()
        {
            try
            {
                List<TransfertsModele> lTransferts;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lTransferts = ctx.Transferts.ToList();
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

        public List<TransfertsModele> ListAllWithEquipeJoueurs()
        {
            try
            {
                List<TransfertsModele> lJoueursTransferts;

                // donne la liste des transfert avec entités joueurs et équipes pour lesquels il n'y pas eu de sortie (participation en cours)
                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
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

                Boolean _return = true;

                foreach (DataRowView row in oView)
                {
                    //obtient le joueur
                    JoueursService js = new JoueursService();
                    JoueursModele joueur = js.GetJoueurs(row["Joueur :"].ToString());

                    //obtient l'équipe
                    EquipesService es = new EquipesService();
                    EquipesModele equipeOld = es.getEquipe(row["Equipe :"].ToString());
                    EquipesModele equipeNew = es.getEquipe(row["combo"].ToString());

                    //obtient le nombre de transfert 
                    int nbTransfertsOut = nombreTransfertEquipeOld(oView, equipeOld.nom);
                    //obtient le nombre de joueur avant transfert
                    int nbJoueur = nombreJoueurEquipe(equipeOld.equipeId, (DateTime)row["Date du transfert :"]);

                    //vérifie si le transfert est lors d'une intersaison
                    IntersaisonsService inter = new IntersaisonsService();

                    if (!inter.checkPasDansIntersaison((DateTime)row["Date du transfert :"]))
                    {

                        if ((nbJoueur - nbTransfertsOut) >= NOMBREMINJOUEUR)
                        {
                            return true;
                        }
                        else
                        {
                            // retourne un BusinessError si il n'y aurait plus assez de joueurs
                            BusinessError bErreur = new BusinessError("Il y a trop de transferts de sortie pour l'équipe : " + equipeOld.nom);
                            throw bErreur;
                        }
                    }
                }
                return _return;

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

    }
}
