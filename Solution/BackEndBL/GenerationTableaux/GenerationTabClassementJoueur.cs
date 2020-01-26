using BackEndBL.Services;
using FifaError;
using FifaModeles;
using FifaModeles.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.GenerationTableaux
{
    public class GenerationTabClassementJoueur
    {
        public DataTable getClassementEquipe(DateTime date)
        {
            try
            {
                //crée la table vide de classement d'équipe
                DataTable oTable = new TableClassementJoueur().getTable();

                //récupère le championnat lié à l'année
                ChampionnatsModele championnat = new ChampionnatService().getChampionnat(date.Year);

                //récupère les joueurs de tout le championnat 
                List<Guid> lId = new TransfertsService().getListeJoueurChampionnat(championnat);
                List<JoueursModele> Ljoueurs = new JoueursService().getListeJoueurs(lId); 
 
                DataRow row;

                foreach (JoueursModele joueur in Ljoueurs)
                {
                    //récupère la liste d'équipe pour laquelle un joueur a joué
                    List<EquipesModele> lEquipe = new TransfertsService().getEquipesDatees(joueur, championnat);

                    //récupère les matchs de l'équipe du 1/1/date.year à date compris
                    List<MatchsModele> matchs = new MatchsService().ListesMatchsListeEquipeDatee(lEquipe, date);

                    //récupère les quarters
                    QuartersModele quarter1 = getQuarter(championnat, 1);
                    QuartersModele quarter2 = getQuarter(championnat, 2);

                    row = oTable.NewRow();

                    //assigne le nom de l'équipe
                    row["Joueur :"] = joueur.prenom + " " + joueur.nom; 

                    //assigne les goals du Q1
                    row["Goals Q1 :"] = getGoals(joueur, matchs, quarter1);

                    //assigne les goals du Q2
                    row["Goals Q2 :"] = getGoals(joueur, matchs, quarter2);

                    //calcule le total de goals
                    row["Goals Totaux"] = (int)row["Goals Q1 :"] + (int)row["Goals Q2 :"];

                    row["Cartes Jaunes Q1 :"] = getCartesJaunes(joueur, matchs, quarter1);

                    row["Cartes Jaunes Q2 :"] = getCartesJaunes(joueur, matchs, quarter2);

                    row["Cartes Jaunes Totales"] = (int)row["Cartes Jaunes Q1 :"] + (int)row["Cartes Jaunes Q2 :"];

                    row["Cartes Rouges Q1 :"] = getCartesRouges(joueur, matchs, quarter1);

                    row["Cartes Rouges Q2 :"] = getCartesRouges(joueur, matchs, quarter2);

                    row["Cartes Rouges Totales"] = (int)row["Cartes Rouges Q1 :"] + (int)row["Cartes Rouges Q2 :"];

                    row["CartonsValeur"] = (int)row["Cartes Jaunes Totales"] + (3 * (int)row["Cartes Rouges Totales"]);

                    oTable.Rows.Add(row);
                }
                oTable.AcceptChanges();
                return oTable;
            }
            catch (TechnicalError oErreur)
            {
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }



        // récupère le nombre de cartons jaunes pour une équipe à un quarter
        public int getCartesJaunes(JoueursModele joueur, List<MatchsModele> lMatchs, QuartersModele quarter)
        {
            List<CartonsJaunesModele> lcj = new CartesJaunesService().ListAll();
            int count = 0;

            foreach (CartonsJaunesModele cj in lcj)
            {
                if (cj.joueurId == joueur.joueurId)
                {
                    foreach (MatchsModele match in lMatchs)
                    {
                        if (match.matchId == cj.matchId && match.matchDate <= quarter.dateFin && match.matchDate >= quarter.dateDebut)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        // récupère le nombre de cartons rouges pour une équipe à un quarter
        public int getCartesRouges(JoueursModele joueur, List<MatchsModele> lMatchs, QuartersModele quarter)
        {
            List<CartonsRougesModele> lcr = new CartesRougesService().ListAll();
            int count = 0;

            foreach (CartonsRougesModele cr in lcr)
            {
                if (cr.joueurId == joueur.joueurId)
                {
                    foreach (MatchsModele match in lMatchs)
                    {
                        if (match.matchId == cr.matchId && match.matchDate <= quarter.dateFin && match.matchDate >= quarter.dateDebut)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }


        // récupère le nombre de goals pour une équipe à un quarter
        public int getGoals(JoueursModele joueur, List<MatchsModele> lMatchs, QuartersModele quarter)
        {
            List<GoalsModele> lGoals = new GoalsService().ListAll();
            int count = 0;

            foreach (GoalsModele goal in lGoals)
            {
                if (goal.joueurId == joueur.joueurId)
                {
                    foreach (MatchsModele match in lMatchs)
                    {
                        if (match.matchId == goal.matchId && match.matchDate <= quarter.dateFin && match.matchDate >= quarter.dateDebut)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        //renvoie un quarter en fonction d'un championnat et d'un numéro de quarter (1 ou 2)
        public QuartersModele getQuarter(ChampionnatsModele championnat, int numeroQuarter)
        {
            try
            {
                List<QuartersModele> lQuarterTrie = new List<QuartersModele>();

                List<QuartersModele> lQuarter = new QuartersService().ListOneChampionnat(championnat);

                if (numeroQuarter == 1)
                {
                    lQuarterTrie = lQuarter.OrderBy(xx => xx.dateDebut).ToList();
                }

                if (numeroQuarter == 2)
                {
                    lQuarterTrie = lQuarter.OrderByDescending(xx => xx.dateDebut).ToList();
                }

                if (numeroQuarter != 1 && numeroQuarter != 2)
                {
                    // retourne un BusinessError si le numero de Quarter n'est pas bon
                    BusinessError bErreur = new BusinessError("Ce numéro de quarter n'est pas correct");
                    throw bErreur;
                }

                return lQuarterTrie[0];
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
