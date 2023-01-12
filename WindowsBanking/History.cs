using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankOfBIT_ZD.Models;
using BankOfBIT_ZD.Data;
using Utility;

namespace WindowsBanking
{
    public partial class History : Form
    {
        ConstructorData constructorData;
        BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();


        /// <summary>
        /// Form can only be opened with a Constructor Data object
        /// containing client and account details.
        /// </summary>
        /// <param name="constructorData">Populated Constructor data object.</param>
        public History(ConstructorData constructorData)
        {
            //Given, more code to be added.
            InitializeComponent();
            this.constructorData = constructorData;

            this.bankAccountBindingSource.DataSource = constructorData.BankAccount;

        }


        /// <summary>
        /// Return to the Client Data form passing specific client and 
        /// account information within ConstructorData.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientData client = new ClientData(constructorData);
            client.MdiParent = this.MdiParent;
            client.Show();
            this.Close();
        }
        /// <summary>
        /// Always display the form in the top right corner of the frame.
        /// </summary>
        private void History_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            try
            {
                this.lblAccNumberMasked.Mask = BusinessRules.AccountFormat(constructorData.BankAccount.Description);

                var transactionHistory =
                    from results in db.Transactions
                    where constructorData.BankAccount.BankAccountId == results.BankAccountId
                    join trans in db.TransactionTypes on results.TransactionTypeId equals trans.TransactionTypeId
                    select new
                    {
                        DateCreated = results.DateCreated,
                        TransactionType = trans.Description,
                        Deposit = results.Deposit,
                        Withdrawal = results.Withdrawal,
                        Notes = results.Notes
                    };

                this.transactionBindingSource.DataSource = transactionHistory.ToList();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
