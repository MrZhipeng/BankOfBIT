namespace BankOfBIT_ZD.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BankOfBIT_ZD.Data.BankOfBIT_ZDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BankOfBIT_ZD.Data.BankOfBIT_ZDContext";
        }

        protected override void Seed(BankOfBIT_ZD.Data.BankOfBIT_ZDContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
