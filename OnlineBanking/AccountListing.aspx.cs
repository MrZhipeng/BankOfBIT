using BankOfBIT_ZD.Data;
using BankOfBIT_ZD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking
{
    public partial class AccountListing : System.Web.UI.Page
    {
        BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();

        /// <summary>
        /// Populate the label and GridView.
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
                        //Obtain the client number from user's log on id.
                        String Email = Page.User.Identity.Name;
                        int location = Email.IndexOf("@");
                        long clientNumber = long.Parse(Email.Substring(0, location));

                        //Retrieve the record from Clients table based on the ClientNumber argument.
                        Client client = (from result in db.Clients
                                         where result.ClientNumber == clientNumber
                                         select result).SingleOrDefault();

                        //Save the client record into a session variable.
                        Session["SessionClient"] = client;

                        //Set the lblClientName label to the full name of the Client object.
                        lblClientName.Text = client.FullName;

                        //Retrieve the records from BankAccount table based on the ClientId argument
                        IQueryable<BankAccount> accounts = from result in db.BankAccounts
                                                           where result.ClientId == client.ClientId
                                                           select result;

                        //Bind the accounts to the GridView control.
                        gvAccounts.DataSource = accounts.ToList();

                        //Save the accounts collection into a session variable.
                        Session["SessionAccounts"] = accounts;

                        this.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                lblException.Text = ex.Message;
                lblException.Visible = true;
            }
        }

        protected void gvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SessionAccountNumber"] = gvAccounts.Rows[gvAccounts.SelectedIndex].Cells[1].Text;
            Response.Redirect("~/TransactionListing");
        }
    }
}