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
        public List<EquipesModele> ListAll()
        {
            try
            {
                List<EquipesModele> lEqu = new List<EquipesModele>();

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (dynamic dyn in ctx.Equipes_GetAll())
                    {
                        EquipesModele eq = new EquipesModele();
                        eq = dyn;
                        lEqu.Add(eq);
                    }
                }
                return lEqu;
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

        // à partir d'une liste de nom, renvoie la liste d'équipe qui correspond
        public List<EquipesModele> ListeEquipeParticipants(List<string> lNomEquipes)
        {
            try
            {
                List<EquipesModele> lEquipe = new List<EquipesModele>();

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

        // à partir d'un nom d'équipe, renvoie l'équipe qui correspond
        public EquipesModele getEquipe (string nomEquipes)
        {
            try
            {
                return this.ListAll().Where(x => x.nom == nomEquipes).FirstOrDefault();
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

        // à partir de l'Id d'une équipe, renvoie l'équipe qui correspond
        public EquipesModele getEquipe(Guid equipeId)
        {
            try
            {
                return this.ListAll().Where(x => x.equipeId == equipeId).FirstOrDefault();
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
