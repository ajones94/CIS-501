using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    public class TenantManager
    {
        TenantManager tenantManager;
        List<Tenant> tenants;

        public TenantManager SetManager
        {
            set
            {
                tenantManager = value;
            }
        }

        public TenantManager()
        {
            tenants = new List<Tenant>();
        }

        public void AddTenant(Tenant t)
        {
            tenants.Add(t);
        }
        public Tenant FindTenant(string firstName, string lastName)
        {
            Tenant tenant = tenants.Find(x => x.FirstName == firstName && x.LastName == lastName);
            return tenant;
        }

        public void RemoveTenant(Tenant tenant)
        {
            tenants.RemoveAll(x => x == tenant);
        }

        public void SetList(List<Tenant> tenant)
        {
            tenants = tenant;
        }
        public List<Tenant> ObtainList()
        {
            return tenants;
        }
    }
}
