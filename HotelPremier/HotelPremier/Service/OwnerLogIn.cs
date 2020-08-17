using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPremier.Service
{
    public class OwnerLogIn
    {
        public static bool Login(string username, string password)
        {
            string locationFile = @"..\..\OwnerAccess\OwnerAccess.txt";
            if (File.Exists(locationFile))
            {
                string[] credentials = File.ReadAllLines(locationFile);
                string[] usernameCredentials = credentials[0].Split(':');
                string[] passwordCredentials = credentials[1].Split(':');

                if (username == usernameCredentials[1] && password == passwordCredentials[1])
                {
                    return true;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File not found!");
            }
            return false;
        }
    }
}
