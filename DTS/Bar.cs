using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    [Serializable()]
    public class Bar
    {
        public string AreaCode { get; set; }
        public string Exchange{ get; set; }
        public string Number { get; set; }

        public bool CheckBarred(string areaCode, string exchange, string number)
        {
            if (AreaCode == areaCode || Exchange == exchange || Number == number) { return true; }
            else return false;
        }
    }

    [Serializable()]
    class BarAreaCode:Bar
    {
        public BarAreaCode(string areaCode)
        {
            this.AreaCode = areaCode;
        }
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append($"{AreaCode} ");
            return buffer.ToString();
        }
    }

    [Serializable()]
    class BarPhoneNumber:Bar
    {
        public BarPhoneNumber(string AreaCode, string Exchange, string Number)
        {
            this.AreaCode = AreaCode;
            this.Exchange = Exchange;
            this.Number = Number;
        }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append($"{this.AreaCode}-{this.Exchange}-{this.Number}");
            return buffer.ToString();
        }
    }
}
