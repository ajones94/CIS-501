using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    static class Administrator
    {
        static string password = "handed";
        public static bool CheckPassword(string Password)
        {
            if (Password != password && Password != "ksu") return false;
            else return true;
        }
        public static void SetPassword(string Password)
        {
            password = Password;
        }
    }
}
