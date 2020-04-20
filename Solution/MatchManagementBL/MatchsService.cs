using FifaDAL.MatchManagement;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public class MatchsService : MatchManagementService
    {
        public MatchsService()
        {
            this.name = "Matchs";
        }

        public List<MatchsModele> GetListeObject()
        {
            try
            {
                List<MatchsModele> listeMatchs= new List<MatchsModele>();
                return listeMatchs = ConvertDataTable<MatchsModele>(this.loadAllData().ToTable());
            }

            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime getMatchDate(Guid matchId)
        {
            try
            {
                return this.GetListeObject().FirstOrDefault(x => x.matchId == matchId).matchDate;
                                            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MatchsModele> getMatchsEquipe (Guid equipeId, QuartersModele quarter)
        {
            try
            {
                List<MatchsModele> lMatchs = this.GetListeObject()
                                                 .Where(xx => xx.matchDate <= quarter.dateFin)
                                                 .Where(xx => xx.matchDate >= quarter.dateDebut)
                                                 .Where(xx => xx.equipe1Id == equipeId || xx.equipe2Id == equipeId)
                                                 .OrderBy (xx => xx.matchDate)
                                                 .ToList();
                return lMatchs;
            }
            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateIsPlayed (Guid matchId)
        {
            try
            {
                MatchData md = new MatchData(_Connection);
                md.UpdateIsPlayed(matchId);
            }
            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<MatchsModele> getMatchParticipationParUnJoueurParQuarter (Guid joueurId, DateTime dateDebut, DateTime dateFin)
        {
            try
            {
                List<dynamic> ldyn = new List<dynamic>();
                ldyn.Add(dateDebut);
                ldyn.Add(dateFin);
                ldyn.Add(joueurId);
                
                MatchData mData = new MatchData(_Connection);
                DataTable oTable = mData.getMatchUnJoueurUnQuarter(ldyn, "MatchsUnJoueur").Tables["MatchsUnJoueur"];

                List<MatchsModele> listeMatchs = new List<MatchsModele>();
                return listeMatchs = ConvertDataTable<MatchsModele>(oTable);
            }
            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MatchsModele> getMatchParticipationParUneEquipeParQuarter(Guid equipeId, DateTime dateDebut, DateTime dateFin)
        {
            try
            {
                List<dynamic> ldyn = new List<dynamic>();
                ldyn.Add(dateDebut);
                ldyn.Add(dateFin);
                ldyn.Add(equipeId);

                MatchData mData = new MatchData(_Connection);
                DataTable oTable = mData.getMatchUneEquipeUnQuarter(ldyn, "MatchsUneEquipe").Tables["MatchsUneEquipe"];

                List<MatchsModele> listeMatchs = new List<MatchsModele>();
                return listeMatchs = ConvertDataTable<MatchsModele>(oTable); ;
            }
            catch (TechnicalError ce)
            {
                throw ce;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
