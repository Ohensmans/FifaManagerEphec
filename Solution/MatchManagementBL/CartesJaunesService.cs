using FifaDAL.MatchManagement;
using FifaError;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MatchManagementBL
{
    public class CartesJaunesService : MatchManagementService
    {
        public CartesJaunesService()
        {
            this.name = "CartonsJaunes";
        }

        //ajoute et supprime les participations nécessaires (qui ont été modifiées)
        public void SaveAll(DataView oView, Guid matchId, Guid equipeId)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    this.AddAll(oView, matchId, equipeId);
                    this.DeleteAll(oView);
                    this.UpdateAll(oView, matchId);

                    scope.Complete();
                }
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

        // ajoute les lignes de joueurs inscrits qui ont été modifiées
        public void AddAll(DataView oView, Guid matchId, Guid equipeId)
        {
            try
            {
                oView.RowStateFilter = DataViewRowState.Added;
                if (oView.Count > 0)
                {
                    foreach (DataRowView rowView in oView)
                    {
                        List<dynamic> lstParam = new List<dynamic>();
                        lstParam.Add(rowView[0]);
                        lstParam.Add(matchId);
                        lstParam.Add(equipeId);
                        lstParam.Add(rowView[2]);

                        CartonsJaunesData cjd = new CartonsJaunesData(_Connection);
                        cjd.AddCarte(lstParam);
                    }
                }

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

        // supprime les lignes de joueurs qui ne sont plus inscrits et qui ont été modifiées
        public void DeleteAll(DataView oView)
        {
            try
            {
                oView.RowStateFilter = DataViewRowState.Deleted;
                if (oView.Count > 0)
                {
                    foreach (DataRowView rowView in oView)
                    {
                        
                        List<dynamic> lstParam = new List<dynamic>();
                        lstParam.Add(rowView[3]);
                        
                        CartonsJaunesData cjd = new CartonsJaunesData(_Connection);
                        cjd.DeleteCarte(lstParam);
                    }
                }
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

        // modifie les lignes de joueurs inscrits qui ont été modifiées
        public void UpdateAll(DataView oView, Guid matchId)
        {
            try
            {
                oView.RowStateFilter = DataViewRowState.ModifiedCurrent;
                if (oView.Count > 0)
                {
                    foreach (DataRowView rowView in oView)
                    {
                        DateTime Maint = DateTime.Now;

                        List<dynamic> lstParam = new List<dynamic>();
                        lstParam.Add(rowView[3]);
                        lstParam.Add(rowView[0]);
                        lstParam.Add(matchId);
                        lstParam.Add(rowView[2]);
                        lstParam.Add(Maint);

                        CartonsJaunesData cjd = new CartonsJaunesData(_Connection);
                        cjd.UpdateCarte(lstParam);
                    }
                }

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
