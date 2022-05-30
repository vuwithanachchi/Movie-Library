using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEFLICKS
{
    class clsSession
    {
        // String variable to hold username for the session
        private static string uName = "";

        // Set method for assign username
        public void SetName(string userName)
        {
            uName = userName;
        }

        // Get method for retrieve username
        public string GetName()
        {
            return uName;
        }
    }
}