using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaError
{
    public class BusinessError : Exception
    {
        private string _Message;

        public BusinessError(string Message)
        {
            this._Message = Message;
        }

        public override string Message
        {
            get { return _Message; }
        }
    }
}
