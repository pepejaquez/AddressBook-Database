namespace Address_Book
{
    partial class Form1
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
            this.txtboxFirstName = new System.Windows.Forms.TextBox();
            this.txtboxLastName = new System.Windows.Forms.TextBox();
            this.txtboxAddress = new System.Windows.Forms.TextBox();
            this.txtboxCity = new System.Windows.Forms.TextBox();
            this.txtboxState = new System.Windows.Forms.TextBox();
            this.txtboxZipcode = new System.Windows.Forms.TextBox();
            this.txtboxEmail = new System.Windows.Forms.TextBox();
            this.txtboxComment = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblZipcode = new System.Windows.Forms.Label();
            this.lblHomePhone = new System.Windows.Forms.Label();
            this.lblCellPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.maskedtxtboxHomePhone = new System.Windows.Forms.MaskedTextBox();
            this.maskedtxtboxCellPhone = new System.Windows.Forms.MaskedTextBox();
            this.lstboxCurrentContacts = new System.Windows.Forms.ListBox();
            this.lblCurrentContacts = new System.Windows.Forms.Label();
            this.btnNewUpdateEntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtboxFirstName
            // 
            this.txtboxFirstName.Location = new System.Drawing.Point(294, 38);
            this.txtboxFirstName.Name = "txtboxFirstName";
            this.txtboxFirstName.Size = new System.Drawing.Size(171, 26);
            this.txtboxFirstName.TabIndex = 0;
            // 
            // txtboxLastName
            // 
            this.txtboxLastName.Location = new System.Drawing.Point(499, 38);
            this.txtboxLastName.Name = "txtboxLastName";
            this.txtboxLastName.Size = new System.Drawing.Size(219, 26);
            this.txtboxLastName.TabIndex = 1;
            // 
            // txtboxAddress
            // 
            this.txtboxAddress.Location = new System.Drawing.Point(294, 108);
            this.txtboxAddress.Name = "txtboxAddress";
            this.txtboxAddress.Size = new System.Drawing.Size(322, 26);
            this.txtboxAddress.TabIndex = 2;
            // 
            // txtboxCity
            // 
            this.txtboxCity.Location = new System.Drawing.Point(294, 178);
            this.txtboxCity.Name = "txtboxCity";
            this.txtboxCity.Size = new System.Drawing.Size(120, 26);
            this.txtboxCity.TabIndex = 3;
            // 
            // txtboxState
            // 
            this.txtboxState.Location = new System.Drawing.Point(444, 178);
            this.txtboxState.Name = "txtboxState";
            this.txtboxState.Size = new System.Drawing.Size(74, 26);
            this.txtboxState.TabIndex = 4;
            // 
            // txtboxZipcode
            // 
            this.txtboxZipcode.Location = new System.Drawing.Point(565, 178);
            this.txtboxZipcode.Name = "txtboxZipcode";
            this.txtboxZipcode.Size = new System.Drawing.Size(100, 26);
            this.txtboxZipcode.TabIndex = 5;
            // 
            // txtboxEmail
            // 
            this.txtboxEmail.Location = new System.Drawing.Point(294, 324);
            this.txtboxEmail.Name = "txtboxEmail";
            this.txtboxEmail.Size = new System.Drawing.Size(233, 26);
            this.txtboxEmail.TabIndex = 8;
            // 
            // txtboxComment
            // 
            this.txtboxComment.Location = new System.Drawing.Point(294, 392);
            this.txtboxComment.Multiline = true;
            this.txtboxComment.Name = "txtboxComment";
            this.txtboxComment.Size = new System.Drawing.Size(353, 70);
            this.txtboxComment.TabIndex = 9;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(290, 9);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(86, 20);
            this.lblFirstName.TabIndex = 10;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(495, 9);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(86, 20);
            this.lblLastName.TabIndex = 11;
            this.lblLastName.Text = "Last Name";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(290, 85);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(116, 20);
            this.lblAddress.TabIndex = 12;
            this.lblAddress.Text = "Street Address";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(290, 155);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(35, 20);
            this.lblCity.TabIndex = 13;
            this.lblCity.Text = "City";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(440, 157);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(48, 20);
            this.lblState.TabIndex = 14;
            this.lblState.Text = "State";
            // 
            // lblZipcode
            // 
            this.lblZipcode.AutoSize = true;
            this.lblZipcode.Location = new System.Drawing.Point(561, 157);
            this.lblZipcode.Name = "lblZipcode";
            this.lblZipcode.Size = new System.Drawing.Size(73, 20);
            this.lblZipcode.TabIndex = 15;
            this.lblZipcode.Text = "Zip Code";
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.AutoSize = true;
            this.lblHomePhone.Location = new System.Drawing.Point(290, 229);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Size = new System.Drawing.Size(102, 20);
            this.lblHomePhone.TabIndex = 16;
            this.lblHomePhone.Text = "Home Phone";
            // 
            // lblCellPhone
            // 
            this.lblCellPhone.AutoSize = true;
            this.lblCellPhone.Location = new System.Drawing.Point(459, 229);
            this.lblCellPhone.Name = "lblCellPhone";
            this.lblCellPhone.Size = new System.Drawing.Size(85, 20);
            this.lblCellPhone.TabIndex = 17;
            this.lblCellPhone.Text = "Cell Phone";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(290, 301);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(290, 369);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(78, 20);
            this.lblComment.TabIndex = 19;
            this.lblComment.Text = "Comment";
            // 
            // maskedtxtboxHomePhone
            // 
            this.maskedtxtboxHomePhone.Location = new System.Drawing.Point(294, 252);
            this.maskedtxtboxHomePhone.Mask = "(999) 000-0000";
            this.maskedtxtboxHomePhone.Name = "maskedtxtboxHomePhone";
            this.maskedtxtboxHomePhone.Size = new System.Drawing.Size(123, 26);
            this.maskedtxtboxHomePhone.TabIndex = 20;
            // 
            // maskedtxtboxCellPhone
            // 
            this.maskedtxtboxCellPhone.Location = new System.Drawing.Point(463, 252);
            this.maskedtxtboxCellPhone.Mask = "(999) 000-0000";
            this.maskedtxtboxCellPhone.Name = "maskedtxtboxCellPhone";
            this.maskedtxtboxCellPhone.Size = new System.Drawing.Size(123, 26);
            this.maskedtxtboxCellPhone.TabIndex = 21;
            // 
            // lstboxCurrentContacts
            // 
            this.lstboxCurrentContacts.FormattingEnabled = true;
            this.lstboxCurrentContacts.ItemHeight = 20;
            this.lstboxCurrentContacts.Location = new System.Drawing.Point(47, 38);
            this.lstboxCurrentContacts.Name = "lstboxCurrentContacts";
            this.lstboxCurrentContacts.Size = new System.Drawing.Size(208, 424);
            this.lstboxCurrentContacts.TabIndex = 22;
            this.lstboxCurrentContacts.DoubleClick += new System.EventHandler(this.lstboxCurrentContacts_DoubleClick);
            // 
            // lblCurrentContacts
            // 
            this.lblCurrentContacts.AutoSize = true;
            this.lblCurrentContacts.Location = new System.Drawing.Point(43, 9);
            this.lblCurrentContacts.Name = "lblCurrentContacts";
            this.lblCurrentContacts.Size = new System.Drawing.Size(130, 20);
            this.lblCurrentContacts.TabIndex = 23;
            this.lblCurrentContacts.Text = "Current Contacts";
            // 
            // btnNewUpdateEntry
            // 
            this.btnNewUpdateEntry.Location = new System.Drawing.Point(343, 486);
            this.btnNewUpdateEntry.Name = "btnNewUpdateEntry";
            this.btnNewUpdateEntry.Size = new System.Drawing.Size(222, 47);
            this.btnNewUpdateEntry.TabIndex = 24;
            this.btnNewUpdateEntry.Text = "New/Update Entry";
            this.btnNewUpdateEntry.UseVisualStyleBackColor = true;
            this.btnNewUpdateEntry.Click += new System.EventHandler(this.btnNewUpdateEntry_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 551);
            this.Controls.Add(this.btnNewUpdateEntry);
            this.Controls.Add(this.lblCurrentContacts);
            this.Controls.Add(this.lstboxCurrentContacts);
            this.Controls.Add(this.maskedtxtboxCellPhone);
            this.Controls.Add(this.maskedtxtboxHomePhone);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblCellPhone);
            this.Controls.Add(this.lblHomePhone);
            this.Controls.Add(this.lblZipcode);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtboxComment);
            this.Controls.Add(this.txtboxEmail);
            this.Controls.Add(this.txtboxZipcode);
            this.Controls.Add(this.txtboxState);
            this.Controls.Add(this.txtboxCity);
            this.Controls.Add(this.txtboxAddress);
            this.Controls.Add(this.txtboxLastName);
            this.Controls.Add(this.txtboxFirstName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Address Entry";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxFirstName;
        private System.Windows.Forms.TextBox txtboxLastName;
        private System.Windows.Forms.TextBox txtboxAddress;
        private System.Windows.Forms.TextBox txtboxCity;
        private System.Windows.Forms.TextBox txtboxState;
        private System.Windows.Forms.TextBox txtboxZipcode;
        private System.Windows.Forms.TextBox txtboxEmail;
        private System.Windows.Forms.TextBox txtboxComment;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblZipcode;
        private System.Windows.Forms.Label lblHomePhone;
        private System.Windows.Forms.Label lblCellPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.MaskedTextBox maskedtxtboxHomePhone;
        private System.Windows.Forms.MaskedTextBox maskedtxtboxCellPhone;
        private System.Windows.Forms.ListBox lstboxCurrentContacts;
        private System.Windows.Forms.Label lblCurrentContacts;
        private System.Windows.Forms.Button btnNewUpdateEntry;
    }
}

