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
    public static class GenerationTabEquipeSelection
    {
        static int MINJOUEUR = 5;
        static int MAXJOUEUR = 10;

        public static DataTable getEquipes(DateTime debutChamp)
        {
            try
            {
                EquipesService es = new EquipesService();
                List<EquipesModele> lEquipes = es.ListAll();

                TransfertsService ts = new TransfertsService();
                List<TransfertsModele> lTransferts = ts.ListAll();

                DataTable equipesSelection = new TableEquipesSelectionnees().getTable();
                DataRow row;

                foreach (EquipesModele em in lEquipes)
                {
                    int count = 0;

                    foreach  (TransfertsModele tm in lTransferts)
                    {
                        if (em.equipeId == tm.equipeId && tm.dateDebut<debutChamp && (tm.dateFin== null || tm.dateFin>debutChamp))
                        {
                            count++;
                        }
                    }

                    if (count <=MAXJOUEUR && count >=MINJOUEUR)
                    {
                        row = equipesSelection.NewRow();

                        row[0] = em.nom;

                        row[1] = false;

                        equipesSelection.Rows.Add(row);
                    }
                }
                return equipesSelection;

            }
            catch (CustomsError oErreur)
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
