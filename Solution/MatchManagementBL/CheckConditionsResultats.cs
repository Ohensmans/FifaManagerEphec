using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public static class CheckConditionsResultats
    {
        public static int NBMINJOUEUR = 5;

        //vérifie si il y a un transfert après le match si et seulement si le match est avant l'intersaison (le classement n'intervient que dans la condition de transfert en intersaison)
        public static bool checkTransfertApres(Guid matchId)
        {
            try
            {

                MatchsService match = new MatchsService();
                DateTime dateMatch = match.getMatchDate(matchId);

                IntersaisonsService inter = new IntersaisonsService();
                DateTime dateDebutIntersaison = inter.GetDateDebut(dateMatch.Year);
                DateTime dateFinIntersaison = inter.GetDateFin(dateMatch.Year);

                if (dateDebutIntersaison > dateMatch)
                {
                    ChampionnatsService cs = new ChampionnatsService();
                    Guid championnatId = cs.GetListeObject().FirstOrDefault(x => x.annee == dateMatch.Year).championnatId;

                    EquipesParticipationsService eps = new EquipesParticipationsService();
                    List<EquipesModele> lEquipe = eps.getEquipesParticipantes(championnatId);

                    TransfertsHistoryService ths = new TransfertsHistoryService();
                    List<TransfertsModele> lTransferts = ths.GetListeObject().Where(x => (x.dateDebut >= dateDebutIntersaison 
                                                                                        && x.dateDebut <= dateFinIntersaison)
                                                                                        || (x.dateFin >= dateDebutIntersaison
                                                                                        && x.dateFin <= dateFinIntersaison))
                                                                             .ToList();

                    foreach (TransfertsModele transfert in lTransferts)
                    {
                        if (lEquipe.Any(x => x.equipeId == transfert.equipeId))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckFeuilleApres(Guid equipeAId, Guid equipeBId, Guid matchId)
        {
            try
            {
                MatchsService match = new MatchsService();
                DateTime dateMatch = match.getMatchDate(matchId);

                MatchsService ms = new MatchsService();
                List<MatchsModele> lMatchs = ms.GetListeObject().Where(x => x.matchDate.Year == dateMatch.Year
                                                                        && x.matchDate > dateMatch
                                                                        && (x.equipe1Id == equipeAId
                                                                        || x.equipe1Id == equipeBId
                                                                        || x.equipe2Id == equipeAId
                                                                        || x.equipe2Id == equipeBId))
                                                                        .ToList();
                FeuillesMatchService fms = new FeuillesMatchService();
                List<FeuillesDeMatchModele> lFeuilleMatch = fms.GetListeObject();

                foreach (FeuillesDeMatchModele feuille in lFeuilleMatch)
                {
                    if (lMatchs.Any(x => x.matchId == feuille.matchId))
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

        public static bool CheckNombreJoueurFeuillePasAssez(Guid equipeAId, Guid equipeBId, Guid matchId)
        {
            try
            {
                FeuillesMatchService fms = new FeuillesMatchService();
                JoueursParticipationService jps = new JoueursParticipationService();

                if (fms.FeuilleExiste(matchId))
                {
                    int countJoueurEquipeA = jps.getCountJoueur(fms.GetFeuille(matchId, equipeAId).feuilleId);
                    int countJoueurEquipeB = jps.getCountJoueur(fms.GetFeuille(matchId, equipeBId).feuilleId);

                    if (countJoueurEquipeA >= NBMINJOUEUR && countJoueurEquipeB >= NBMINJOUEUR)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}
