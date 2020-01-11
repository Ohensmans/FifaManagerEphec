using FifaDAL.BackEnd;
using FifaModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL.Services
{
    public class TransfertsService : BackEndService
    {
        public List<TransfertsModele> ListAll()
        {
            List<TransfertsModele> lTransferts;

            using (FifaManagerContext ctx = new FifaManagerContext(_Connection))
            {
                lTransferts = ctx.Transferts.ToList();
            }
            return lTransferts;
        }
    }
}
