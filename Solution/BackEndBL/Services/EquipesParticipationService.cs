using FifaDAL.BackEnd;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.Services
{
    public class EquipesParticipationService : BackEndService
    {
        public List<EquipesParticipationModele> ListAll()
        {
            List<EquipesParticipationModele> lEquParti;

            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                lEquParti = ctx.EquipesParticipation.ToList();
            }
            return lEquParti;
        }
    }
}
