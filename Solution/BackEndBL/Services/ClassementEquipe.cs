using BackEndBL.GenerationTableaux;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.Services
{
    public class ClassementEquipe
    {

        //vérifie si l'équipe envoyée est bien dans les 3 derniers du championnat à la date envoyée
        /*public Boolean isLastThree (EquipesModele equipe, DateTime date)
        {
            EquipesParticipationService eps = new EquipesParticipationService();

            //vérifie que l'équipe est bien dans le championnat
            if (eps.isParticipation(equipe, date))
            {
                DataView oView = new GenerationTabClassementEquipe().getClassementEquipe(date.Year).DefaultView;
            }
        }*/


    }
}
