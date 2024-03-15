using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWordlev2
{
    public class LoginFacade //väldigt simpel fasad, förenklar, inkapslar, går att återanvändas
    {
        private static readonly LoginFacade instance = new LoginFacade();

        private LoginFacade() { } //privat ctor

        public static LoginFacade Instance => instance;

        public bool Authenticate(string username, string password) //lägg till databas med användare/skapa användare
        {
            
            if (username == "admin" && password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
