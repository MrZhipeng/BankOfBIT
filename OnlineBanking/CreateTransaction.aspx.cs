using BankOfBIT_ZD.Data;
using BankOfBIT_ZD.Models;
using BankService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking
{
    public partial class CreateTransaction : System.Web.UI.Page
    {
        BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();

        /// <summary>
        /// Populate the labels, TextBox, LinkButtons and DropDownLists
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
                        txtAmount.Style.Add("text-align", "right");

                        //Set the lblAccountNumberValue label to the account number obtained from the session variable
                        lblAccountNumberValue.Text = Session["SessionAccountNumber"].ToString();

                        //Set the lblBalanceValue label to the balance of the specified account
                        BankAccount account = (BankAccount)Session["SessionAccount"];

                        lblBalanceValue.Text = account.Balance.ToString("$#.##");

                        //Bind ddlTransactionType with the results of a LINQ-to-SQL Server query against the TransactionTypes table
                        ddlTransactionType.DataSource = (from results in db.TransactionTypes
                                                         where results.TransactionTypeId == 3 || results.TransactionTypeId == 4
                                                         select results).ToList();
                        ddlTransactionType.DataTextField = "Description";
                        ddlTransactionType.DataValueField = "TransactionTypeId";
                        ddlTransactionType.DataBind();

                        //Bind ddlTo with the results of a LINQ-to-SQL Server query against the Payees table
                        ddlTo.DataSource = db.Payees.ToList();
                        ddlTo.DataTextField = "Description";
                        ddlTo.DataValueField = "PayeeId";
                        ddlTo.DataBind();
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
        /// Change the content of ddlTransactionType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlTransactionType.SelectedValue == "3")
            {
                //Clear out previous data bindings on dllTo
                ddlTo.DataSource = null;
                ddlTo.DataTextField = null;
                ddlTo.DataValueField = null;

                //Bind ddlTo with the results of a LINQ-to-SQL Server query against the Payees table
                ddlTo.DataSource = db.Payees.ToList();
                ddlTo.DataTextField = "Description";
                ddlTo.DataValueField = "PayeeId";
                ddlTo.DataBind();
            }

            else if(ddlTransactionType.SelectedValue == "4")
            {
                //Clear out previous data bindings on dllTo
                ddlTo.DataSource = null;
                ddlTo.DataTextField = null;
                ddlTo.DataValueField = null;

                //Obtain variables from session
                Client client = (Client)Session["SessionClient"];
                long accountNumber = long.Parse(Session["SessionAccountNumber"].ToString());

                //Retrieve the client's accounts except the current one
                IQueryable<BankAccount> accounts = from result in db.BankAccounts
                                                   where result.ClientId == client.ClientId && result.AccountNumber != accountNumber
                                                   select result;
                //Bind ddlTo with the results of a LINQ-to-SQL Server query against the bankAccounts table
                ddlTo.DataSource = accounts.ToList();
                ddlTo.DataTextField = "AccountNumber";
                ddlTo.DataValueField = "BankAccountId";
                ddlTo.DataBind();
            }
        }

        //Process the transaction while clicking on lbtnCompleteTransaction
        protected void lbtnCompleteTransaction_Click(object sender, EventArgs e)
        {
            //Enable the rfvAmount Validate Control
            rfvAmount.Enabled = true;

            //Ensure the data is validated
            Page.Validate();

            if(Page.IsValid)
            {
                //Compare the current balance to the requested amount, throw an exception if insufficient
                try
                {
                    double residualAmount = double.Parse(lblBalanceValue.Text) - double.Parse(txtAmount.Text);

                    if(residualAmount < 0)
                    {
                        throw new Exception();
                    }
                }

                catch(Exception)
                {
                    lblException.Text = "Insufficient funds for requested transaction.";
                    lblException.Visible = true;
                }

                //Process the transaction by calling BillPayment from WCF
                if(ddlTransactionType.SelectedValue == "3")
                {
                    try
                    {
                        BankAccount account = (BankAccount)Session["SessionAccount"];

                        int bankAccountId = account.BankAccountId;

                        double amount = double.Parse(txtAmount.Text);

                        String notes = "Online Banking Payment to : " + ddlTo.SelectedItem;

                        TransactionManager transactionManager = new TransactionManager();

                        double? transactionResult = transactionManager.BillPayment(bankAccountId, amount, notes);

                        //Throw an exception if the transaction fails
                        if (transactionResult == null)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            lblBalanceValue.Text = ((double)transactionResult).ToString("$#.##");
                        }
                    }
                    catch (Exception)
                    {

                        lblException.Text = "Transaction failed!";
                        lblException.Visible = true;
                    }
                }

                //Process the transaction by calling Transfer from WCF
                else if(ddlTransactionType.SelectedValue == "4")
                {
                    try
                    {
                        BankAccount account = (BankAccount)Session["SessionAccount"];

                        int fromAccountId = account.BankAccountId;

                        int toAccountId = int.Parse(ddlTo.SelectedValue);

                        double amount = double.Parse(txtAmount.Text);

                        String notes = "Online Banking Transfer From: " + lblAccountNumberValue.Text + " To: " + ddlTo.SelectedItem;


                        TransactionManager transactionManager = new TransactionManager();

                        double? transactionResult = transactionManager.Transfer(fromAccountId, toAccountId, amount, notes);

                        //Throw an exception if the transaction fails
                        if (transactionResult == null)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            lblBalanceValue.Text = ((double)transactionResult).ToString("$#.##");
                        }
                    }
                    catch (Exception)
                    {

                        lblException.Text = "Transaction failed!";
                        lblException.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Redirect to AccoutListing when click on lbtnReturnToAccountListing linkButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnReturnToAccountListing_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccountListing.aspx");
        }
    }
}