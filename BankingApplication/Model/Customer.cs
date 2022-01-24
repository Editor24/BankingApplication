using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Model
{
    class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
