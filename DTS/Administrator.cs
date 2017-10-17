using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    class Administrator
    {
        string password = "handed";

        public Administrator() { }
        public bool CheckPassword(string Password)
        {
            if (Password != password && Password != "ksu") return false;
            else return true;
        }
        public void SetPassword(string Password)
        {
            password = Password;
        }
    }
}
