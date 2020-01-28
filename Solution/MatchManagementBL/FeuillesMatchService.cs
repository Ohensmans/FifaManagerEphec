using FifaDAL.MatchManagement;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MatchManagementBL
{
    class FeuillesMatchService : MatchManagementService
    {
        public FeuillesMatchService()
        {
            this.name = "FeuilleDeMatch";
        }


        //reçoit un matchId et renvoie la feuilleDeMatch correspondant ou crée une nouvelle
        public Guid UpdateFeuille(Guid matchId, Guid equipeId)
        {
            try
            {
                DataView fv = this.loadAllData();
                Guid feuilleId = Guid.NewGuid();
                Boolean nouveau = true;

                // récupère feuilleID si il existe
                foreach (DataRowView dr in fv)
                {
                    if ((Guid)dr["matchId"] == matchId && (Guid)dr["equipeId"] == equipeId)
                    {
                        feuilleId = (Guid)dr["feuilleId"];
                        nouveau = false;
                    }
                }
                // si n'exite pas la crée dans la DB
                if (nouveau)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        FeuilleMatchData fmd = new FeuilleMatchData(_Connection);

                        List<dynamic> lParam = new List<dynamic>();
                        lParam.Add(matchId);
                        lParam.Add(equipeId);

                        fmd.Add(lParam);

                        scope.Complete();
                    }

                }
                return feuilleId;
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


        public List<FeuillesDeMatchModele> GetListeObject()
        {
            try
            {
                List<FeuillesDeMatchModele> listeJoueurs = new List<FeuillesDeMatchModele>();
                return listeJoueurs = ConvertDataTable<FeuillesDeMatchModele>(this.loadAllData().ToTable());
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

    }
}
