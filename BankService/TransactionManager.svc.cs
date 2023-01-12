using BankOfBIT_ZD.Data;
using BankOfBIT_ZD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TransactionManager.svc or TransactionManager.svc.cs at the Solution Explorer and start debugging.
    public class TransactionManager : ITransactionManager
    {
        private BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();

        /// <summary>
        /// Update balance of a specified account by a giving amount.
        /// </summary>
        /// <param name="accountId">Represents the account id.</param>
        /// <param name="amount">Represents the amount of money.</param>
        /// <returns>The updated balance</returns>
        private double? UpdateBalance(int accountId, double amount)
        {
            //Retrieve the record based on the accountId argument
            BankAccount account = (from result in db.BankAccounts
                                   where result.BankAccountId == accountId
                                   select result).SingleOrDefault();
            //BankAccount account = db.BankAccounts.Find(accountId);

            //update record's balance
            account.Balance += amount;

            //update account's state if necessary
            account.ChangeState();

            //commit the change to the database
            db.SaveChanges();

            //Return the updated balance. If an exception occurs, return null.
            try
            {
                return account.Balance;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Create a new transaction, and add it to Transaction table in the database.
        /// </summary>
        /// <param name="accountId">Represents the account id.</param>
        /// <param name="amount">Represents the amount of money.</param>
        /// <param name="transactionTypeId">Represents the transaction type id.</param>
        /// <param name="notes">Represents the notes.</param>
        private void CreateTransaction(int accountId, double amount, int transactionTypeId, String notes)
        {
            //Define a new transaction record
            Transaction transaction = new Transaction();

            //Set the properties of the transaction record based on the argument values.
            transaction.TransactionTypeId = transactionTypeId;
            transaction.Notes = notes;
            transaction.BankAccountId = accountId;

            if (amount < 0)
            {
                transaction.Deposit = null;
                transaction.Withdrawal = Math.Abs(amount);
            }
            else if (amount >= 0)
            {
                transaction.Deposit = amount;
                transaction.Withdrawal = null;
            }

            transaction.DateCreated = DateTime.Today;

            transaction.SetNextTransactionNumber();

            //Add the transaction object to the Transaction table in the database.
            db.Transactions.Add(transaction);

            //persist this new record to the database.
            db.SaveChanges();
        }

        public void DoWork()
        {
        }

        /// <summary>
        /// Make a deposit in the specified account.
        /// </summary>
        /// <param name="accountId">Represents for account id.</param>
        /// <param name="amount">Represents for amount of money.</param>
        /// <param name="notes">Represents for notes.</param>
        /// <returns>The new balance of the account.</returns>
        public double? Deposit(int accountId, double amount, string notes)
        {
            //Calculate new balance.
            double newBalance = (double)this.UpdateBalance(accountId, amount);

            //Add new transaction record.
            this.CreateTransaction(accountId, amount, 1, notes);

            //Return the new balance.
            try
            {
                return newBalance;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Make a withdrawal in the specified account.
        /// </summary>
        /// <param name="accountId">Represents for account id.</param>
        /// <param name="amount">Represents for amount of money.</param>
        /// <param name="notes">Represents for notes.</param>
        /// <returns>The new balance of the account.</returns>
        public double? Withdrawal(int accountId, double amount, string notes)
        {
            //Calculate new balance.
            double newBalance = (double)this.UpdateBalance(accountId, -amount);

            //Add new transaction record.
            this.CreateTransaction(accountId, -amount, 2, notes);

            //Return the new balance.
            try
            {
                return newBalance;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Make a payment in the specified account.
        /// </summary>
        /// <param name="accountId">Represents for account id.</param>
        /// <param name="amount">Represents for amount of money.</param>
        /// <param name="notes">Represents for notes.</param>
        /// <returns>The new balance of the account.</returns>
        public double? BillPayment(int accountId, double amount, string notes)
        {
            //Calculate new balance.
            double newBalance = (double)this.UpdateBalance(accountId, -amount);

            //Add new transaction record.
            this.CreateTransaction(accountId, -amount, 3, notes);

            //Return the new balance.
            try
            {
                return newBalance;
            }
            catch
            {
                return null;
            }
        }

        public double? Transfer(int fromAccountId, int toAccountId, double amount, string notes)
        {
            //Calculate new balance of the sending account.
            double newBalance = (double)this.UpdateBalance(fromAccountId, -amount);

            //Add new transaction record for the sending account.
            this.CreateTransaction(fromAccountId, -amount, 4, notes);

            //Calculate new balance of the receiving account.
            this.UpdateBalance(toAccountId, amount);

            //Add new transaction record for the receiving account.
            this.CreateTransaction(toAccountId, amount, 5, notes);

            //Return the new balance of the sending account.
            try
            {
                return newBalance;
            }
            catch
            {
                return null;
            }
        }

        public double? CalculateInterest(int accountId, string notes)
        {
            //Declare variables
            double interest;
            double interestRate;
            //double balance;
            int timePeriods = 1;
            int frequency = 12;


            //Retrieve the account record based on the accountId argument
            BankAccount account = (from result in db.BankAccounts
                                   where result.BankAccountId == accountId
                                   select result).SingleOrDefault();
            //BankAccount account = db.BankAccounts.Find(accountId);


            //Retrieve the accountState record based on the accountStateId argument
            AccountState accountState = (from result in db.AccountStates
                                         where result.AcountStateId == account.AccountStateId
                                         select result).SingleOrDefault();
            //AccountState accountState = db.AccountStates.Find(account.AccountStateId);

            //Adjust the interest rate
            interestRate = accountState.RateAdjustment(account);

            //balance = account.Balance;

            //Calculate the interest.
            interest = interestRate * account.Balance * timePeriods / frequency;

            //Calculate new balance.
            double newBalance = (double)this.UpdateBalance(accountId, interest);

            //Add new transaction record.
            this.CreateTransaction(accountId, interest, 6, notes);

            try
            {
                return newBalance;
            }
            catch
            {
                return null;
            }
        }
    }
}
