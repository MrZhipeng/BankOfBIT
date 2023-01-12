using BankOfBIT_ZD.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankOfBIT_ZD.Models;

namespace OnlineBanking
{
    public partial class TransactionListing : System.Web.UI.Page
    {
        BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();
        
        /// <summary>
        /// Populate the labels and GridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!this.Page.User.Identity.IsAuthenticated)
                    {
                        Response.Redirect("~/Account/Login.aspx");
                    }
                    else
                    {
                        //Obtain the client record from the Session variable created in AccountListing web form
                        Client client = (Client)Session["SessionClient"];

                        //Set the lblClientName label to the full name of the Client object.
                        lblClientName.Text = client.FullName;

                        lblAccountNumber.Text = "Account Number:  ";

                        //Set the lblAccountNumberValue label to the account number obtained from the session variable
                        lblAccountNumberValue.Text = Session["SessionAccountNumber"].ToString();

                        lblBalance.Text = "Balance:  ";

                        //Obtain the accountNumber from the session variable
                        long accountNumber = long.Parse(Session["SessionAccountNumber"].ToString());

                        BankAccount account = (from result in db.BankAccounts
                                               where result.AccountNumber == accountNumber
                                               select result).SingleOrDefault();

                        Session["SessionAccount"] = account;

                        //Set the lblBalanceValue label to the balance of the specified account
                        //lblBalanceValue.Text = db.BankAccounts
                        //    .Where(x => x.AccountNumber == accountNumber)
                        //    .Select(x => x.Balance).SingleOrDefault().ToString("$#.##");

                        lblBalanceValue.Text = account.Balance.ToString("$#.##");

                        //Bind the Transactions to the gvTransactionList
                        //int bankAccountId = (from result in db.BankAccounts
                        //                     where result.AccountNumber == accountNumber
                        //                     select result.BankAccountId).SingleOrDefault();

                        IQueryable<Transaction> transactions = from results in db.Transactions
                                                               where results.BankAccountId == account.BankAccountId
                                                               select results;

                        gvTransactionList.DataSource = transactions.ToList();
                        gvTransactionList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                lblException.Text = ex.Message;
                lblException.Visible = true;
            }
        }

        /// <summary>
        /// Redirect to CreateTransaction web form by click the link button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateTransaction.aspx");
        }

        /// <summary>
        /// Redirect to AccountListing web form by click the link button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAccountListing_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccountListing.aspx");
        }
    }
}