using BankOfBIT_ZD.Data;
using BankOfBIT_ZD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsBanking
{
    public partial class ClientData : Form
    {
        ConstructorData constructorData = new ConstructorData();
        BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();

        /// <summary>
        /// This constructor will execute when the form is opened
        /// from the MDI Frame.
        /// </summary>
        public ClientData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This constructor will execute when the form is opened by
        /// returning from the History or Transaction forms.
        /// </summary>
        /// <param name="constructorData">Populated ConstructorData object.</param>
        public ClientData(ConstructorData constructorData)
        {
            //Given:
            InitializeComponent();
            this.constructorData = constructorData;

            //More code to be added:
            this.txtClientNumberMasked.Text = constructorData.Client.ClientNumber.ToString();

            txtClientNumberMasked_leave(null, null);
        }

        /// <summary>
        /// Open the Transaction form passing ConstructorData object.
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Given, more code to be added.
            this.constructorData.Client = (Client)clientBindingSource.Current;
            this.constructorData.BankAccount = (BankAccount)bankAccountBindingSource.Current;

            ProcessTransaction transaction = new ProcessTransaction(constructorData);
            transaction.MdiParent = this.MdiParent;
            transaction.Show();
            this.Close();
        }

        /// <summary>
        /// Open the History form passing ConstructorData object.
        /// </summary>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Given, more code to be added.
            this.constructorData.Client = (Client)clientBindingSource.Current;
            this.constructorData.BankAccount = (BankAccount)bankAccountBindingSource.Current;

            History history = new History(constructorData);
            history.MdiParent = this.MdiParent;
            history.Show();
            this.Close();
        }

        /// <summary>
        /// Always display the form in the top right corner of the frame.
        /// </summary>
        private void ClientData_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
        }

        /// <summary>
        /// Represents data from the Clients Number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClientNumberMasked_leave(object sender, EventArgs e)
        {
            int clientNumber = int.Parse(txtClientNumberMasked.Text);

            Client clients = (from results in db.Clients
                              where results.ClientNumber == clientNumber
                              select results).SingleOrDefault();

            if (clients == null)
            {
                // Initialize variables to pass to MessageBox.Show
                string caption = "Invalid Client Number";
                string message = String.Format("Client Number: {0} does not exist.", clientNumber);

                // Displays MessageBox
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }

                this.lnkProcess.Enabled = false;
                this.lnkDetails.Enabled = false;

                // focus
                this.txtClientNumberMasked.Focus();

                this.clientBindingSource.DataSource = typeof(Client);
            }

            else
            {
                this.clientBindingSource.DataSource = clients;

                IQueryable<BankAccount> clientBankAccount = from results in db.BankAccounts
                                                            where results.ClientId == clients.ClientId
                                                            select results;

                if (clientBankAccount == null)
                {
                    this.lnkProcess.Enabled = false;
                    this.lnkDetails.Enabled = false;
                    this.bankAccountBindingSource.DataSource = typeof(BankAccount);
                }

                else
                {
                    this.bankAccountBindingSource.DataSource = clientBankAccount.ToList();
                    this.lnkProcess.Enabled = true;
                    this.lnkDetails.Enabled = true;
                }
            }
        }
    }
}
