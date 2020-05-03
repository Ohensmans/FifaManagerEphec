using FifaDAL.BackEndDBF;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.Services
{
    public class FeuillesDeMatchService : BackEndService
    {
        public List<FeuillesDeMatchModele> ListAll()
        {
            try
            {
                List<FeuillesDeMatchModele> lFeuilles = new List<FeuillesDeMatchModele>();

                MatchsService ms = new MatchsService();
                List<MatchsModele> lMatchs = ms.ListAll();

                using (FifaManagerEphecEntities ctx = new FifaManagerEphecEntities(_Connection))
                {
                    foreach (FeuilleDeMatch_GetAll1_Result oFeuille in ctx.FeuilleDeMatch_GetAll1())
                    {
                        FeuillesDeMatchModele feuille = new FeuillesDeMatchModele();
                        feuille.feuilleId = oFeuille.feuilleId;
                        feuille.matchId = oFeuille.matchId;
                        feuille.equipeId = oFeuille.equipeId;
                        feuille.lastUpdate = oFeuille.lastUpdate;
                        feuille.Matchs = lMatchs.FirstOrDefault(x => x.matchId == oFeuille.matchId);
                        lFeuilles.Add(feuille);

                     }
                }
                return lFeuilles;
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
