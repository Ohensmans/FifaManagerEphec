using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaDAL.MatchManagement;
using System.Transactions;

namespace MatchManagementBL
{
    public class JoueursParticipationService : MatchManagementService
    {
        public JoueursParticipationService()
        {
            this.name = "JoueursParticipation";
        }


        public List<JoueursParticipationModele> GetListeObject()
        {
            try
            {
                List<JoueursParticipationModele> liste = new List<JoueursParticipationModele>();
                return liste = ConvertDataTable<JoueursParticipationModele>(this.loadAllData().ToTable());
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

        // utilise les procédures stockées de lecture procedureName nécésitant des paramètres lstParam
        public DataView loadWithParameter(string newTableName, List<dynamic> lstParam)
        {
            try
            {
                JoueursParticipationData oData = new JoueursParticipationData(_Connection);
                return oData.getParticipants(lstParam, newTableName).Tables[newTableName].DefaultView;
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

        //ajoute et supprime les participations nécessaires (qui ont été modifiées)
        public void SaveAll (DataView oView, Guid matchId, Guid equipeId)
        {
            try
            {
             using (TransactionScope scope = new TransactionScope())
                {
                    FeuillesMatchService fs = new FeuillesMatchService();
                    Guid feuilleID = fs.UpdateFeuille(matchId,equipeId);

                    this.AddAll(oView, feuilleID);
                    this.DeleteAll(oView, feuilleID);

                    scope.Complete();
                }
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

        // ajoute les lignes de joueurs inscrits qui ont été modifiées
        public void AddAll (DataView oView, Guid feuilleId)
        {
            try
            {
                oView.RowStateFilter = DataViewRowState.ModifiedCurrent;
                if (oView.Count>0)
                {
                    foreach (DataRowView rowView in oView)
                    {
                        if ((Boolean)rowView[4])
                        {
                            List<dynamic> lstParam = new List<dynamic>();
                            lstParam.Add(rowView[5]);
                            lstParam.Add(feuilleId);

                            JoueursParticipationData jpd = new JoueursParticipationData(_Connection);
                            jpd.AddParticipants(lstParam);
                        }
                    }
                }

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

        // supprime les lignes de joueurs qui ne sont plus inscrits et qui ont été modifiées
        public void DeleteAll(DataView oView, Guid feuilleId)
        {
            try
            {
                oView.RowStateFilter = DataViewRowState.ModifiedCurrent;
                if (oView.Count > 0)
                {
                    foreach (DataRowView rowView in oView)
                    {
                        if (!(Boolean)rowView[4])
                        {
                            List<dynamic> lstParam = new List<dynamic>();
                            lstParam.Add(rowView[5]);
                            lstParam.Add(feuilleId);

                            JoueursParticipationData jpd = new JoueursParticipationData(_Connection);
                            jpd.DeleteParticipants(lstParam);
                        }
                    }
                }

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

        public int getCountJoueur(Guid feuilleId)
        {
            try
            {
                if (this.GetListeObject().Any(x => x.feuilleId == feuilleId))
                {
                    return this.GetListeObject().Where(x => x.feuilleId == feuilleId)
                                     .ToList()
                                     .Count;
                }
                return 0;              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
