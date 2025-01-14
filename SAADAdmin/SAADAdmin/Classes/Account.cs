using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAADAdmin
{
    internal class Account
    {
        private string username;
        private string password;

        public void SetAccountDetails(string username, string password)
        {
           this.username = username;
           this.password = password;
        }

    }
}
