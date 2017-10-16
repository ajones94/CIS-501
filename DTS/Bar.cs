using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    [Serializable()]
    class Bar
    {
        public string AreaCode { get; set; }
        public string Exchange{ get; set; }
        public string Number { get; set; }
        public Bar() { }

        public bool CheckBarred(string areaCode, string exchange, string number)
        {
            if (AreaCode == areaCode) { return true; }
            else if (AreaCode == areaCode && Exchange == exchange && Number == number) { return true; }
            else return false;
        }

    }

    [Serializable()]
    class BarAreaCode:Bar
    {
        Bar b = new Bar();
        public BarAreaCode(string areaCode)
        {
            this.AreaCode = areaCode;
        }

        public bool CheckBarAreaCode(string AreaCode)
        {
            if (!b.CheckBarred(AreaCode, " ", " ")) { return false; }
            else return true;
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
        Bar b = new Bar();
        public BarPhoneNumber(string AreaCode, string Exchange, string Number)
        {
            this.AreaCode = AreaCode;
            this.Exchange = Exchange;
            this.Number = Number;
        }

        public bool CheckBarPhoneNumber(string areaCode, string exchange, string number)
        {
            if(!b.CheckBarred(areaCode, exchange, number)){ return false; }
            else return true;
        }
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append($"{this.AreaCode}-{this.Exchange}-{this.Number}");
            return buffer.ToString();
        }
    }
}
