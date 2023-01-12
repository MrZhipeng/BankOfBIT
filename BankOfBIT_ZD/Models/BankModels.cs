/*
 * Name: Zhipeng Ding
 * Program: Business Information Technology
 * Course: ADEV-3008 Programming 3
 * Created: 2022-09-07
 * Updated: 2022-09-09
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.ModelBinding;
using Utility;
using BankOfBIT_ZD.Data;
using System.Data.SqlClient;
using System.Data;

namespace BankOfBIT_ZD.Models
{
    /// <summary>
    /// AccountState Model. Represents the AccountState table in the database
    /// </summary>
    public abstract class AccountState
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AcountStateId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [Display(Name = "Lower\nLimit")]
        public double LowerLimit { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [Display(Name = "Upper\nLimit")]
        public double UpperLimit { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:p}")]
        public double Rate { get; set; }

        [Display(Name = "Account\nState")]
        public string Description
        {
            get
            {
                return FormatName.FormatDescription(GetType().Name, "State");
            }
        }

        protected static BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();

        //navigation property
        public virtual ICollection<BankAccount> BankAccount { get; set; }

        public abstract void StateChangeCheck(BankAccount bankAccount);

        public abstract double RateAdjustment(BankAccount bankAccount);
    }

    /// <summary>
    /// BronzeState Model. Represents the BronzeState table in the database
    /// </summary>
    public class BronzeState : AccountState
    {
        private static BronzeState bronzeState;

        /// <summary>
        /// Initializes an private instance of BronzeState with lower limit, upper limit and rate.
        /// </summary>
        private BronzeState()
        {
            this.LowerLimit = 0;
            this.UpperLimit = 5000;
            this.Rate = 0.01;
        }

        /// <summary>
        /// Get the instance of bronze state.
        /// </summary>
        /// <returns>the instance of bronze state.</returns>
        public static BronzeState GetInstance()
        {
            //check whether bronzeState if null
            if(bronzeState == null)
            {
                //check whether there is a record of bronzeState in the database
                if(db.BronzeStates.SingleOrDefault() != null)
                {
                    bronzeState = db.BronzeStates.SingleOrDefault();
                }
                else
                {
                    BronzeState bronzeState = new BronzeState();
                    db.BronzeStates.Add(bronzeState);
                    db.SaveChanges();
                }
            }

            return bronzeState;
        }

        /// <summary>
        /// Check if the state should be changed, change it when necessary and save the change
        /// </summary>
        /// <param name="bankAccount"></param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if(bankAccount.Balance > this.UpperLimit)
            {
                bankAccount.AccountStateId = SilverState.GetInstance().AcountStateId;
                db.SaveChanges();
            }
        }

        public override double RateAdjustment(BankAccount bankAccount)
        {
            if(bankAccount.Balance <= 0)
            {
                this.Rate = 0.055;
            }

            return this.Rate;
        }
    }

    /// <summary>
    /// SilverState Model. Represents the SilverState table in the database
    /// </summary>
    public class SilverState : AccountState
    {
        private static SilverState silverState;

        /// <summary>
        /// Initializes an private instance of SilverState with lower limit, upper limit and rate.
        /// </summary>
        private SilverState()
        {
            this.LowerLimit = 5000;
            this.UpperLimit = 10000;
            this.Rate = 0.0125;
        }

        /// <summary>
        /// Get the instance of silver state.
        /// </summary>
        /// <returns>the instance of silver state.</returns>
        public static SilverState GetInstance()
        {
            if(silverState == null)
            {
                if(db.SilverStates.SingleOrDefault() != null)
                {
                    silverState = db.SilverStates.SingleOrDefault();
                }
                else
                {
                    SilverState silverState = new SilverState();
                    silverState = db.SilverStates.Add(silverState);
                    db.SaveChanges();
                }
            }

            return silverState;
        }

        /// <summary>
        /// Check if the state should be changed, change it when necessary and save the change
        /// </summary>
        /// <param name="bankAccount"></param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance > this.UpperLimit)
            {
                bankAccount.AccountStateId = GoldState.GetInstance().AcountStateId;
                db.SaveChanges();
            }

            else if (bankAccount.Balance < this.LowerLimit)
            {
                bankAccount.AccountStateId = BronzeState.GetInstance().AcountStateId;
                db.SaveChanges();
            }
        }

        public override double RateAdjustment(BankAccount bankAccount)
        {
            return this.Rate;
        }
    }

    /// <summary>
    /// GoldState Model. Represents the GoldState table in the database
    /// </summary>
    public class GoldState : AccountState
    {
        private static GoldState goldState;

        /// <summary>
        /// Initializes an private instance of GoldState with lower limit, upper limit and rate.
        /// </summary>
        private GoldState()
        {
            this.LowerLimit = 10000;
            this.UpperLimit = 20000;
            this.Rate = 0.02;

        }

        /// <summary>
        /// Get the instance of gold state.
        /// </summary>
        /// <returns>the instance of gold state.</returns>
        public static GoldState GetInstance()
        {
            if (goldState == null)
            {
                if(db.GoldStates.SingleOrDefault() != null)
                {
                    goldState = db.GoldStates.SingleOrDefault();
                }
                else
                {
                    GoldState goldState = new GoldState();
                    goldState = db.GoldStates.Add(goldState);
                    db.SaveChanges();
                }
            }

            return goldState;
        }

        /// <summary>
        /// Check if the state should be changed, change it when necessary and save the change
        /// </summary>
        /// <param name="bankAccount"></param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance > this.UpperLimit)
            {
                bankAccount.AccountStateId = PlatinumState.GetInstance().AcountStateId;
                db.SaveChanges();
            }

            else if (bankAccount.Balance < this.LowerLimit)
            {
                bankAccount.AccountStateId = SilverState.GetInstance().AcountStateId;
                db.SaveChanges();
            }
        }

        public override double RateAdjustment(BankAccount bankAccount)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - bankAccount.DateCreated.Month;
            int years = today.Year - bankAccount.DateCreated.Year;

            if (today.Day < bankAccount.DateCreated.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
            }

            if (years > 10)
            {
                this.Rate = this.Rate + 0.01;
            }

            return this.Rate;
        }
    }

    /// <summary>
    /// PlatinumState Model. Represents the PlatinumState table in the database
    /// </summary>
    public class PlatinumState : AccountState
    {
        private static PlatinumState platinumState;

        /// <summary>
        /// Initializes an private instance of PlatinumState with lower limit, upper limit and rate.
        /// </summary>
        private PlatinumState()
        {
            this.LowerLimit = 20000;
            this.UpperLimit = 0;
            this.Rate = 0.025;
        }

        /// <summary>
        /// Get the instance of platinum state.
        /// </summary>
        /// <returns>the instance of platinum state.</returns>
        public static PlatinumState GetInstance()
        {
            if(platinumState == null)
            {
                if(db.PlatinumStates.SingleOrDefault() != null)
                {
                    platinumState = db.PlatinumStates.SingleOrDefault();
                }
                else
                {
                    PlatinumState platinumState = new PlatinumState();
                    platinumState = db.PlatinumStates.Add(platinumState);
                    db.SaveChanges();
                }
            }

            return platinumState;
        }

        /// <summary>
        /// Check if the state should be changed, change it when necessary and save the change
        /// </summary>
        /// <param name="bankAccount"></param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance < this.LowerLimit)
            {
                bankAccount.AccountStateId = GoldState.GetInstance().AcountStateId;
                db.SaveChanges();
            }
        }

        public override double RateAdjustment(BankAccount bankAccount)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - bankAccount.DateCreated.Month;
            int years = today.Year - bankAccount.DateCreated.Year;

            if (today.Day < bankAccount.DateCreated.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
            }

            if (years > 10)
            {
                this.Rate = this.Rate + 0.01;
            }

            if(bankAccount.Balance > this.LowerLimit * 2)
            {
                this.Rate = this.Rate + 0.005;
            }

            return this.Rate;
        }
    }

    /// <summary>
    /// Client Model. Represents the Client table in the database
    /// </summary>
    public class Client
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Display(Name = "Client\nNumber")]
        public long ClientNumber { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "First\nName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "Last\nName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK|YT)", ErrorMessage = "Invalid Canadian province code!")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }
        
        public string Notes { get; set; }

        [Display(Name = "Name")]
        public string FullName 
        { 
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        [Display(Name = "Address")]
        public string FullAddress 
        {
            get
            {
                return String.Format("{0} {1} {2}", Address, City, Province);
            }
        }

        /// <summary>
        /// Set the ClientNumber to the value returned from the NextNumber method.
        /// </summary>
        public void SetNextClientNumber()
        {
            if (StoredProcedure.NextNumber("NextClient") != null)
            {
                this.ClientNumber = (long)StoredProcedure.NextNumber("NextClient");
            }
        }

        //navigation property
        public virtual ICollection<BankAccount> BankAccount { get; set; }
    }
    
    /// <summary>
    /// BankAccount Model. Represents the BankAccount table in the database
    /// </summary>
    public abstract class BankAccount
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BankAccountId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("AccountState")]
        public int AccountStateId { get; set; }

        [Display(Name = "Account\nNumber")]
        public long AccountNumber { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public double Balance { get; set; }

        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }
        
        public string Notes { get; set; }
        public string Description
        {
            get
            {
                return FormatName.FormatDescription(GetType().Name, "Account");
            }
        }

        private BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();

        /// <summary>
        /// Change state for a bank account
        /// </summary>
        public void ChangeState()
        {
            AccountState accountState;

            do
            {
                accountState = db.AccountStates.Find(this.AccountStateId);
                accountState.StateChangeCheck(this);
            }

            while (accountState.AcountStateId != this.AccountStateId);
        }

        public abstract void SetNextAccountNumber();

        //navigation properties
        public virtual AccountState AccountState { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }

    /// <summary>
    /// SavingsAccount Model. Represents the SavingsAccount table in the database
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        [Required]
        [Display(Name = "Savings\nService\nCharges")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public double SavingsServiceCharges { get; set; }

        /// <summary>
        /// Set the AccountNumber to the value returned from the NextNumber method.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            if(StoredProcedure.NextNumber("NextSavingsAccount") != null)
            {
                this.AccountNumber = (long)StoredProcedure.NextNumber("NextSavingsAccount");
            }
        }
    }

    /// <summary>
    /// MortgageAccount Model. Represents the MortgageAccount table in the database
    /// </summary>
    public class MortgageAccount : BankAccount
    {
        [Required]
        [Display(Name = "Mortgage\nRate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:p}")]
        public double MortgageRate { get; set; }

        [Required]
        public int Amortization { get; set; }

        /// <summary>
        /// Set the AccountNumber to the value returned from the NextNumber method.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            if (StoredProcedure.NextNumber("NextMortgageAccount") != null)
            {
                this.AccountNumber = (long)StoredProcedure.NextNumber("NextMortgageAccount");
            }
        }
    }

    /// <summary>
    /// InvestmentAccount Model. Represents the InvestmentAccount table in the database
    /// </summary>
    public class InvestmentAccount : BankAccount
    {
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:p}")]
        public double InterestRate { get; set; }

        /// <summary>
        /// Set the AccountNumber to the value returned from the NextNumber method.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            if (StoredProcedure.NextNumber("NextInvestmentAccount") != null)
            {
                this.AccountNumber = (long)StoredProcedure.NextNumber("NextInvestmentAccount");
            }
        }
    }

    /// <summary>
    /// ChequingAccount Model. Represents the ChequingAccount table in the database
    /// </summary>
    public class ChequingAccount : BankAccount
    {

        [Required]
        [Display(Name = "Chequing\nService\nCharges")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public double ChequingServiceCharges { get; set; }

        /// <summary>
        /// Set the AccountNumber to the value returned from the NextNumber method.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            if (StoredProcedure.NextNumber("NextChequingAccount") != null)
            {
                this.AccountNumber = (long)StoredProcedure.NextNumber("NextChequingAccount");
            }
        }
    }

    /// <summary>
    /// Payee Model. Represents the Payee table in the database
    /// </summary>
    public class Payee
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PayeeId { get; set; }

        [Required]
        [Display(Name ="Payee")]
        public String Description { get; set; }
    }

    /// <summary>
    /// Institution Model. Represents the Institution table in the database
    /// </summary>
    public class Institution
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int InstitutionId { get; set; }

        [Display(Name ="Number")]
        public int InstitutionNumber { get; set; }

        [Required]
        [Display(Name ="Institution")]
        public String Description { get; set; }
    }

    /// <summary>
    /// TransactionType Model. Represents the TransactionType table in the database
    /// </summary>
    public class TransactionType
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TransactionTypeId { get; set; }

        [Required]
        [Display(Name ="Type")]
        public String Description { get; set; }

        //navigation properties
        public virtual ICollection<Transaction> Transaction { get; set; }
    }

    /// <summary>
    /// Transaction Model. Represents the Transaction table in the database
    /// </summary>
    public class Transaction
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }

        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }

        [Display(Name ="Number")]
        public long TransactionNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Deposit { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Withdrawal { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name ="Date")]
        public DateTime DateCreated { get; set; }

        public String Notes { get; set; }

        /// <summary>
        /// Set the TransactionNumber to the value returned from the NextNumber method.
        /// </summary>
        public void SetNextTransactionNumber()
        {
            if (StoredProcedure.NextNumber("NextTransaction") != null)
            {
                this.TransactionNumber = (long)StoredProcedure.NextNumber("NextTransaction");
            }
        }

        //navigation properties
        public virtual BankAccount BankAccount { get; set; }

        public virtual TransactionType TransactionType { get; set; }
    }

    /// <summary>
    /// NextUniqueNumber Model. Represents the NextUniqueNumber table in the database
    /// </summary>
    public abstract class NextUniqueNumber
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NextUniqueNumberId { get; set; }

        [Required]
        public long NextAvailableNumber { get; set; }

        protected static BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();
    }

    /// <summary>
    /// NextSavingsAccount Model. Represents the NextSavingsAccount table in the database
    /// </summary>
    public class NextSavingsAccount : NextUniqueNumber
    {
        private static NextSavingsAccount nextSavingsAccount;

        /// <summary>
        /// Initialize a private instance of the NextSavingsAccount class.
        /// </summary>
        private NextSavingsAccount()
        {
            this.NextAvailableNumber = 20000;
        }

        /// <summary>
        /// Get the instance of the NextSavingsAccount class.
        /// </summary>
        /// <returns>the instance of the NextSavingsAccount class</returns>
        public static NextSavingsAccount GetInstance()
        {
            if (nextSavingsAccount == null)
            {
                if (db.NextSavingsAccounts.SingleOrDefault() != null)
                {
                    nextSavingsAccount = db.NextSavingsAccounts.SingleOrDefault();
                }
                else
                {
                    NextSavingsAccount nextSavingsAccount = new NextSavingsAccount();
                    nextSavingsAccount = db.NextSavingsAccounts.Add(nextSavingsAccount);
                    db.SaveChanges();
                }
            }
            return nextSavingsAccount;
        }
    }

    /// <summary>
    /// NextMortgageAccount Model. Represents the NextMortgageAccount table in the database
    /// </summary>
    public class NextMortgageAccount : NextUniqueNumber
    {
        private static NextMortgageAccount nextMortgageAccount;

        /// <summary>
        /// Initialize a private instance of the NextMortgageAccount class.
        /// </summary>
        private NextMortgageAccount()
        {
            this.NextAvailableNumber = 200000;
        }

        /// <summary>
        /// Get the instance of the NextMortgageAccount class.
        /// </summary>
        /// <returns>the instance of the NextMortgageAccount class</returns>
        public static NextMortgageAccount GetInstance()
        {
            if (nextMortgageAccount == null)
            {
                if (db.NextMortgageAccounts.SingleOrDefault() != null)
                {
                    nextMortgageAccount = db.NextMortgageAccounts.SingleOrDefault();
                }
                else
                {
                    NextMortgageAccount nextMortgageAccount = new NextMortgageAccount();
                    nextMortgageAccount = db.NextMortgageAccounts.Add(nextMortgageAccount);
                    db.SaveChanges();
                }
            }
            return nextMortgageAccount;
        }
    }

    /// <summary>
    /// NextInvestmentAccount Model. Represents the NextInvestmentAccount table in the database
    /// </summary>
    public class NextInvestmentAccount : NextUniqueNumber
    {
        private static NextInvestmentAccount nextInvestmentAccount;

        /// <summary>
        /// Initialize a private instance of the NextInvestmentAccount class.
        /// </summary>
        private NextInvestmentAccount()
        {
            this.NextAvailableNumber = 2000000;
        }

        /// <summary>
        /// Get the instance of the NextInvestmentAccount class.
        /// </summary>
        /// <returns>instance of the NextInvestmentAccount class</returns>
        public static NextInvestmentAccount GetInstance()
        {
            if (nextInvestmentAccount == null)
            {
                if (db.NextInvestmentAccounts.SingleOrDefault() != null)
                {
                    nextInvestmentAccount = db.NextInvestmentAccounts.SingleOrDefault();
                }
                else
                {
                    NextInvestmentAccount nextInvestmentAccount = new NextInvestmentAccount();
                    nextInvestmentAccount = db.NextInvestmentAccounts.Add(nextInvestmentAccount);
                    db.SaveChanges();
                }
            }
            return nextInvestmentAccount;
        }
    }

    /// <summary>
    /// NextChequingAccount Model. Represents the NextChequingAccount table in the database
    /// </summary>
    public class NextChequingAccount : NextUniqueNumber
    {
        private static NextChequingAccount nextChequingAccount;

        /// <summary>
        /// Initialize a private instance of the NextChequingAccount class.
        /// </summary>
        private NextChequingAccount()
        {
            this.NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Get the instance of the NextChequingAccount class.
        /// </summary>
        /// <returns>instance of the NextChequingAccount class</returns>
        public static NextChequingAccount GetInstance()
        {
            if (nextChequingAccount == null)
            {
                if (db.NextChequingAccounts.SingleOrDefault() != null)
                {
                    nextChequingAccount = db.NextChequingAccounts.SingleOrDefault();
                }
                else
                {
                    NextChequingAccount nextChequingAccount = new NextChequingAccount();
                    nextChequingAccount = db.NextChequingAccounts.Add(nextChequingAccount);
                    db.SaveChanges();
                }
            }
            return nextChequingAccount;
        }
    }

    /// <summary>
    /// NextClient Model. Represents the NextClient table in the database
    /// </summary>
    public class NextClient : NextUniqueNumber
    {
        private static NextClient nextClient;

        /// <summary>
        /// Initialize a private instance of the NextClient class.
        /// </summary>
        private NextClient()
        {
            this.NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Get the instance of the NextClient class.
        /// </summary>
        /// <returns>instance of the NextClient class</returns>
        public static NextClient GetInstance()
        {
            if (nextClient == null)
            {
                if (db.NextClients.SingleOrDefault() != null)
                {
                    nextClient = db.NextClients.SingleOrDefault();
                }
                else
                {
                    NextClient nextClient = new NextClient();
                    nextClient = db.NextClients.Add(nextClient);
                    db.SaveChanges();
                }
            }

            return nextClient;
        }
    }

    /// <summary>
    /// NextTransaction Model. Represents the NextTransaction table in the database
    /// </summary>
    public class NextTransaction : NextUniqueNumber
    {
        private static NextTransaction nextTransaction;

        /// <summary>
        /// Initialize a private instance of the NextTransaction class.
        /// </summary>
        private NextTransaction()
        {
            this.NextAvailableNumber = 700;
        }

        /// <summary>
        /// Get the instance of the NextTransaction class.
        /// </summary>
        /// <returns>instance of the NextTransaction class</returns>
        public static NextTransaction GetInstance()
        {
            if (nextTransaction == null)
            {
                if (db.NextTransactions.SingleOrDefault() != null)
                {
                    nextTransaction = db.NextTransactions.SingleOrDefault();
                }
                else
                {
                    NextTransaction nextTransaction = new NextTransaction();
                    nextTransaction = db.NextTransactions.Add(nextTransaction);
                    db.SaveChanges();
                }
            }
            return nextTransaction;
        }
    }

    /// <summary>
    /// StoredProcedure Model. Represents the stored procedure in the database.
    /// </summary>
    public static class StoredProcedure
    {
        /// <summary>
        /// Increment the NextAvaliableNumber variable of the specified class by one.
        /// </summary>
        /// <param name="discriminator">The specified class which's NextAvaliableNumber variable need to be incremented.</param>
        /// <returns>The incremented value of the NextAvaliableNumber variable.</returns>
        public static long? NextNumber(String discriminator)
        {
            try
            {
                //declare a connection to the database
                SqlConnection connection = new SqlConnection("Data Source=localhost; " +
                    "Initial Catalog=BankOfBIT_ZDContext;Integrated Security=True");

                //declare a variable
                long? returnValue = 0;

                //define a sql command, assign type and parameter to it
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);
                storedProcedure.CommandType = CommandType.StoredProcedure;
                storedProcedure.Parameters.AddWithValue("@Discriminator", discriminator);

                //define an output parameter and add it to the command
                SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                storedProcedure.Parameters.Add(outputParameter);

                //open the connection, run the sql command above and close it.
                connection.Open();
                storedProcedure.ExecuteNonQuery();
                connection.Close();
                
                //assign value to the returnValue variable and return it.
                returnValue = (long?)outputParameter.Value;
                return returnValue;
            }
            //returns null if any exception occurs.
            catch
            {
                return null;
            }
            
        }
    }
}