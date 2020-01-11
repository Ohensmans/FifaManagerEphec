using FifaDAL.BackEnd;
using FifaError;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL
{
    public class ChampionnatService : BackEndService
    {
        public List<ChampionnatsModele> ListAll()
        {
            List<ChampionnatsModele> lChamp;

            using (FifaManagerContext ctx =  new FifaManagerContext(_Connection))
            {
                try
                {
                    lChamp = ctx.Championnats.ToList();
                }

                catch (SqlException exsql)
                {
                    CustomsError oErreur = new CustomsError(exsql);
                    throw oErreur;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return lChamp;
        }

    }
}
