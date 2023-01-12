using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankOfBIT_ZD.Data
{
    public class BankOfBIT_ZDContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BankOfBIT_ZDContext() : base("name=BankOfBIT_ZDContext")
        {
        }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.AccountState> AccountStates { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.BronzeState> BronzeStates { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.SilverState> SilverStates { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.GoldState> GoldStates { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.PlatinumState> PlatinumStates { get; set; }


        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.BankAccount> BankAccounts { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.SavingsAccount> SavingsAccounts { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.MortgageAccount> MortgageAccounts { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.InvestmentAccount> InvestmentAccounts { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.ChequingAccount> ChequingAccounts { get; set; }


        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.Institution> Institutions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.Payee> Payees { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.NextUniqueNumber> NextUniqueNumbers { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.NextSavingsAccount> NextSavingsAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.NextMortgageAccount> NextMortgageAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.NextInvestmentAccount> NextInvestmentAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.NextChequingAccount> NextChequingAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.NextTransaction> NextTransactions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.NextClient> NextClients { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.TransactionType> TransactionTypes { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_ZD.Models.Transaction> Transactions { get; set; }
    }
}
