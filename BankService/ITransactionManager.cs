using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionManager" in both code and config file together.
    [ServiceContract]
    public interface ITransactionManager
    {
        [OperationContract]
        void DoWork();

        /// <summary>
        /// Implementation will make a deposit in the specified account.
        /// </summary>
        /// <param name="accountId">Represents the account id.</param>
        /// <param name="amount">Represents the amount of money.</param>
        /// <param name="notes">Represents the notes.</param>
        /// <returns></returns>
        [OperationContract]
        double? Deposit(int accountId, double amount, String notes);

        /// <summary>
        /// Implementation will make a withdrawal in the specified account.
        /// </summary>
        /// <param name="accountId">Represents the account id.</param>
        /// <param name="amount">Represents the amount of money.</param>
        /// <param name="notes">Represents the notes.</param>
        /// <returns></returns>
        [OperationContract]
        double? Withdrawal(int accountId, double amount, String notes);

        /// <summary>
        /// Implementation will make a bill payment using the specified account.
        /// </summary>
        /// <param name="accountId">Represents the account id.</param>
        /// <param name="amount">Represents the amount of money.</param>
        /// <param name="notes">Represents the notes.</param>
        /// <returns></returns>
        [OperationContract]
        double? BillPayment(int accountId, double amount, String notes);

        /// <summary>
        /// Implementation will transfer money from the specified account to another specified account.
        /// </summary>
        /// <param name="fromAccountId">Represents the from account id.</param>
        /// <param name="toAccountId">Represents the to account id.</param>
        /// <param name="amount">Represents the amount of money.</param>
        /// <param name="notes">Represents the notes.</param>
        /// <returns></returns>
        [OperationContract]
        double? Transfer(int fromAccountId, int toAccountId, double amount, String notes);

        /// <summary>
        /// Implementation will calculate the interest for the specified account.
        /// </summary>
        /// <param name="accountId">Represents the account id.</param>
        /// <param name="notes">Represents the notes.</param>
        /// <returns></returns>
        [OperationContract]
        double? CalculateInterest(int accountId, String notes);
    }
}
