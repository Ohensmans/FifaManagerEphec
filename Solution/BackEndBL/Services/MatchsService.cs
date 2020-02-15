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
    public class MatchsService : BackEndService
    {
        public List<FifaModeles.MatchsModele> ListAll()
        {
            List<FifaModeles.MatchsModele> lMatchs = new List<FifaModeles.MatchsModele>();

            using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
            {
                try
                {
                    foreach (Matchs_GetAll_Result oMatch in ctx.Matchs_GetAll())
                    {
                        FifaModeles.MatchsModele match = new FifaModeles.MatchsModele();
                        match.matchId = oMatch.matchId;
                        match.matchDate = oMatch.matchDate;
                        match.equipe1Id = oMatch.equipe1Id;
                        match.equipe2Id = oMatch.equipe2Id;
                        match.equipe1Points = oMatch.equipe1Points;
                        match.equipe2Points = oMatch.equipe2Points;
                        match.isPlayed = oMatch.isPlayed;
                        match.lastUpdate = oMatch.lastUpdate;
                        lMatchs.Add(match);
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
            return lMatchs;
        }

        //renvoie la liste des matchs d'une équipe du 1er janvier année de la date à la date comprise
        public List<FifaModeles.MatchsModele> ListesMatchsOneEquipeDatee(FifaModeles.EquipesModele equipe, DateTime date)
        {
            DateTime dateDebut = new DateTime(date.Year, 1, 1);

            List<FifaModeles.MatchsModele> lMatchs = new List<FifaModeles.MatchsModele>();

            try
            {
                foreach (FifaModeles.MatchsModele match in this.ListAll())
                {
                    if ((match.equipe1Id == equipe.equipeId || match.equipe2Id == equipe.equipeId) && match.matchDate >= dateDebut && match.matchDate <= date)
                    {
                        lMatchs.Add(match);
                    }
                }
                return lMatchs;
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

        //renvoie la liste des matchs d'une liste d'équipe du 1er janvier année de la date à la date comprise
        public List<FifaModeles.MatchsModele> ListesMatchsListeEquipeDatee(List<FifaModeles.EquipesModele> lEquipe, DateTime date)
        {
            DateTime dateDebut = new DateTime(date.Year, 1, 1);

            List<FifaModeles.MatchsModele> lMatchs = new List<FifaModeles.MatchsModele>();

            try
            {
                foreach (FifaModeles.MatchsModele match in this.ListAll())
                {
                    foreach (FifaModeles.EquipesModele equipe in lEquipe)
                    {
                        if ((match.equipe1Id == equipe.equipeId || match.equipe2Id == equipe.equipeId) && match.matchDate >= dateDebut && match.matchDate <= date)
                        {
                            lMatchs.Add(match);
                        }
                    }
                }
                return lMatchs;
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


        public void enregistrerMatchs(DataView oView)
        {
            try
            {
                if (checkToutesDatesRemplies(oView))
                {


                    if (checkDatesMatch(oView))
                    {

                        using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                        {

                            //récupère la liste des équipes
                            EquipesService equipes = new EquipesService();
                            List<FifaModeles.EquipesModele> lEquipes = equipes.ListAll();

                            foreach (DataRowView oRow in oView)
                            {
                                //trouve l'Id des 2 équipes
                                Guid equipe1Id = Guid.Empty;
                                Guid equipe2Id = Guid.Empty;
                                int i = 0;
                                while ((equipe1Id == Guid.Empty || equipe2Id == Guid.Empty) && i < lEquipes.Count)
                                {
                                    if (lEquipes[i].nom.Equals((String)oRow["Equipe à Domicile :"]))
                                    {
                                        equipe1Id = lEquipes[i].equipeId;
                                    }
                                    if (lEquipes[i].nom.Equals((String)oRow["Equipe à l'extérieur :"]))
                                    {
                                        equipe2Id = lEquipes[i].equipeId;
                                    }
                                    i++;
                                }

                                //assigne la date du match
                                DateTime matchDate = (DateTime)(oRow["Date du Match :"]);

                                //ajoute le match au DbSET
                                ctx.Matchs_Add(matchDate, equipe1Id, equipe2Id);
                            }

                            //enregistre le DbSet dans la database
                            using (TransactionScope scope = new TransactionScope())
                            {
                                ctx.SaveChanges();
                                scope.Complete();
                            }
                        }
                    }
                    else
                    {
                        Exception ex = new Exception("Une équipe ne peut pas jouer 2 fois le même jour");
                        throw ex;
                    }
                }
                else
                {
                    Exception ex = new Exception("Toutes les dates de match doivent être dans un quarter");
                    throw ex;
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

        public Boolean checkDatesMatch(DataView oView)
        {
            Boolean _return = true;

            foreach (DataRowView oRow in oView)
            {
                for (int i =0; i<oView.Count;i++)
                {
                    if ((int)oRow["Match n° :"] !=(int)oView[i]["Match n° :"])
                    {
                        //vérifie si un autre match avec l'équipe à domicile se joue le même jour
                        if ((oRow["Equipe à Domicile :"].Equals((string)oView[i]["Equipe à Domicile :"]) || oRow["Equipe à Domicile :"].Equals((string)oView[i]["Equipe à l'extérieur :"]))
                            && (DateTime)oRow["Date du Match :"]==(DateTime)oView[i]["Date du Match :"])
                        {
                            _return = false;
                        }

                        //vérifie si un autre match avec l'équipe à l'extérieur se joue le même jour
                        if ((oRow["Equipe à l'extérieur :"].Equals((string)oView[i]["Equipe à Domicile :"]) || oRow["Equipe à l'extérieur :"].Equals((string)oView[i]["Equipe à l'extérieur :"]))
                               && (DateTime)oRow["Date du Match :"] == (DateTime)oView[i]["Date du Match :"])
                        {
                            _return = false;
                        }
                    }
                }

            }
            return _return;           
        }

        public Boolean checkToutesDatesRemplies(DataView oView)
        {
            Boolean _return = true;

            //vérifie si toutes les dates ont bien été complétées (la date par défaut la plus élevée est 1/1/1802)
            foreach (DataRowView oRow in oView)
            {
                if ((DateTime)oRow["Date du Match :"] < new DateTime(1802, 1, 2))
                {
                    _return = false;
                }
            }
            return _return;
        }
    }
}
