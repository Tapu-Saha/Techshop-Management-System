using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_Registration_GUI
{
    class session
    {
        public static string userid;
        public static string username;
        public static string role;
        public static void destroy()
        {
            session.userid = "";
            session.username = "";
            session.role = "";
        }
    }
}
