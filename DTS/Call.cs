using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    [Serializable()]
    public class Call
    {
        string areaCode;
        string exchangeCode;
        string number;
        DateTime callStart;
        DateTime callEnd;

        public Call(string AreaCode, string ExchangeCode, string Number, DateTime CallStart, DateTime CallEnd)
        {
            this.areaCode = AreaCode;
            this.exchangeCode = ExchangeCode;
            this.number = Number;
            this.callStart = CallStart;
            this.callEnd = CallEnd;
        }

        public override string ToString()
        {
            StringBuilder call = new StringBuilder();
            call.Append($"{areaCode}-{exchangeCode}-{number} : {callStart}---{callEnd}");

            return call.ToString();
        }
    }
}
