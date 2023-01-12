namespace WindowsBanking
{
    partial class ClientData
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
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label fullAddressLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label notesLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label descriptionLabel2;
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.txtClientNumberMasked = new System.Windows.Forms.MaskedTextBox();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblFullAddress = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.cbAccountNumber = new System.Windows.Forms.ComboBox();
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            fullNameLabel = new System.Windows.Forms.Label();
            fullAddressLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            descriptionLabel2 = new System.Windows.Forms.Label();
            this.grpClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.grpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(65, 50);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(65, 12);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Full Name:";
            // 
            // fullAddressLabel
            // 
            fullAddressLabel.AutoSize = true;
            fullAddressLabel.Location = new System.Drawing.Point(65, 82);
            fullAddressLabel.Name = "fullAddressLabel";
            fullAddressLabel.Size = new System.Drawing.Size(83, 12);
            fullAddressLabel.TabIndex = 4;
            fullAddressLabel.Text = "Full Address:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(65, 114);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(83, 12);
            dateCreatedLabel.TabIndex = 6;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(65, 17);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(89, 12);
            clientNumberLabel.TabIndex = 7;
            clientNumberLabel.Text = "Client Number:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(65, 31);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(95, 12);
            accountNumberLabel.TabIndex = 2;
            accountNumberLabel.Text = "Account Number:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(421, 61);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(83, 12);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Account Type:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(65, 101);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(41, 12);
            notesLabel.TabIndex = 6;
            notesLabel.Text = "Notes:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(445, 28);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(53, 12);
            balanceLabel.TabIndex = 8;
            balanceLabel.Text = "Balance:";
            // 
            // descriptionLabel2
            // 
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Location = new System.Drawing.Point(65, 64);
            descriptionLabel2.Name = "descriptionLabel2";
            descriptionLabel2.Size = new System.Drawing.Size(41, 12);
            descriptionLabel2.TabIndex = 10;
            descriptionLabel2.Text = "State:";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(clientNumberLabel);
            this.grpClient.Controls.Add(this.txtClientNumberMasked);
            this.grpClient.Controls.Add(dateCreatedLabel);
            this.grpClient.Controls.Add(this.lblDateCreated);
            this.grpClient.Controls.Add(fullAddressLabel);
            this.grpClient.Controls.Add(this.lblFullAddress);
            this.grpClient.Controls.Add(fullNameLabel);
            this.grpClient.Controls.Add(this.lblFullName);
            this.grpClient.Location = new System.Drawing.Point(55, 23);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(677, 157);
            this.grpClient.TabIndex = 0;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Data";
            // 
            // txtClientNumberMasked
            // 
            this.txtClientNumberMasked.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.txtClientNumberMasked.Location = new System.Drawing.Point(164, 14);
            this.txtClientNumberMasked.Mask = "0000-0000";
            this.txtClientNumberMasked.Name = "txtClientNumberMasked";
            this.txtClientNumberMasked.Size = new System.Drawing.Size(100, 21);
            this.txtClientNumberMasked.TabIndex = 0;
            this.txtClientNumberMasked.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtClientNumberMasked.Leave += new System.EventHandler(this.txtClientNumberMasked_leave);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT_ZD.Models.Client);
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateCreated.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "DateCreated", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.lblDateCreated.Location = new System.Drawing.Point(162, 114);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(102, 23);
            this.lblDateCreated.TabIndex = 7;
            // 
            // lblFullAddress
            // 
            this.lblFullAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullAddress", true));
            this.lblFullAddress.Location = new System.Drawing.Point(162, 81);
            this.lblFullAddress.Name = "lblFullAddress";
            this.lblFullAddress.Size = new System.Drawing.Size(442, 23);
            this.lblFullAddress.TabIndex = 5;
            // 
            // lblFullName
            // 
            this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.lblFullName.Location = new System.Drawing.Point(162, 50);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(442, 23);
            this.lblFullName.TabIndex = 3;
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(descriptionLabel2);
            this.grpAccount.Controls.Add(this.lblState);
            this.grpAccount.Controls.Add(balanceLabel);
            this.grpAccount.Controls.Add(this.lblBalance);
            this.grpAccount.Controls.Add(notesLabel);
            this.grpAccount.Controls.Add(this.lblNotes);
            this.grpAccount.Controls.Add(descriptionLabel);
            this.grpAccount.Controls.Add(this.lblAccountType);
            this.grpAccount.Controls.Add(accountNumberLabel);
            this.grpAccount.Controls.Add(this.cbAccountNumber);
            this.grpAccount.Controls.Add(this.lnkDetails);
            this.grpAccount.Controls.Add(this.lnkProcess);
            this.grpAccount.Location = new System.Drawing.Point(55, 174);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(677, 206);
            this.grpAccount.TabIndex = 1;
            this.grpAccount.TabStop = false;
            this.grpAccount.Text = "Bank Account Data";
            // 
            // lblState
            // 
            this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountState.Description", true));
            this.lblState.Location = new System.Drawing.Point(162, 64);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(102, 23);
            this.lblState.TabIndex = 11;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_ZD.Models.BankAccount);
            // 
            // lblBalance
            // 
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblBalance.Location = new System.Drawing.Point(504, 28);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(100, 23);
            this.lblBalance.TabIndex = 9;
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNotes
            // 
            this.lblNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Notes", true));
            this.lblNotes.Location = new System.Drawing.Point(162, 101);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(442, 56);
            this.lblNotes.TabIndex = 7;
            // 
            // lblAccountType
            // 
            this.lblAccountType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccountType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Description", true));
            this.lblAccountType.Location = new System.Drawing.Point(504, 61);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(100, 23);
            this.lblAccountType.TabIndex = 5;
            // 
            // cbAccountNumber
            // 
            //this.cbAccountNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.cbAccountNumber.DataSource = this.bankAccountBindingSource;
            this.cbAccountNumber.DisplayMember = "AccountNumber";
            this.cbAccountNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountNumber.FormattingEnabled = true;
            this.cbAccountNumber.Location = new System.Drawing.Point(162, 28);
            this.cbAccountNumber.Name = "cbAccountNumber";
            this.cbAccountNumber.Size = new System.Drawing.Size(102, 20);
            this.cbAccountNumber.TabIndex = 3;
            this.cbAccountNumber.ValueMember = "BankAccountId";
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Enabled = false;
            this.lnkDetails.Location = new System.Drawing.Point(385, 170);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(77, 12);
            this.lnkDetails.TabIndex = 1;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Enabled = false;
            this.lnkProcess.Location = new System.Drawing.Point(160, 170);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(119, 12);
            this.lnkProcess.TabIndex = 0;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Transaction";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // ClientData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.grpAccount);
            this.Controls.Add(this.grpClient);
            this.Name = "ClientData";
            this.Text = "ClientData";
            this.Load += new System.EventHandler(this.ClientData_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.MaskedTextBox txtClientNumberMasked;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblFullAddress;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.ComboBox cbAccountNumber;
    }
}