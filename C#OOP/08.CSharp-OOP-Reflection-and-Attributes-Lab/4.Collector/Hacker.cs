using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPasssw0rd";

        public string Passsword
        {
            get => password;
            set => password = value;
        }

        private int Id { get; set; }
        public double BankAccountBalance { get; private set; }
        public void DownloadAllBankAccountsInTheWorld()
        {

        }
    }
}
