using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBL
{
    public class BackEndService
    {
        //protected string _Connection = "metadata=res://*/BackEndDBF.ModelBackEnd.csdl|res://*/BackEndDBF.ModelBackEnd.ssdl|res://*/BackEndDBF.ModelBackEnd.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(local);initial catalog=FifaManagerEphec;persist security info=True;user id=BackEnd;password=ephec01;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        protected string _Connection = "name=FifaManagerEphecEntities";
        //protected string _Connection = "Data Source = DESKTOP-C7PMR28\\COURS2019;Initial Catalog = FifaManagerEphec; User ID = sa; Password=ephec";
        //protected string _Connection = "Data Source = (local);Initial Catalog = FifaManagerEphec; User ID = BackEnd; Password=ephec01";


    }
}
