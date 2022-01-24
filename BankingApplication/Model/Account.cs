using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Model
{
    class Account
    {
        public Account()
        {
            Transactions = new List<Transaction>();
        }
        public Guid AccountNumber { get; set; }
        public TypeOfAccount AccountType { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime LastTransactionTime { get; set; }
        public int WithdrawalLimitPerHour { get; set; }
        public int NumberOfTransactionPerHour { get; set; }
        public List<Transaction> Transactions { get; set; }
        public enum TypeOfAccount
        {
            Saving,
            Current
        }
    }
}
