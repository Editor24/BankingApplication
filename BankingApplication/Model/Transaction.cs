using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Model
{
    class Transaction
    {
        public DateTime TrasnsactionTime { get; set; }
        public double Amount { get; set; }

        public TypeOfTransaction TransactionType { get; set; }

        public double Balance { get; set; }

        public enum TypeOfTransaction { Debit, Credit }
    }
}
