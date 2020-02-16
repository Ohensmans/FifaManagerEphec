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

        public BusinessError(string Message, string rowNumber)
        {
            this._Message = Message;
            this.rowNumber = rowNumber;
        }

        public override string Message
        {
            get { return _Message; }
        }

        public string rowNumber { get; set; }
    }
}
