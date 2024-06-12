using System.Runtime.InteropServices;
using Bank.Exceptions;
using Bank.Models;


namespace Bank
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",");
            List<BankAccount> bank = new();
            for (int i = 0; i < input.Length; i++)
            {
                string[] accountInfo = input[i].Split('-');
                BankAccount account = new(int.Parse(accountInfo[0]), decimal.Parse(accountInfo[1]));
                bank.Add(account);
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandInfo = command.Split();
                string action = commandInfo[0];
                int accountNumber = int.Parse(commandInfo[1]);
                decimal amount = decimal.Parse(commandInfo[2]);
                try
                {
                    if (action == "Deposit")
                    {

                        BankAccount currentAccount = bank.FirstOrDefault(x => x.AccountNumber == accountNumber);
                        if (currentAccount == null)
                        {
                            throw new AccountNotFoundException(ExeptionMessages.AccountNotFound);
                        }

                        currentAccount.Deposit(amount);
                        Console.WriteLine($"Account {accountNumber} has new balance: {currentAccount.Balance}");
                    }
                    else if (action == "Withdraw")
                    {
                        BankAccount currentAccount = bank.FirstOrDefault(x => x.AccountNumber == accountNumber);
                        if (currentAccount == null)
                        {
                            throw new AccountNotFoundException(ExeptionMessages.AccountNotFound);
                        }

                        currentAccount.Withdraw(amount);
                        Console.WriteLine($"Account {accountNumber} has new balance: {Math.Round(currentAccount.Balance,2)}");
                    }
                    else
                    {
                        throw new InvalidCommandException(ExeptionMessages.InvalidCommand);
                    }
                }
                catch (AccountNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidCommandException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
