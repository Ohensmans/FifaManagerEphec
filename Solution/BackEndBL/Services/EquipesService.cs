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


    }
}
