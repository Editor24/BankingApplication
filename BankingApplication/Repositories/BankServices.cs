using BankingApplication.Interface;
using BankingApplication.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Repositories
{
    class BankServices : IBankServices
    {

        int NumberOfTransactionPerHour = 4;
        int WithdrawLimitPerHour = 200000;
        protected List<Customer> customer = new List<Customer>();
        protected List<Account> account = new List<Account>();
        protected List<Transaction> transaction = new List<Transaction>();

        public void AddAccountDetails()
        {
            customer.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Alex Warior",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType= Account.TypeOfAccount.Saving,
                        CurrentBalance = 100254,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },

                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = Account.TypeOfAccount.Current,
                        CurrentBalance = 52603,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },

                }
            });

            customer.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "James Heloxi",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = Account.TypeOfAccount.Current,
                        CurrentBalance = 450325,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = Account.TypeOfAccount.Saving,
                        CurrentBalance = 321456,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },
                }
            });

            customer.Add(new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "Leion Velax",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = Guid.NewGuid(),
                        AccountType = Account.TypeOfAccount.Saving,
                        CurrentBalance = 784126,
                        LastTransactionTime = DateTime.Now,
                        WithdrawalLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour
                    },

                }
            });
        }

        public void DisplayAccountDetails()
        {
            foreach (var customer in customer)
            {
                Console.WriteLine();
                Console.WriteLine($"Customer Name : {customer.CustomerName}");
                Console.WriteLine($"Customer ID : {customer.CustomerId}");
                foreach (var account in customer.Accounts)
                {
                    Console.WriteLine($"Account Type : {account.AccountType}");
                    Console.WriteLine($"Account Number : {account.AccountNumber}");
                    Console.WriteLine($"Account Balance : {account.CurrentBalance}");
                }
            }
        }

        public void Credit()
        {
            Console.WriteLine("Enter your CustomerId");
            var customerId = Console.ReadLine();
            Console.WriteLine("Enter your AccountNumber");
            var accountNumber = Console.ReadLine();
            var AccountDetails = customer.FirstOrDefault(x => x.CustomerId.ToString() == customerId).Accounts.FirstOrDefault(y =>y.AccountNumber.ToString() == accountNumber);
            if (AccountDetails != null)
            {
                TimeSpan Ts = DateTime.Now - AccountDetails.LastTransactionTime;
                if (Ts.Hours >= 1)
                {
                    AccountDetails.NumberOfTransactionPerHour = 4;
                    AccountDetails.WithdrawalLimitPerHour = 200000;
                }
                Console.WriteLine("Enter amount you want to credit in your Account");
                var amount = Convert.ToInt32(Console.ReadLine());
                if (AccountDetails.NumberOfTransactionPerHour > 0)
                {
                    if ((amount % 100) == 0)
                    {
                        AccountDetails.CurrentBalance = AccountDetails.CurrentBalance + amount;
                        AccountDetails.NumberOfTransactionPerHour -= 1;
                        Console.WriteLine($"{amount} Successfully Credit to Account {AccountDetails.AccountNumber}");
                        AccountDetails.Transactions.Add(new Transaction() 
                        { 
                            TrasnsactionTime=DateTime.Now,
                            Amount = amount,
                            TransactionType= Transaction.TypeOfTransaction.Credit,
                            Balance = AccountDetails.CurrentBalance 
                        });
                        Console.WriteLine($"Current Balance: {AccountDetails.CurrentBalance}");
                    }
                    else
                    {
                        Console.WriteLine("You can Credit only in multiple of hundred");
                    }
                }
                else
                {
                    Console.WriteLine("You can not proceed more than 4 transaction in an hour");
                }
            }
            else
            {
                Console.WriteLine("You Entered Wrong Customer Id or Account Number");
            }
            
        }

        public void Debit()
        {
            Console.WriteLine("Enter your CustomerId");
            var customerId = Console.ReadLine();

            Console.WriteLine("Enter your AccountNumber");
            var accountNumber = Console.ReadLine();

            var AccountDetails = customer.FirstOrDefault(x => x.CustomerId.ToString() == customerId).Accounts.FirstOrDefault(y => y.AccountNumber.ToString() == accountNumber);

            if (AccountDetails != null)
            {
                Console.WriteLine("Enter amount you want to withdraw in your Account");
                var amount = Convert.ToInt32(Console.ReadLine());
                if ((amount % 100) == 0)
                {
                    if (amount <= 50000)
                    {

                        TimeSpan Ts = DateTime.Now - AccountDetails.LastTransactionTime;
                        if (Ts.Hours >= 1)
                        {
                            AccountDetails.NumberOfTransactionPerHour = 4;
                            AccountDetails.WithdrawalLimitPerHour = 200000;
                        }
                        if (AccountDetails.NumberOfTransactionPerHour > 0 && AccountDetails.WithdrawalLimitPerHour > 0)
                        {
                            if (amount > 30000)
                            {
                                AccountDetails.CurrentBalance = AccountDetails.CurrentBalance - (amount + 30);
                                AccountDetails.WithdrawalLimitPerHour -= (amount + 30);
                            }
                            else
                            {
                                AccountDetails.CurrentBalance = AccountDetails.CurrentBalance - amount;
                                AccountDetails.WithdrawalLimitPerHour -= amount;
                            }
                            AccountDetails.NumberOfTransactionPerHour -= 1;
                            AccountDetails.LastTransactionTime = DateTime.Now;
                            AccountDetails.Transactions.Add(new Transaction()
                            {
                                TrasnsactionTime = DateTime.Now,
                                Amount = amount,
                                TransactionType = Transaction.TypeOfTransaction.Debit,
                                Balance = AccountDetails.CurrentBalance
                            });
                            Console.WriteLine($"{amount} Successfully Debited from Account {AccountDetails.AccountNumber}");
                            Console.WriteLine($"Current Balance: {AccountDetails.CurrentBalance}");
                        }
                        else
                        {
                            Console.WriteLine("You have exceed your hourly limit");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can only withdraw less than or equal to 50k");
                    }
                }
                else
                {
                    Console.WriteLine("You can  withdraw in multiple of hundred");
                }
            }
            else
            {
                Console.WriteLine("You Entered Wrong Customer Id or Account Number");
            }
        }

        public void ShowAccountStatement(Guid accountNumber)
        {
            var accountDetail = customer.Select(x => x.Accounts.FirstOrDefault(y => y.AccountNumber == accountNumber));
            if (accountDetail!=null)
            {
                Console.WriteLine("Time \t\t\t Amount \tType \tBalance");
                Console.WriteLine("------------------------------------------------------------------");
                foreach (var account in accountDetail)
                {
                    if (account != null)
                    {
                        foreach (var transaction in account.Transactions)
                        {
                            Console.WriteLine($"{transaction.TrasnsactionTime}\t{transaction.Amount}\t\t{transaction.TransactionType}\t{transaction.Balance}");
                        }
                    }
                    else
                    {
                        continue;
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("No Record Found..");
            }
        }

        public void ShowBalanceUsingCustomerId(Guid CustomerId)
        {
            var allAccountsDetail = customer.FirstOrDefault(x => x.CustomerId == CustomerId);
            if (allAccountsDetail != null)
            {
                int index = 1;
                Console.WriteLine("No. \t\t\t Account Number \t\tAccount Type \t Balance");
                Console.WriteLine("--------------------------------------------------------------------------------");
                foreach (var account in allAccountsDetail.Accounts)
                {
                    Console.WriteLine($"{index++}\t\t{account.AccountNumber}\t{account.AccountType}\t\t{account.CurrentBalance}");
                }
            }
            else
            {
                
                Console.WriteLine("No Records Found..");
            }
        }

        public void DisplayBalanceUsingAccountNumber(Guid AccountNumber)
        {
                var accountDetail = customer.Select(x => x.Accounts.FirstOrDefault(y => y.AccountNumber == AccountNumber));
                if (accountDetail.Any(i=>i!=null))
                {
                    Console.WriteLine("Account Number \t\t\t\t Account Type \tCurrent Balance");
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    foreach (var account in accountDetail)
                    {
                        if (account != null)
                        {
                            Console.WriteLine($"{account.AccountNumber}\t{account.AccountType}\t\t{account.CurrentBalance}");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Records Found...");
                }
 
        }
    }
}
