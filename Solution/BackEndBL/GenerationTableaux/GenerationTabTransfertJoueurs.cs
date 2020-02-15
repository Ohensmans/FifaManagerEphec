using BackEndBL.Services;
using FifaError;
using FifaModeles;
using FifaModeles.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.GenerationTableaux
{
    public class GenerationTabTransfertJoueurs
    {
        public DataTable genererTableauTransferts()
        {
            try
            {

                DataTable oTable = new TableTransfertJoueurs().getTable();
                DataRow row;

                //récupère la liste des participations de joueurs en cours dans des équipes
                TransfertsService Joueurstransferts = new TransfertsService();
                List<TransfertsModele> lTransferts = Joueurstransferts.ListAllWithEquipeJoueurs();

                //récupère la liste des joueurs
                JoueursService js = new JoueursService();
                List<JoueursModele> lJoueurs = js.ListAll();

                //récupère la liste des équipes
                EquipesService es = new EquipesService();
                List<EquipesModele> lEquipes = es.ListAll();



                //rajoute les joueurs qui ont déjà été transférés
                foreach (TransfertsModele transferts in lTransferts)
                {
                    row = oTable.NewRow();

                    // récupère le nom du joueur
                    string prenom = lJoueurs.Where(xx => xx.joueurId == transferts.joueurId).FirstOrDefault().prenom;
                    string nom = lJoueurs.Where(xx => xx.joueurId == transferts.joueurId).FirstOrDefault().nom;
                    row["Joueur :"] = prenom + " " + nom;

                    row["Equipe :"] = lEquipes.Where(xx => xx.equipeId == transferts.equipeId).FirstOrDefault().nom;

                    row["Date arrivee :"] = (DateTime)transferts.dateDebut;

                    oTable.Rows.Add(row);
                }

                //rajoute les joueurs sans équipe
                foreach (JoueursModele joueurs in lJoueurs)
                {
                    row = oTable.NewRow();

                    //vérifie si le joueur n'est pas déjà dans la table de joueursParticipation
                    if (lTransferts.FirstOrDefault(xx => xx.joueurId == joueurs.joueurId) == null)
                    {
                        row["Joueur :"] = joueurs.prenom + " " + joueurs.nom;
                        oTable.Rows.Add(row);
                    }
                }

                oTable.AcceptChanges();
                return oTable;
            }
            catch (TechnicalError oErreur)
            {
                throw oErreur;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
