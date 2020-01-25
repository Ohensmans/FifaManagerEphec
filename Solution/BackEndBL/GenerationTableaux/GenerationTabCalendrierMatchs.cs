﻿using BackEndBL.Services;
using FifaError;
using FifaModeles;
using FifaModeles.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.GenerationTableaux
{
    public class GenerationTabCalendrierMatchs
    {
        public DataTable generationCalendrier(int annee, List<string> lNomEquipe)
        {
            try
            {
                List<MatchsModele> lMatchsQ1Tries = GetMatchsQuarterTries(annee, lNomEquipe, 1);
                List<MatchsModele> lMatchsQ2Tries = GetMatchsQuarterTries(annee, lNomEquipe, 2);

                //crée une liste consolidée pour la saison
                List<MatchsModele> lMatchsSaisonTrie = lMatchsQ1Tries;
                foreach (MatchsModele match in lMatchsQ2Tries)
                {
                    lMatchsSaisonTrie.Add(match);
                }

                DataTable oTable = new TableCalendrierMatch().getTable();
                DataRow row;

                int i = 0;

                foreach (MatchsModele match in lMatchsSaisonTrie)
                {
                    row = oTable.NewRow();

                    //numérote le match
                    i++;
                    row["Match n° :"] = i;

                    //trouve le nom de l'équipe A
                    row["Equipe à Domicile :"] = getNomEquipes(match.equipe1Id);

                    //trouve le nom de l'équipe B
                    row["Equipe à l'extérieur :"] = getNomEquipes(match.equipe2Id);

                    //inscrit la date
                    row["Date du Match :"] = match.matchDate;

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


        public string getNomEquipes(Guid equipeId)
        {
            try
            {
                EquipesService es = new EquipesService();
                List<EquipesModele> lEquipe = es.ListAll();
                int i = 0;

                while (lEquipe[i].equipeId!=equipeId&&i<lEquipe.Count)
                {
                    i++;
                }

                return lEquipe[i].nom;

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



        public List<MatchsModele> GetMatchsQuarterTries(int annee, List<string> lNomEquipe, int numeroQuarter)
        {
            try
            {
                //crée la liste des matchs pour tout le championnat
                List<MatchsModele> lMatchsSaison = getListeMatchSaison(lNomEquipe);

                //crée les listes des matchs pour chaque quarter
                List<MatchsModele> lMatchQNonTrie = getListeMatchQuarter(lMatchsSaison, numeroQuarter);

                //obtient les listes des weeks ends pour les 2 quarters
                List<DateTime> lWeekEndQ = getListeDateWeekEnds(annee, numeroQuarter);

                //obtient le nombre de match par week end
                int nombreMatchParWeekEnd = lMatchQNonTrie.Count / 2;

                //obtient le nombre de match par jour 
                int nombreMatchParJour = nombreMatchParWeekEnd / 2;

                //obtient le supplément si nombre de match par week end impaire
                int addition = lMatchQNonTrie.Count % 2;

                List<MatchsModele> lMatchQTries = new List<MatchsModele>();

                int i = 0;
                int k = 0;

                // continue la boucle tant que la liste de date ou de match n'est pas terminée
                while (i < lWeekEndQ.Count && k < lMatchQNonTrie.Count)
                {
                    int nombreMatchEffectif = nombreMatchParJour;

                    //rajoute l'addition si nécessaire
                    if (i % 2 == 0)
                    {
                        nombreMatchEffectif += addition;
                    }

                    for (int j = 0; j < nombreMatchEffectif; j++)
                    {
                        if (k < lMatchQNonTrie.Count)
                        {
                            //teste si une équipe joue déjà le même jour
                            if (!lMatchQTries.Any(xx => xx.matchDate == lWeekEndQ[i] && (xx.equipe1Id == lMatchQNonTrie[k].equipe1Id || xx.equipe2Id == lMatchQNonTrie[k].equipe2Id 
                                                                                            || xx.equipe1Id == lMatchQNonTrie[k].equipe2Id || xx.equipe2Id == lMatchQNonTrie[k].equipe1Id)))
                            {
                                //teste si une équipe joue déjà la veille
                                if (!lMatchQTries.Any(xx => xx.matchDate == lWeekEndQ[i].AddDays(-1) && (xx.equipe1Id == lMatchQNonTrie[k].equipe1Id || xx.equipe2Id == lMatchQNonTrie[k].equipe2Id 
                                                                                                        || xx.equipe1Id == lMatchQNonTrie[k].equipe2Id || xx.equipe2Id == lMatchQNonTrie[k].equipe1Id)))
                                {
                                    //ajoute la date et rajoute le match à la liste définitive
                                    MatchsModele match = lMatchQNonTrie[k];
                                    match.matchDate = lWeekEndQ[i];
                                    lMatchQTries.Add(match);
                                    k++;
                                }
                            }
                        }

                    }
                    i++;
                }

                //vérifie que tous les matchs soient bien dans la liste définitive
                int difference = lMatchQNonTrie.Count - lMatchQTries.Count;

                if (difference != 0)
                {
                    for (int m = lMatchQNonTrie.Count - difference; m < lMatchQNonTrie.Count; m++)
                    {
                        MatchsModele match = lMatchQNonTrie[m];
                        //assigne une date en fonction du quarter
                        match.matchDate = new DateTime((numeroQuarter+1800), 1, 1);
                        lMatchQTries.Add(lMatchQNonTrie[m]);
                    }
                }

                return lMatchQTries;
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


        // crée la liste complète des matchs de la saison (A-B;A-C;B-A;B-C;C-A;C-B)
        public List<MatchsModele> getListeMatchSaison(List<string> lNomEquipe)
        {
            try
            {
                List<EquipesModele> lEquipe = new List<EquipesModele>();

                EquipesService es = new EquipesService();
                lEquipe = es.ListeEquipeParticipants(lNomEquipe);

                List<MatchsModele> lMatchs = new List<MatchsModele>();

                foreach (EquipesModele oEquipe in lEquipe)
                {
                    for (int i = 0; i < lEquipe.Count; i++)
                    {
                        if (oEquipe.nom != lEquipe[i].nom)
                        {
                            MatchsModele match = new MatchsModele(oEquipe.equipeId, lEquipe[i].equipeId);
                            lMatchs.Add(match);
                        }
                    }
                }
                return lMatchs;
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


        //Divise de manière égale les matchs entre le Q1 et Q2
        public List<MatchsModele> getListeMatchQuarter(List<MatchsModele> lMatchs, int numeroQuarter)
        {
            List<MatchsModele> lMatchsQuarter = new List<MatchsModele>();

            for (int i = numeroQuarter % 2; i < lMatchs.Count; i += 2)
            {
                lMatchsQuarter.Add(lMatchs[i]);
            }
            return lMatchsQuarter;
        }

        public List<DateTime> getListeDateWeekEnds(int annee, int numeroQuarter)
        {
            try
            {
                List<DateTime> lDateWeekend = new List<DateTime>();
                //obtient le quarter demandé
                QuartersModele quarter = getQuarters(annee, numeroQuarter);

                DateTime date = quarter.dateDebut;

                //vérifie si la date est un samedi ou un dimanche si oui l'ajoute à la liste et après rajoute un jour à la date
                while (date <= quarter.dateFin)
                {
                    if (Convert.ToInt32(date.DayOfWeek) == 0 || Convert.ToInt32(date.DayOfWeek) == 6)
                    {
                        lDateWeekend.Add(date);
                    }
                    date = date.AddDays(1);
                }
                return lDateWeekend;
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
    

        public QuartersModele getQuarters (int annee, int numeroQuarter)
        {
            try
            {
                List<QuartersModele> lQuarters = new List<QuartersModele>();

                QuartersService qs = new QuartersService();

                QuartersModele quarter1;
                QuartersModele quarter2;

                List<QuartersModele> lAllQuarters = qs.ListAll();

                foreach (QuartersModele oQuarter in lAllQuarters)
                {
                    if (oQuarter.dateDebut.Year == annee)
                    {
                        lQuarters.Add(oQuarter);
                    }
                }

                //trie les quarters selon leur ordre temporel
                if (lQuarters[0].dateDebut < lQuarters[1].dateDebut)
                {
                    quarter1 = lQuarters[0];
                    quarter2 = lQuarters[1];
                }
                else
                {
                    quarter1 = lQuarters[1];
                    quarter2 = lQuarters[0];
                }

                //retourne le quarter demandé
                if (numeroQuarter==1)
                {
                    return quarter1;
                }
                else
                {
                    return quarter2;
                }

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
    }
}
