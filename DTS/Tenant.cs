using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    [Serializable()]
    class Tenant
    {
        string firstName;
        string lastName;
        string accessCode;
        List<Call> calls;
        List<Bar> baredNumbers;

        public string FirstName
        {
            get { return firstName; }
        }
        public string LastName
        {
            get { return lastName; }
        }
        public string AccessCode
        {
            get { return accessCode; }
        }

        public Tenant(string FirstName, string LastName, string AccessCode)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.accessCode = AccessCode;
            this.calls = new List<Call>();
            this.baredNumbers = new List<Bar>();
        }

        public void AddCall(string areaCode, string exchange, string number, DateTime callStart, DateTime callEnd)
        {
            calls.Add(new Call(areaCode, exchange, number, callStart, callEnd));
        }

        public void BarAreaCode(string areaCode)
        {
            baredNumbers.Add(new BarAreaCode(areaCode));
        }

        public void BarNumber(string areaCode, string exchange, string number)
        {
            baredNumbers.Add(new BarPhoneNumber(areaCode, exchange, number));
        }

        public void UnBarAreaCode(string areaCode)
        {
            baredNumbers.RemoveAll(x => x.AreaCode == areaCode);
        }
        public void UnBarNumber(string areaCode, string exchange, string number)
        {
            baredNumbers.RemoveAll(x => x.AreaCode == areaCode && x.Exchange == exchange && x.Number == number);
        }
        public List<Call> DisplayCalls()
        {
            return calls;
        }
        
        public List<Bar> DisplayBarredNumbers()
        {
            return baredNumbers;
        }
        public override string ToString()
        {
            StringBuilder tenant = new StringBuilder();
            tenant.Append($"{firstName} {lastName} : {accessCode}");
            return tenant.ToString();
        }

    }

    static class TenantList
    {
        static List<Tenant> tenants;

        public static void ObtainList(List<Tenant> Tenants)
        {
            tenants = new List<Tenant>(Tenants);
        }

        public static List<Tenant> RetrieveList()
        {
            return tenants;
        } 
    }
}
