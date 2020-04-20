using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    public class EquipesParticipationsService : MatchManagementService
    {
        public EquipesParticipationsService()
        {
            this.name = "EquipesParticipation";
        }

        public List<EquipesParticipationModele> GetListeObject()
        {
            try
            {
                List<EquipesParticipationModele> listeEquipeParticipation = new List<EquipesParticipationModele>();
                return listeEquipeParticipation = ConvertDataTable<EquipesParticipationModele>(this.loadAllData().ToTable());
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

        public List<EquipesModele> getEquipesParticipantes (Guid championnatId)
        {
            EquipesService es = new EquipesService();
            List<EquipesModele> lEquipesAll = es.GetListeObject();

            List<EquipesModele> lEquipesParticipantes = new List<EquipesModele>();

            List<EquipesParticipationModele> lIdEquipesParticipantes = this.GetListeObject().Where(x => x.championnatId == championnatId)
                                                                                          .ToList();
            foreach (EquipesModele equipe in lEquipesAll)
            {
                if (lIdEquipesParticipantes.Any(x => x.equipeId == equipe.equipeId))
                {
                    lEquipesParticipantes.Add(equipe);
                }
            }
            return lEquipesParticipantes;                                                                                           
        }

    }
}
