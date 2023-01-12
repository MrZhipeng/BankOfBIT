namespace WindowsBanking
{
    partial class ProcessTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label descriptionLabel;
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.lblPTBalance = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblPTFullName = new System.Windows.Forms.Label();
            this.lblPTAccountNumberMasked = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblPTClientNumMasked = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.grpTransaction = new System.Windows.Forms.GroupBox();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.transactionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.cboPayeeAccount = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblPayeeAccount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoAdditionalAccounts = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            this.grpClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.grpTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(93, 27);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(89, 12);
            clientNumberLabel.TabIndex = 0;
            clientNumberLabel.Text = "Client Number:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(94, 60);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(95, 12);
            accountNumberLabel.TabIndex = 2;
            accountNumberLabel.Text = "Account Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(381, 27);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(65, 12);
            fullNameLabel.TabIndex = 4;
            fullNameLabel.Text = "Full Name:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(381, 60);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(53, 12);
            balanceLabel.TabIndex = 6;
            balanceLabel.Text = "Balance:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(185, 66);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(107, 12);
            descriptionLabel.TabIndex = 7;
            descriptionLabel.Text = "Transaction Type:";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(balanceLabel);
            this.grpClient.Controls.Add(this.lblPTBalance);
            this.grpClient.Controls.Add(fullNameLabel);
            this.grpClient.Controls.Add(this.lblPTFullName);
            this.grpClient.Controls.Add(accountNumberLabel);
            this.grpClient.Controls.Add(this.lblPTAccountNumberMasked);
            this.grpClient.Controls.Add(clientNumberLabel);
            this.grpClient.Controls.Add(this.lblPTClientNumMasked);
            this.grpClient.Location = new System.Drawing.Point(47, 44);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(694, 102);
            this.grpClient.TabIndex = 0;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Data";
            // 
            // lblPTBalance
            // 
            this.lblPTBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPTBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblPTBalance.Location = new System.Drawing.Point(452, 59);
            this.lblPTBalance.Name = "lblPTBalance";
            this.lblPTBalance.Size = new System.Drawing.Size(147, 23);
            this.lblPTBalance.TabIndex = 7;
            this.lblPTBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_ZD.Models.BankAccount);
            // 
            // lblPTFullName
            // 
            this.lblPTFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPTFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Client.FullName", true));
            this.lblPTFullName.Location = new System.Drawing.Point(452, 27);
            this.lblPTFullName.Name = "lblPTFullName";
            this.lblPTFullName.Size = new System.Drawing.Size(147, 23);
            this.lblPTFullName.TabIndex = 5;
            // 
            // lblPTAccountNumberMasked
            // 
            this.lblPTAccountNumberMasked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPTAccountNumberMasked.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.lblPTAccountNumberMasked.Location = new System.Drawing.Point(195, 60);
            this.lblPTAccountNumberMasked.Name = "lblPTAccountNumberMasked";
            this.lblPTAccountNumberMasked.Size = new System.Drawing.Size(100, 23);
            this.lblPTAccountNumberMasked.TabIndex = 3;
            // 
            // lblPTClientNumMasked
            // 
            this.lblPTClientNumMasked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPTClientNumMasked.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Client.ClientNumber", true));
            this.lblPTClientNumMasked.Location = new System.Drawing.Point(195, 27);
            this.lblPTClientNumMasked.Mask = "0000-0000";
            this.lblPTClientNumMasked.Name = "lblPTClientNumMasked";
            this.lblPTClientNumMasked.Size = new System.Drawing.Size(100, 23);
            this.lblPTClientNumMasked.TabIndex = 1;
            this.lblPTClientNumMasked.Text = "    -";
            // 
            // grpTransaction
            // 
            this.grpTransaction.Controls.Add(descriptionLabel);
            this.grpTransaction.Controls.Add(this.cboTransactionType);
            this.grpTransaction.Controls.Add(this.lnkReturn);
            this.grpTransaction.Controls.Add(this.lnkUpdate);
            this.grpTransaction.Controls.Add(this.cboPayeeAccount);
            this.grpTransaction.Controls.Add(this.txtAmount);
            this.grpTransaction.Controls.Add(this.lblPayeeAccount);
            this.grpTransaction.Controls.Add(this.label1);
            this.grpTransaction.Controls.Add(this.lblNoAdditionalAccounts);
            this.grpTransaction.Location = new System.Drawing.Point(47, 173);
            this.grpTransaction.Name = "grpTransaction";
            this.grpTransaction.Size = new System.Drawing.Size(694, 193);
            this.grpTransaction.TabIndex = 1;
            this.grpTransaction.TabStop = false;
            this.grpTransaction.Text = "Perform Transaction";
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionTypeBindingSource, "Description", true));
            this.cboTransactionType.DataSource = this.transactionTypeBindingSource;
            this.cboTransactionType.DisplayMember = "Description";
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(302, 63);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(202, 20);
            this.cboTransactionType.TabIndex = 8;
            this.cboTransactionType.ValueMember = "TransactionTypeId";
            this.cboTransactionType.SelectedIndexChanged += new System.EventHandler(this.cboTransactionType_SelectedIndexChanged);
            // 
            // transactionTypeBindingSource
            // 
            this.transactionTypeBindingSource.DataSource = typeof(BankOfBIT_ZD.Models.TransactionType);
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(319, 161);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(101, 12);
            this.lnkReturn.TabIndex = 5;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Client";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Location = new System.Drawing.Point(221, 161);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(41, 12);
            this.lnkUpdate.TabIndex = 4;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // cboPayeeAccount
            // 
            this.cboPayeeAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayeeAccount.FormattingEnabled = true;
            this.cboPayeeAccount.Location = new System.Drawing.Point(303, 119);
            this.cboPayeeAccount.Name = "cboPayeeAccount";
            this.cboPayeeAccount.Size = new System.Drawing.Size(201, 20);
            this.cboPayeeAccount.TabIndex = 3;
            this.cboPayeeAccount.Visible = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(303, 90);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(201, 21);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPayeeAccount
            // 
            this.lblPayeeAccount.AutoSize = true;
            this.lblPayeeAccount.Location = new System.Drawing.Point(218, 119);
            this.lblPayeeAccount.Name = "lblPayeeAccount";
            this.lblPayeeAccount.Size = new System.Drawing.Size(41, 12);
            this.lblPayeeAccount.TabIndex = 1;
            this.lblPayeeAccount.Text = "Payee:";
            this.lblPayeeAccount.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount:";
            // 
            // lblNoAdditionalAccounts
            // 
            this.lblNoAdditionalAccounts.Location = new System.Drawing.Point(300, 141);
            this.lblNoAdditionalAccounts.Name = "lblNoAdditionalAccounts";
            this.lblNoAdditionalAccounts.Size = new System.Drawing.Size(207, 30);
            this.lblNoAdditionalAccounts.TabIndex = 6;
            this.lblNoAdditionalAccounts.Text = "No accounts available to receive transfer.";
            this.lblNoAdditionalAccounts.Visible = false;
            // 
            // ProcessTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.grpTransaction);
            this.Controls.Add(this.grpClient);
            this.Name = "ProcessTransaction";
            this.Text = "ProcessTransaction";
            this.Load += new System.EventHandler(this.ProcessTransaction_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.grpTransaction.ResumeLayout(false);
            this.grpTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.GroupBox grpTransaction;
        private System.Windows.Forms.Label lblNoAdditionalAccounts;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.ComboBox cboPayeeAccount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblPayeeAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPTBalance;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label lblPTFullName;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblPTAccountNumberMasked;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblPTClientNumMasked;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.BindingSource transactionTypeBindingSource;
    }
}