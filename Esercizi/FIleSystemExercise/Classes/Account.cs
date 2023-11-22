using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleSystemExercise.Classes
{
    internal class Account
    {
        private string _accountID;
        private decimal _balance;

        public Account(string accountID, decimal balance)
        {
            _accountID = accountID;
            _balance = balance;
        }

        public string AccountID { get => _accountID; }
        public decimal Balance { get => _balance;}

        public override string ToString()
        {
            return $"AccountID: {AccountID}, Balance:{Balance}";
        }
    }
}
