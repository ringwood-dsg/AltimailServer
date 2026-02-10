namespace DBUpdater
{
   partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.labelCurrentVersionLabel = new System.Windows.Forms.Label();
            this.labelRequiredDatabaseVersionLabel = new System.Windows.Forms.Label();
            this.labelRequiredDatabaseVersion = new System.Windows.Forms.Label();
            this.labelCurrentDatabaseVersion = new System.Windows.Forms.Label();
            this.listRequiredUpgrades = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonUpgrade = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelUpgradeSteps = new System.Windows.Forms.Label();
            this.labelRunBackup = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCurrentVersionLabel
            // 
            this.labelCurrentVersionLabel.AutoSize = true;
            this.labelCurrentVersionLabel.Location = new System.Drawing.Point(8, 8);
            this.labelCurrentVersionLabel.Name = "labelCurrentVersionLabel";
            this.labelCurrentVersionLabel.Size = new System.Drawing.Size(136, 13);
            this.labelCurrentVersionLabel.TabIndex = 0;
            this.labelCurrentVersionLabel.Text = "Current database version";
            // 
            // labelRequiredDatabaseVersionLabel
            // 
            this.labelRequiredDatabaseVersionLabel.AutoSize = true;
            this.labelRequiredDatabaseVersionLabel.Location = new System.Drawing.Point(8, 32);
            this.labelRequiredDatabaseVersionLabel.Name = "labelRequiredDatabaseVersionLabel";
            this.labelRequiredDatabaseVersionLabel.Size = new System.Drawing.Size(144, 13);
            this.labelRequiredDatabaseVersionLabel.TabIndex = 1;
            this.labelRequiredDatabaseVersionLabel.Text = "Required database version";
            // 
            // labelRequiredDatabaseVersion
            // 
            this.labelRequiredDatabaseVersion.AutoSize = true;
            this.labelRequiredDatabaseVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRequiredDatabaseVersion.Location = new System.Drawing.Point(160, 32);
            this.labelRequiredDatabaseVersion.Name = "labelRequiredDatabaseVersion";
            this.labelRequiredDatabaseVersion.Size = new System.Drawing.Size(11, 13);
            this.labelRequiredDatabaseVersion.TabIndex = 3;
            this.labelRequiredDatabaseVersion.Text = "-";
            // 
            // labelCurrentDatabaseVersion
            // 
            this.labelCurrentDatabaseVersion.AutoSize = true;
            this.labelCurrentDatabaseVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentDatabaseVersion.Location = new System.Drawing.Point(160, 8);
            this.labelCurrentDatabaseVersion.Name = "labelCurrentDatabaseVersion";
            this.labelCurrentDatabaseVersion.Size = new System.Drawing.Size(11, 13);
            this.labelCurrentDatabaseVersion.TabIndex = 2;
            this.labelCurrentDatabaseVersion.Text = "-";
            // 
            // listRequiredUpgrades
            // 
            this.listRequiredUpgrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listRequiredUpgrades.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listRequiredUpgrades.FullRowSelect = true;
            this.listRequiredUpgrades.HideSelection = false;
            this.listRequiredUpgrades.Location = new System.Drawing.Point(11, 82);
            this.listRequiredUpgrades.Name = "listRequiredUpgrades";
            this.listRequiredUpgrades.Size = new System.Drawing.Size(452, 180);
            this.listRequiredUpgrades.TabIndex = 4;
            this.listRequiredUpgrades.UseCompatibleStateImageBehavior = false;
            this.listRequiredUpgrades.View = System.Windows.Forms.View.Details;
            this.listRequiredUpgrades.DoubleClick += new System.EventHandler(this.listRequiredUpgrades_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "From";
            this.columnHeader1.Width = 176;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "To";
            this.columnHeader2.Width = 184;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 79;
            // 
            // buttonUpgrade
            // 
            this.buttonUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpgrade.Location = new System.Drawing.Point(257, 319);
            this.buttonUpgrade.Name = "buttonUpgrade";
            this.buttonUpgrade.Size = new System.Drawing.Size(100, 25);
            this.buttonUpgrade.TabIndex = 5;
            this.buttonUpgrade.Text = "&Upgrade";
            this.buttonUpgrade.UseVisualStyleBackColor = true;
            this.buttonUpgrade.Click += new System.EventHandler(this.buttonUpgrade_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(360, 319);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 25);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelUpgradeSteps
            // 
            this.labelUpgradeSteps.AutoSize = true;
            this.labelUpgradeSteps.Location = new System.Drawing.Point(8, 56);
            this.labelUpgradeSteps.Name = "labelUpgradeSteps";
            this.labelUpgradeSteps.Size = new System.Drawing.Size(131, 13);
            this.labelUpgradeSteps.TabIndex = 7;
            this.labelUpgradeSteps.Text = "Required upgrade steps";
            // 
            // labelRunBackup
            // 
            this.labelRunBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRunBackup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelRunBackup.Location = new System.Drawing.Point(36, 269);
            this.labelRunBackup.Name = "labelRunBackup";
            this.labelRunBackup.Size = new System.Drawing.Size(424, 33);
            this.labelRunBackup.TabIndex = 8;
            this.labelRunBackup.Text = "Before performing the database upgrade, you should take a backup of your database" +
    ". If the upgrade fails, restore the database.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::DBUpdater.Properties.Resources.db_warning;
            this.pictureBox1.Location = new System.Drawing.Point(11, 269);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // formMain
            // 
            this.AcceptButton = this.buttonUpgrade;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(475, 352);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelRunBackup);
            this.Controls.Add(this.labelUpgradeSteps);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonUpgrade);
            this.Controls.Add(this.listRequiredUpgrades);
            this.Controls.Add(this.labelRequiredDatabaseVersion);
            this.Controls.Add(this.labelCurrentDatabaseVersion);
            this.Controls.Add(this.labelRequiredDatabaseVersionLabel);
            this.Controls.Add(this.labelCurrentVersionLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(431, 278);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Altimail Server Database Upgrade Utility";
            this.Shown += new System.EventHandler(this.formMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      public System.Windows.Forms.Label labelCurrentVersionLabel;
      public System.Windows.Forms.Label labelRequiredDatabaseVersionLabel;
      public System.Windows.Forms.Label labelRequiredDatabaseVersion;
      public System.Windows.Forms.Label labelCurrentDatabaseVersion;
      private System.Windows.Forms.ListView listRequiredUpgrades;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.Button buttonUpgrade;
      private System.Windows.Forms.Button buttonClose;
      private System.Windows.Forms.Label labelUpgradeSteps;
      private System.Windows.Forms.Label labelRunBackup;
      private System.Windows.Forms.PictureBox pictureBox1;
   }
}

