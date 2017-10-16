using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DTS_Project
{

    public class TerminalController
    {
        private ITerminalDevice terminalDevice;
        List<Tenant> currentTenants;
        Tenant workOnTenant;

        public TerminalController(ITerminalDevice terminalDevice)
        {
            this.terminalDevice = terminalDevice;
            currentTenants = new List<Tenant>();
        }

        public void Activate()
        {
            //verify password and if verified, show MainMenuDialog
            // if a user presses "Cancel", do nothing and just return
            string password = null;
            if (!terminalDevice.GetPassword(ref password)) return;
            if (!Administrator.CheckPassword(password)) return;
            terminalDevice.ShowMainMenuDialog(this);
        }

        // handlers for MainMenuDialog
        public void AddTenant_Handler()
        {
            // Add a tenant
            // Get the name and access code of the tenant to be added
            string firstName = null;
            string lastName = null;
            string accessCode = null;
            if (!terminalDevice.GetTenantInfo(ref firstName, ref lastName, ref accessCode)) return;
            currentTenants.Add(new Tenant(firstName, lastName, accessCode));
            TenantList.ObtainList(currentTenants);
        }

        public void DeleteTenant_Handler()
        {
            // Delete a tenant
            // Get the first name and the last name of the tenant to be deleted
            string firstName = null;
            string lastName = null;
            if (!terminalDevice.GetTenantName(ref firstName, ref lastName)) return;
            Tenant tenant = currentTenants.Find(x => x.FirstName == firstName && x.LastName == lastName);
            currentTenants.Remove(tenant);

        }

        public void WorkOnTenant_Handler()
        {
            // Work on a specific tenant
            // Input the first name and the last name of the tenant to work on
            string firstName = null;
            string lastName = null;
            if (!terminalDevice.GetTenantName(ref firstName, ref lastName)) return;
            workOnTenant = currentTenants.Find(x => x.FirstName == firstName && x.LastName == lastName);
            if(workOnTenant != null)
            {
                terminalDevice.ShowTenantMenuDialog(this);
            }
        }

        public void DisplayTenantList_Handler()
        {
            // call "void DisplayList(object[] list)" to list Tenants
            object[] tenants = currentTenants.ToArray();
            terminalDevice.DisplayList(tenants);
        }

        public void Save_Handler()
        {
            BinaryFormatter fo = new BinaryFormatter();
            using (FileStream f = new FileStream("DTSsavefile.svf",
                FileMode.Create, FileAccess.Write))
            {
                fo.Serialize(f, currentTenants);
            }
        }
        public void Restore_Handler()
        {
            BinaryFormatter fo = new BinaryFormatter();
            using (FileStream f = new FileStream("DTSsavefile.svf",
                FileMode.Open, FileAccess.Read))
            {
                currentTenants = (List<Tenant>)fo.Deserialize(f);
                TenantList.ObtainList(currentTenants);
            }
        }

        public void ChangePassword_Handler()
        {
            string password = null;
            if (!terminalDevice.GetPassword(ref password)) return;
            Administrator.SetPassword(password);

        }

        // ==== Handlers for TenantMenuDialog
        public void BarAreaCode_Handler()
        {
            // Bar an area code
            // Input the area code to bar
            string areaCode = null;
            if (!terminalDevice.GetAreaCode(ref areaCode)) return;
            workOnTenant.BarAreaCode(areaCode);
        }

        public void BarTelephoneNumber_Handler()
        {
            // Bar a telephone number
            // Input the telephone number to bar
            string areaCode = null;
            string exchange = null;
            string number = null;
            if (!terminalDevice.GetTelephoneNumber(ref areaCode, ref exchange, ref number)) return;
            workOnTenant.BarNumber(areaCode, exchange, number);
        }

        public void UnBarAreaCode_Handler()
        {
            // Unbar an area code
            // Input the area code to unbar
            string areaCode = null;
            if (!terminalDevice.GetAreaCode(ref areaCode)) return;
            workOnTenant.UnBarAreaCode(areaCode);

        }

        public void UnBarTelephoneNumber_Handler()
        {
            // Unbar a telephone number
            // Input the telephone number to unbar 
            string areaCode = null;
            string exchange = null;
            string number = null;
            if (!terminalDevice.GetTelephoneNumber(ref areaCode, ref exchange, ref number)) return;
            workOnTenant.UnBarNumber(areaCode, exchange, number);

        }

        public void DisplayCallList_Handler()
        {
            Object[] Calls  = ((workOnTenant.DisplayCalls()).ToArray());
            terminalDevice.DisplayList(Calls);

        }

        public void DisplayBarList_Handler()
        {
            Object[] BarredNumbers = ((workOnTenant.DisplayBarredNumbers()).ToArray());
            terminalDevice.DisplayList(BarredNumbers);

        }

        public void ClearCalls_Handler()
        {
            List<Call> calls = workOnTenant.DisplayCalls();
            calls.Clear();
        }
    }
}
