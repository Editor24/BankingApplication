using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Interface
{
    interface IBankServices
    {
        void AddAccountDetails();

        void DisplayAccountDetails();

        void ShowAccountStatement(Guid accountNumber);

        void Debit();

        void Credit();

        public void ShowBalanceUsingCustomerId(Guid CustomerId);

        public void DisplayBalanceUsingAccountNumber(Guid AccountNumber);


    }
}
