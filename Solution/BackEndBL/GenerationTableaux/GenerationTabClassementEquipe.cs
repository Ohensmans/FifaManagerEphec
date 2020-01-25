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
    public class GenerationTabClassementEquipe
    {
        public DataTable getClassementEquipe(int annee)
        {
            try
            {
                //crée la table vide de classement d'équipe
                DataTable oTable = new TableClassementEquipe().getTable();

                //récupère le championnat lié à l'année
                ChampionnatsModele championnat = new ChampionnatService().getChampionnat(annee);

                //récupère les participations aux championnat 
                List<EquipesParticipationModele> lEquipePart = new EquipesParticipationService().ListeEquipeChampionnat(championnat);

                DataRow row;

                foreach (EquipesParticipationModele participation in lEquipePart)
                {
                    //récupère l'objet équipe en fonction de la participation
                    EquipesModele equipe = new EquipesService().getEquipe(participation.equipeId);

                    //récupère les matchs de l'équipe pour le championnat en question
                    List<MatchsModele> matchs = new MatchsService().ListesOneEquipeOneChamp(equipe, championnat);

                    //récupère les quarters
                    QuartersModele quarter1 = getQuarter(championnat, 1);
                    QuartersModele quarter2 = getQuarter(championnat, 2);

                    row = oTable.NewRow();

                    //assigne le nom de l'équipe
                    row["Equipe :"] = equipe.nom;

                    //assigne les points du Q1
                    row["Points Q1 :"] = getPoints(equipe, matchs, quarter1);

                    //assigne les points du Q2
                    row["Points Q2 :"] = getPoints(equipe, matchs, quarter2);

                    //calcule le total de points
                    row["Points Totaux"] = (int)row["Points Q1 :"] + (int)row["Points Q2 :"];

                    //assigne les goals du Q1
                    row["Goals Q1 :"] = getGoals(equipe, matchs, quarter1);

                    //assigne les goals du Q2
                    row["Goals Q2 :"] = getGoals(equipe, matchs, quarter2);

                    //calcule le total de goals
                    row["Goals Totaux"] = (int)row["Goals Q1 :"] + (int)row["Goals Q2 :"];

                    row["Cartes Jaunes Q1 :"] = getCartesJaunes(equipe, matchs, quarter1);

                    row["Cartes Jaunes Q2 :"] = getCartesJaunes(equipe, matchs, quarter2);

                    row["Cartes Jaunes Totales"] = (int)row["Cartes Jaunes Q1 :"] + (int)row["Cartes Jaunes Q2 :"];

                    row["Cartes Rouges Q1 :"] = getCartesRouges(equipe, matchs, quarter1);

                    row["Cartes Rouges Q2 :"] = getCartesRouges(equipe, matchs, quarter2);

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


        // récupère le nombre de points pour une équipe à un quarter
        public int getPoints(EquipesModele equipe, List<MatchsModele> lMatchs, QuartersModele quarter)
        {
            int count = 0;

            foreach (MatchsModele match in lMatchs)
            {
                if (match.equipe1Id == equipe.equipeId && match.matchDate <= quarter.dateFin && match.matchDate >= quarter.dateDebut)
                {
                    count += match.equipe1Points;
                }

                if (match.equipe2Id == equipe.equipeId && match.matchDate <= quarter.dateFin && match.matchDate >= quarter.dateDebut)
                {
                    count += match.equipe2Points;
                }
            }
            return count;
        }

        // récupère le nombre de cartons jaunes pour une équipe à un quarter
        public int getCartesJaunes(EquipesModele equipe, List<MatchsModele> lMatchs, QuartersModele quarter)
        {
            List<CartonsJaunesModele> lcj = new CartesJaunesService().ListAll();
            int count = 0;

            foreach (CartonsJaunesModele cj in lcj)
            {
                if (cj.equipeId == equipe.equipeId)
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
        public int getCartesRouges(EquipesModele equipe, List<MatchsModele> lMatchs, QuartersModele quarter)
        {
            List<CartonsRougesModele> lcr = new CartesRougesService().ListAll();
            int count = 0;

            foreach (CartonsRougesModele cr in lcr)
            {
                if (cr.equipeId == equipe.equipeId)
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
        public int getGoals (EquipesModele equipe, List<MatchsModele> lMatchs, QuartersModele quarter)
        {
            List<GoalsModele> lGoals = new GoalsService().ListAll();
            int count = 0;

            foreach (GoalsModele goal in lGoals)
            {
                if (goal.equipeId == equipe.equipeId)
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
        public QuartersModele getQuarter (ChampionnatsModele championnat, int numeroQuarter)
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
