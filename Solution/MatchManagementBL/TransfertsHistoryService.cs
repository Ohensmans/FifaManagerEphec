using FifaDAL.MatchManagement;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchManagementBL
{
    class TransfertsHistoryService : MatchManagementService
    {
        public TransfertsHistoryService()
        {
            this.name = "Transferts";
        }

        public List<TransfertsModele> GetListeObject()
        {
            try
            {
                List<TransfertsModele> liste = new List<TransfertsModele>();
                return liste = ConvertDataTable<TransfertsModele>(this.loadAllData().ToTable());
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
                TransfertsData oData = new TransfertsData(_Connection);
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

    }
}
