using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankOfBIT_ZD.Data;
using BankOfBIT_ZD.Models;
using Utility;

namespace WindowsBanking
{
    public partial class ProcessTransaction : Form
    {
        ConstructorData constructorData;

        BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();

        /// Form can only be opened with a Constructor Data object
        /// containing client and account details.
        /// </summary>
        /// <param name="constructorData">Populated Constructor data object.</param>
        public ProcessTransaction(ConstructorData constructorData)
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
        private void ProcessTransaction_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);

            this.lblPTAccountNumberMasked.Mask = BusinessRules.AccountFormat(constructorData.BankAccount.Description);

            try
            {
                IQueryable<TransactionType> transactionTypeList = from results in db.TransactionTypes
                                                                  where results.Description != "Transfer (Recipient)" && results.Description != "Interest"
                                                                  select results;

                this.transactionTypeBindingSource.DataSource = transactionTypeList.ToList();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTransactionType.Text == "Deposit" || this.cboTransactionType.Text == "Withdrawal")
            {
                // label and lower ComboBox invisible
                this.lblPayeeAccount.Visible = false;
                this.cboPayeeAccount.Visible = false;

                // no additional accounts label invisible
                this.lblNoAdditionalAccounts.Visible = false;

                //enable update link label
                this.lnkUpdate.Enabled = true;
            }

            if (this.cboTransactionType.Text == "Bill Payment")
            {
                // SELECT and bind all records from Payees table
                IQueryable<Payee> payeeList = from results in db.Payees
                                              select results;

                this.cboPayeeAccount.DataSource = payeeList.ToList();

                this.cboPayeeAccount.DisplayMember = "Description";
                this.cboPayeeAccount.ValueMember = "PayeeId";

                this.lblPayeeAccount.Visible = true;
                this.cboPayeeAccount.Visible = true;
                this.lblNoAdditionalAccounts.Visible = false;
                this.lnkUpdate.Enabled = true;
            }

            if (this.cboTransactionType.Text == "Transfer")
            {
                IQueryable<BankAccount> bankTransactions = from results in db.BankAccounts
                                                           where results.ClientId == constructorData.Client.ClientId
                                                           where results.AccountNumber != constructorData.BankAccount.AccountNumber
                                                           select results;

                if (bankTransactions.Count() >= 1)
                {
                    this.cboPayeeAccount.DataSource = bankTransactions.ToList();
                    this.cboPayeeAccount.DisplayMember = "AccountNumber";
                    this.cboPayeeAccount.ValueMember = "BankAccountId";

                    this.lblPayeeAccount.Visible = true;
                    this.cboPayeeAccount.Visible = true;
                    this.lblNoAdditionalAccounts.Visible = false;
                    this.lnkUpdate.Enabled = true;
                }

                else
                {
                    this.lblPayeeAccount.Visible = false;
                    this.cboPayeeAccount.Visible = false;
                    this.lblNoAdditionalAccounts.Visible = true;
                    this.lnkUpdate.Enabled = false;
                }
            }
        }

        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TransactionService.TransactionManagerClient clientProxy = new TransactionService.TransactionManagerClient();

            double? bankAccountBalance = null;

            try
            {
                if (!Numeric.IsNumeric(this.txtAmount.Text, System.Globalization.NumberStyles.Float))
                {
                    MessageBox.Show("Must enter a numeric value.", "Error");
                }

                else
                {
                    int newAccountId = constructorData.BankAccount.BankAccountId;
                    double newAmount = double.Parse(this.txtAmount.Text);

                    switch (this.cboTransactionType.Text)
                    {
                        case "Withdrawal":
                            
                            if (double.Parse(this.txtAmount.Text) > this.constructorData.BankAccount.Balance)
                            {
                                MessageBox.Show("Insufficient funds exist for requested transaction.", "Insufficient Funds");
                            }
                            else
                            {
                                bankAccountBalance = clientProxy.Withdrawal(newAccountId, newAmount, "Withdrawal");
                            }
                            break;

                         case "Deposit":
                             bankAccountBalance = clientProxy.Deposit(newAccountId, newAmount, "Deposit");
                            break;

                         case "Bill Payment":
                             if (double.Parse(this.txtAmount.Text) > this.constructorData.BankAccount.Balance)
                            {
                                MessageBox.Show("Insufficient funds exist for requested transaction.", "Insufficient Funds");
                            }
                            else
                            {
                                string notes = string.Format("Online Banking Payment to: {0}", this.cboPayeeAccount.Text);
                                bankAccountBalance = clientProxy.BillPayment(newAccountId, newAmount, notes);
                            }                                
                            break;

                        case "Transfer":
                             if (double.Parse(this.txtAmount.Text) > this.constructorData.BankAccount.Balance)
                            {
                                MessageBox.Show("Insufficient funds exist for requested transaction.", "Insufficient Funds");
                            }
                            else
                            {
                                int transferedAccountId = (int)this.cboPayeeAccount.SelectedValue;
                                string transferNotes = string.Format("Online Banking Transfer From: {0} To: {1}", constructorData.BankAccount.AccountNumber, this.cboPayeeAccount.Text);
                                bankAccountBalance = clientProxy.Transfer(newAccountId, transferedAccountId, newAmount, transferNotes);
                            }                                   
                            break;
                    }

                    if (bankAccountBalance == null)
                    {
                        MessageBox.Show("Error Completing Transaction.", "Transaction Error");
                    }
                    else
                    {
                        constructorData.BankAccount.Balance = (double)bankAccountBalance;
                        bankAccountBindingSource.ResetBindings(false);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
