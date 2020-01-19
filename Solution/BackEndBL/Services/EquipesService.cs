using FifaDAL.BackEnd;
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
                List<EquipesModele> lChamp;

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    lChamp = ctx.Equipes.ToList();
                }
                return lChamp;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    CustomsError oErreur = new CustomsError((SqlException)ex.InnerException.InnerException);
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

                using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
                {
                    foreach (string str in lNomEquipes)
                    {
                        // vérifie que l'équipe existe bien
                        if (ctx.Equipes.Where(x => x.nom == str).FirstOrDefault() != null)
                        {
                            lEquipe.Add(ctx.Equipes.Where(x => x.nom == str).FirstOrDefault());
                        }
                    }
                }
                return lEquipe;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    CustomsError oErreur = new CustomsError((SqlException)ex.InnerException.InnerException);
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
