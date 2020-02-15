using BackEndBL.GenerationTableaux;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.Services
{
    public class ClassementEquipe
    {

        //vérifie si l'équipe envoyée est bien dans les 3 derniers du championnat à la date envoyée
        public Boolean isLastThree(EquipesModele equipe, DateTime date)
        {
            try 
            {
                int NBEQUIPE = 3;
                EquipesParticipationService eps = new EquipesParticipationService();

                DataView oView = new GenerationTabClassementEquipe().getClassementEquipe(date).DefaultView;
                //trie le tableau de manière ascendante
                oView.Sort = "Points Totaux asc";


                //vérifie que l'équipe d'arrivée est bien dans le championnat
                if (eps.isParticipation(equipe, date))
                {
                    if (oView.Count > NBEQUIPE)
                    {
                        for (int i = 0; i < NBEQUIPE; i++)
                        {
                            //vérifie si l'équipe est dans les 3 dernières row du tableau
                            if (oView[i]["Equipe :"].ToString() == equipe.nom)
                            {
                                return true;
                            }
                        }
                        // retourne un BusinessError si l'équipe n'est pas dans les NBEQUIPE derniers
                        BusinessError bErreur = new BusinessError("L'équipe d'arrivée (" + equipe.nom + ") n'est pas classée dans les " + NBEQUIPE + " dernières équipes du classement");
                        throw bErreur;

                    }
                    else
                    {
                        return true;
                    }
                }
                return true;

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
