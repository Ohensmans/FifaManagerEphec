using FifaDAL.BackEnd;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL
{
    public class EquipesService : BackEndService
    {
        public List<EquipesModele> ListAll()
        {
            List<EquipesModele> lChamp;

            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                lChamp = ctx.Equipes.ToList();
            }
            return lChamp;
        }

        // à partir d'une liste de nom, renvoie la liste d'équipe qui correspond
        public List<EquipesModele> ListeEquipeParticipants(List<string> lNomEquipes)
        {
            List<EquipesModele> lEquipe = new List<EquipesModele>(); 

            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                foreach(string str in lNomEquipes)
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


    }
}
