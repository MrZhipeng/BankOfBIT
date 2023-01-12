namespace WindowsBanking
{
    partial class History
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label balanceLabel;
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.transactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAccNumberMasked = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblClientNumMasked = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lblHistoryFullName = new System.Windows.Forms.Label();
            this.lblHistoryBalance = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            this.grpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(balanceLabel);
            this.grpAccount.Controls.Add(this.lblHistoryBalance);
            this.grpAccount.Controls.Add(fullNameLabel);
            this.grpAccount.Controls.Add(this.lblHistoryFullName);
            this.grpAccount.Controls.Add(clientNumberLabel);
            this.grpAccount.Controls.Add(this.lblClientNumMasked);
            this.grpAccount.Controls.Add(accountNumberLabel);
            this.grpAccount.Controls.Add(this.lblAccNumberMasked);
            this.grpAccount.Location = new System.Drawing.Point(43, 34);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(708, 120);
            this.grpAccount.TabIndex = 0;
            this.grpAccount.TabStop = false;
            this.grpAccount.Text = "Account Data";
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(385, 372);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(101, 12);
            this.lnkReturn.TabIndex = 1;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Client";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // transactionBindingSource
            // 
            this.transactionBindingSource.DataSource = typeof(BankOfBIT_ZD.Models.Transaction);
            // 
            // transactionDataGridView
            // 
            this.transactionDataGridView.AutoGenerateColumns = false;
            this.transactionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8});
            this.transactionDataGridView.DataSource = this.transactionBindingSource;
            this.transactionDataGridView.Location = new System.Drawing.Point(43, 171);
            this.transactionDataGridView.Name = "transactionDataGridView";
            this.transactionDataGridView.RowTemplate.Height = 23;
            this.transactionDataGridView.Size = new System.Drawing.Size(708, 189);
            this.transactionDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateCreated";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn7.HeaderText = "Date";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TransactionType";
            this.dataGridViewTextBoxColumn10.HeaderText = "Type";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 160;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Deposit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "Amount In";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Withdrawal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount Out";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Notes";
            this.dataGridViewTextBoxColumn8.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 320;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_ZD.Models.BankAccount);
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(101, 82);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(95, 12);
            accountNumberLabel.TabIndex = 0;
            accountNumberLabel.Text = "Account Number:";
            // 
            // lblAccNumberMasked
            // 
            this.lblAccNumberMasked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccNumberMasked.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.lblAccNumberMasked.Location = new System.Drawing.Point(202, 82);
            this.lblAccNumberMasked.Name = "lblAccNumberMasked";
            this.lblAccNumberMasked.Size = new System.Drawing.Size(100, 23);
            this.lblAccNumberMasked.TabIndex = 1;
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(101, 36);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(89, 12);
            clientNumberLabel.TabIndex = 2;
            clientNumberLabel.Text = "Client Number:";
            // 
            // lblClientNumMasked
            // 
            this.lblClientNumMasked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClientNumMasked.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Client.ClientNumber", true));
            this.lblClientNumMasked.Location = new System.Drawing.Point(202, 35);
            this.lblClientNumMasked.Mask = "0000-0000";
            this.lblClientNumMasked.Name = "lblClientNumMasked";
            this.lblClientNumMasked.Size = new System.Drawing.Size(100, 23);
            this.lblClientNumMasked.TabIndex = 3;
            this.lblClientNumMasked.Text = "    -";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(378, 36);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(65, 12);
            fullNameLabel.TabIndex = 4;
            fullNameLabel.Text = "Full Name:";
            // 
            // lblHistoryFullName
            // 
            this.lblHistoryFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHistoryFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Client.FullName", true));
            this.lblHistoryFullName.Location = new System.Drawing.Point(449, 36);
            this.lblHistoryFullName.Name = "lblHistoryFullName";
            this.lblHistoryFullName.Size = new System.Drawing.Size(157, 23);
            this.lblHistoryFullName.TabIndex = 5;
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(378, 82);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(53, 12);
            balanceLabel.TabIndex = 6;
            balanceLabel.Text = "Balance:";
            // 
            // lblHistoryBalance
            // 
            this.lblHistoryBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHistoryBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.lblHistoryBalance.Location = new System.Drawing.Point(449, 82);
            this.lblHistoryBalance.Name = "lblHistoryBalance";
            this.lblHistoryBalance.Size = new System.Drawing.Size(157, 23);
            this.lblHistoryBalance.TabIndex = 7;
            this.lblHistoryBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 448);
            this.Controls.Add(this.transactionDataGridView);
            this.Controls.Add(this.lnkReturn);
            this.Controls.Add(this.grpAccount);
            this.Name = "History";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.BindingSource transactionBindingSource;
        private System.Windows.Forms.DataGridView transactionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label lblHistoryBalance;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label lblHistoryFullName;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblClientNumMasked;
        private EWSoftware.MaskedLabelControl.MaskedLabel lblAccNumberMasked;
    }
}