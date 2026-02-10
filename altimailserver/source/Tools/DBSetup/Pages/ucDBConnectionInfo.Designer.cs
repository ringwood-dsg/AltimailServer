namespace DBSetup.Pages
{
   partial class ucDBConnectionInfo
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.labelDatabaseServerAddress = new System.Windows.Forms.Label();
            this.textServerAddress = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textDatabaseName = new System.Windows.Forms.TextBox();
            this.labelDatabaseName = new System.Windows.Forms.Label();
            this.radioUseServerAuthentication = new System.Windows.Forms.RadioButton();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.radioUseWindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.textServerPort = new AltimailServer.Shared.ucText();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDatabaseServerAddress
            // 
            this.labelDatabaseServerAddress.AutoSize = true;
            this.labelDatabaseServerAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelDatabaseServerAddress.Location = new System.Drawing.Point(11, 23);
            this.labelDatabaseServerAddress.Name = "labelDatabaseServerAddress";
            this.labelDatabaseServerAddress.Size = new System.Drawing.Size(82, 13);
            this.labelDatabaseServerAddress.TabIndex = 0;
            this.labelDatabaseServerAddress.Text = "Server Address";
            // 
            // textServerAddress
            // 
            this.textServerAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textServerAddress.Location = new System.Drawing.Point(11, 39);
            this.textServerAddress.Name = "textServerAddress";
            this.textServerAddress.Size = new System.Drawing.Size(192, 22);
            this.textServerAddress.TabIndex = 4;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelPort.Location = new System.Drawing.Point(209, 23);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(28, 13);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Port";
            // 
            // textDatabaseName
            // 
            this.textDatabaseName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textDatabaseName.Location = new System.Drawing.Point(11, 87);
            this.textDatabaseName.Name = "textDatabaseName";
            this.textDatabaseName.Size = new System.Drawing.Size(144, 22);
            this.textDatabaseName.TabIndex = 5;
            // 
            // labelDatabaseName
            // 
            this.labelDatabaseName.AutoSize = true;
            this.labelDatabaseName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelDatabaseName.Location = new System.Drawing.Point(11, 71);
            this.labelDatabaseName.Name = "labelDatabaseName";
            this.labelDatabaseName.Size = new System.Drawing.Size(87, 13);
            this.labelDatabaseName.TabIndex = 4;
            this.labelDatabaseName.Text = "Database Name";
            // 
            // radioUseServerAuthentication
            // 
            this.radioUseServerAuthentication.AutoSize = true;
            this.radioUseServerAuthentication.Checked = true;
            this.radioUseServerAuthentication.Location = new System.Drawing.Point(11, 21);
            this.radioUseServerAuthentication.Name = "radioUseServerAuthentication";
            this.radioUseServerAuthentication.Size = new System.Drawing.Size(156, 17);
            this.radioUseServerAuthentication.TabIndex = 7;
            this.radioUseServerAuthentication.TabStop = true;
            this.radioUseServerAuthentication.Text = "Use server authentication";
            this.radioUseServerAuthentication.UseVisualStyleBackColor = true;
            this.radioUseServerAuthentication.CheckedChanged += new System.EventHandler(this.radioUseServerAuthentication_CheckedChanged);
            // 
            // textUsername
            // 
            this.textUsername.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textUsername.Location = new System.Drawing.Point(102, 45);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(144, 22);
            this.textUsername.TabIndex = 2;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelUsername.Location = new System.Drawing.Point(27, 48);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 9;
            this.labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelPassword.Location = new System.Drawing.Point(27, 75);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "Password";
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textPassword.Location = new System.Drawing.Point(102, 72);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(144, 22);
            this.textPassword.TabIndex = 10;
            // 
            // radioUseWindowsAuthentication
            // 
            this.radioUseWindowsAuthentication.AutoSize = true;
            this.radioUseWindowsAuthentication.Location = new System.Drawing.Point(11, 103);
            this.radioUseWindowsAuthentication.Name = "radioUseWindowsAuthentication";
            this.radioUseWindowsAuthentication.Size = new System.Drawing.Size(175, 17);
            this.radioUseWindowsAuthentication.TabIndex = 12;
            this.radioUseWindowsAuthentication.Text = "Use Windows authentication";
            this.radioUseWindowsAuthentication.UseVisualStyleBackColor = true;
            this.radioUseWindowsAuthentication.CheckedChanged += new System.EventHandler(this.radioUseWindowsAuthentication_CheckedChanged);
            // 
            // textServerPort
            // 
            this.textServerPort.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textServerPort.Location = new System.Drawing.Point(209, 39);
            this.textServerPort.MaxLength = 5;
            this.textServerPort.Name = "textServerPort";
            this.textServerPort.Number = 0;
            this.textServerPort.Number64 = ((long)(0));
            this.textServerPort.Numeric = true;
            this.textServerPort.Size = new System.Drawing.Size(58, 22);
            this.textServerPort.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelDatabaseServerAddress);
            this.groupBox1.Controls.Add(this.textServerAddress);
            this.groupBox1.Controls.Add(this.labelPort);
            this.groupBox1.Controls.Add(this.textServerPort);
            this.groupBox1.Controls.Add(this.labelDatabaseName);
            this.groupBox1.Controls.Add(this.textDatabaseName);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 123);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioUseServerAuthentication);
            this.groupBox2.Controls.Add(this.textUsername);
            this.groupBox2.Controls.Add(this.radioUseWindowsAuthentication);
            this.groupBox2.Controls.Add(this.labelUsername);
            this.groupBox2.Controls.Add(this.labelPassword);
            this.groupBox2.Controls.Add(this.textPassword);
            this.groupBox2.Location = new System.Drawing.Point(8, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 128);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authentication";
            // 
            // ucDBConnectionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucDBConnectionInfo";
            this.Size = new System.Drawing.Size(475, 273);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label labelDatabaseServerAddress;
      private System.Windows.Forms.TextBox textServerAddress;
      private System.Windows.Forms.Label labelPort;
      private AltimailServer.Shared.ucText textServerPort;
      private System.Windows.Forms.TextBox textDatabaseName;
      private System.Windows.Forms.Label labelDatabaseName;
      private System.Windows.Forms.RadioButton radioUseServerAuthentication;
      private System.Windows.Forms.TextBox textUsername;
      private System.Windows.Forms.Label labelUsername;
      private System.Windows.Forms.Label labelPassword;
      private System.Windows.Forms.TextBox textPassword;
      private System.Windows.Forms.RadioButton radioUseWindowsAuthentication;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
   }
}
