using BankingApplication.Repositories;
using System;

namespace BankingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BankServices bankServices = new BankServices();
            bankServices.AddAccountDetails();
            bankServices.DisplayAccountDetails();
            char readKey, readKeyOne, readKeyTwo;
            Console.WriteLine("Welcome to our Banking Application\n");
            do
            {
                Console.WriteLine("1: Credit/ Debit");
                Console.WriteLine("2: Display Balance using Account Number");
                Console.WriteLine("3: Display Balance using Customer Id");
                Console.WriteLine("4: Display Statement");
                var readNumber = Console.ReadLine()[0];
                switch (readNumber)
                {
                    case '1':
                        Console.WriteLine("Credit/ Debit");
                        do
                        {
                            Console.WriteLine("Press D for Debit Operation");
                            Console.WriteLine("Press C for Credit Operation");
                            Console.WriteLine("Press N if you want to Quit Debit/Credit operation");
                            char readChar = char.ToUpper(Console.ReadLine()[0]);
                            switch (readChar)
                            {
                                case 'D':
                                    bankServices.Debit();
                                    break;
                                case 'C':
                                    bankServices.Credit();
                                    break;
                                default:
                                    Console.WriteLine("Please enter valid option");
                                    break;
                            }

                            Console.WriteLine("Do you want to further processed For Debit/Credit Operation");
                            Console.WriteLine("Press Y for yes and press N for No");
                            readKeyTwo = char.ToUpper(Console.ReadLine()[0]);
                        } while (readKeyTwo == 'Y');
                        break;
                    case '2':
                        Console.WriteLine("Enter Account Number To View your Balance");
                        var AccountNumber = Console.ReadLine();
                        bankServices.DisplayBalanceUsingAccountNumber(Guid.Parse(AccountNumber));
                        break;
                    case '3':
                        Console.WriteLine("Enter Customer Id  To View All Account Balance");
                        Guid CustomerId;
                        string customerIdStr = Console.ReadLine();
                        while (!(Guid.TryParse(customerIdStr, out CustomerId)))
                        {
                            Console.WriteLine("Please Enter Customer Id in Correct format");
                            customerIdStr = Console.ReadLine();
                        }
                        bankServices.ShowBalanceUsingCustomerId(CustomerId);
                        break;
                    case '4':
                        Console.WriteLine("Enter Account Number to View Account Statement");
                        Guid accountNumber;
                        string accountNumberStr = Console.ReadLine();
                        while (!(Guid.TryParse(accountNumberStr, out accountNumber)))
                        {
                            Console.WriteLine("Please Enter Account number in Correct format");
                            accountNumberStr = Console.ReadLine();
                        }
                        bankServices.ShowAccountStatement(accountNumber);
                        break;

                    default:
                        Console.WriteLine("Please enter valid option");
                        break;
                }
                Console.WriteLine("Do you want to Quit the application");
                Console.WriteLine("Press Y for yes and press N for No");
                readKey = Console.ReadKey().KeyChar;
                readKeyOne = char.ToUpper(readKey);
                Console.WriteLine();
            } while (readKeyOne != 'Y');
        }
    }
}
