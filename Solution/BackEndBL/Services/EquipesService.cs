using FifaDAL.BackEndDBF;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL
{
    public class EquipesService : BackEndService
    {
        public List<FifaModeles.EquipesModele> ListAll()
        {
            try
            {
                List<FifaModeles.EquipesModele> lEqu = new List<FifaModeles.EquipesModele>();

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (Equipes_GetAll_Result equipe in ctx.Equipes_GetAll())
                    {
                        FifaModeles.EquipesModele eq = new FifaModeles.EquipesModele();
                        eq.equipeId = equipe.equipeId;
                        eq.nom = equipe.nom;
                        eq.lastUpdate = equipe.lastUpdate;
                        eq.logoPath = equipe.logoPath;
                        lEqu.Add(eq);
                    }
                }
                return lEqu;
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

        // à partir d'une liste de nom, renvoie la liste d'équipe qui correspond
        public List<FifaModeles.EquipesModele> ListeEquipeParticipants(List<string> lNomEquipes)
        {
            try
            {
                List<FifaModeles.EquipesModele> lEquipe = new List<FifaModeles.EquipesModele>();

                foreach (string str in lNomEquipes)
                {
                    // vérifie que l'équipe existe bien
                    if (this.ListAll().Where(x => x.nom == str).FirstOrDefault() != null)
                    {
                        lEquipe.Add(this.ListAll().Where(x => x.nom == str).FirstOrDefault());
                    }
                }

                return lEquipe;
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

        // à partir d'un nom d'équipe, renvoie l'équipe qui correspond
        public FifaModeles.EquipesModele getEquipe (string nomEquipes)
        {
            try
            {
                return this.ListAll().Where(x => x.nom == nomEquipes).FirstOrDefault();
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

        // à partir de l'Id d'une équipe, renvoie l'équipe qui correspond
        public FifaModeles.EquipesModele getEquipe(Guid equipeId)
        {
            try
            {
                return this.ListAll().Where(x => x.equipeId == equipeId).FirstOrDefault();
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
