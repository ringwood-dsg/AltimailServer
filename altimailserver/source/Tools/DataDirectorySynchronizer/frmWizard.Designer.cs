namespace DataDirectorySynchronizer
{
   partial class frmWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWizard));
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.wpAction = new AeroWizard.WizardPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.optRemoveMail = new System.Windows.Forms.RadioButton();
            this.optImportMail = new System.Windows.Forms.RadioButton();
            this.wpDomains = new AeroWizard.WizardPage();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.listViewDomains = new System.Windows.Forms.ListView();
            this.columnDomainName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.wpFinish = new AeroWizard.WizardPage();
            this.listProcess = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelSkipped = new System.Windows.Forms.Label();
            this.labelExecutionTime = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.imgStatus = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wpAction.SuspendLayout();
            this.wpDomains.SuspendLayout();
            this.wpFinish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishButtonText = "&Execute";
            this.wizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.wpAction);
            this.wizardControl1.Pages.Add(this.wpDomains);
            this.wizardControl1.Pages.Add(this.wpFinish);
            this.wizardControl1.Size = new System.Drawing.Size(574, 415);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "Altimail Server Data Synchronisation Utility";
            this.wizardControl1.TitleIcon = ((System.Drawing.Icon)(resources.GetObject("wizardControl1.TitleIcon")));
            this.wizardControl1.Cancelling += new System.ComponentModel.CancelEventHandler(this.wizardMain_Cancelling);
            this.wizardControl1.Finished += new System.EventHandler(this.wizardMain_Finished);
            this.wizardControl1.SelectedPageChanged += new System.EventHandler(this.wizardMain_SelectedPageChanged);
            // 
            // wpAction
            // 
            this.wpAction.Controls.Add(this.label1);
            this.wpAction.Controls.Add(this.label3);
            this.wpAction.Controls.Add(this.optRemoveMail);
            this.wpAction.Controls.Add(this.optImportMail);
            this.wpAction.Name = "wpAction";
            this.wpAction.Size = new System.Drawing.Size(527, 261);
            this.wpAction.TabIndex = 0;
            this.wpAction.Text = "what would you like to do?";
            this.wpAction.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Commit);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label1.Location = new System.Drawing.Point(39, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Use this option to remove physical email files from the DATA directory if they no" +
    " longer exist in the database. This is useful for removing orphaned emails.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label3.Location = new System.Drawing.Point(39, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(473, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "Use this option if you want to import emails from another email server (typically" +
    " in .eml format) into Altimail Server. Place the files in the DATA directory bef" +
    "ore proceeding.";
            // 
            // optRemoveMail
            // 
            this.optRemoveMail.AutoSize = true;
            this.optRemoveMail.Location = new System.Drawing.Point(21, 91);
            this.optRemoveMail.Name = "optRemoveMail";
            this.optRemoveMail.Size = new System.Drawing.Size(196, 19);
            this.optRemoveMail.TabIndex = 1;
            this.optRemoveMail.Text = "Remove mail from the database.";
            this.optRemoveMail.UseVisualStyleBackColor = true;
            // 
            // optImportMail
            // 
            this.optImportMail.AutoSize = true;
            this.optImportMail.Checked = true;
            this.optImportMail.Location = new System.Drawing.Point(21, 21);
            this.optImportMail.Name = "optImportMail";
            this.optImportMail.Size = new System.Drawing.Size(184, 19);
            this.optImportMail.TabIndex = 0;
            this.optImportMail.TabStop = true;
            this.optImportMail.Text = "Import mail into the database.";
            this.optImportMail.UseVisualStyleBackColor = true;
            // 
            // wpDomains
            // 
            this.wpDomains.Controls.Add(this.btnSelectAll);
            this.wpDomains.Controls.Add(this.btnSelectNone);
            this.wpDomains.Controls.Add(this.listViewDomains);
            this.wpDomains.Controls.Add(this.label2);
            this.wpDomains.Name = "wpDomains";
            this.wpDomains.Size = new System.Drawing.Size(527, 261);
            this.wpDomains.TabIndex = 1;
            this.wpDomains.Text = "target domain(s)";
            this.wpDomains.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Commit);
            this.wpDomains.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Rollback);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Image = global::DataDirectorySynchronizer.Properties.Resources.btn_select_all;
            this.btnSelectAll.Location = new System.Drawing.Point(478, 21);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 9;
            this.tipMain.SetToolTip(this.btnSelectAll, "Select All");
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Image = global::DataDirectorySynchronizer.Properties.Resources.btn_select_none;
            this.btnSelectNone.Location = new System.Drawing.Point(452, 21);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 1;
            this.tipMain.SetToolTip(this.btnSelectNone, "Clear Selection");
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // listViewDomains
            // 
            this.listViewDomains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDomains.CheckBoxes = true;
            this.listViewDomains.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDomainName});
            this.listViewDomains.FullRowSelect = true;
            this.listViewDomains.HideSelection = false;
            this.listViewDomains.Location = new System.Drawing.Point(24, 48);
            this.listViewDomains.Name = "listViewDomains";
            this.listViewDomains.Size = new System.Drawing.Size(478, 191);
            this.listViewDomains.TabIndex = 8;
            this.listViewDomains.UseCompatibleStateImageBehavior = false;
            this.listViewDomains.View = System.Windows.Forms.View.Details;
            // 
            // columnDomainName
            // 
            this.columnDomainName.Text = "Domain name";
            this.columnDomainName.Width = 250;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select the domain(s) you want to synchronise.";
            // 
            // wpFinish
            // 
            this.wpFinish.Controls.Add(this.listProcess);
            this.wpFinish.Controls.Add(this.labelSkipped);
            this.wpFinish.Controls.Add(this.labelExecutionTime);
            this.wpFinish.Controls.Add(this.labelStatus);
            this.wpFinish.Controls.Add(this.imgStatus);
            this.wpFinish.Controls.Add(this.label13);
            this.wpFinish.Name = "wpFinish";
            this.wpFinish.Size = new System.Drawing.Size(527, 261);
            this.wpFinish.TabIndex = 2;
            this.wpFinish.Text = "ready";
            this.wpFinish.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Commit);
            this.wpFinish.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Rollback);
            // 
            // listProcess
            // 
            this.listProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listProcess.HideSelection = false;
            this.listProcess.Location = new System.Drawing.Point(24, 115);
            this.listProcess.Name = "listProcess";
            this.listProcess.Size = new System.Drawing.Size(482, 127);
            this.listProcess.TabIndex = 7;
            this.listProcess.UseCompatibleStateImageBehavior = false;
            this.listProcess.View = System.Windows.Forms.View.Details;
            this.listProcess.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File name";
            this.columnHeader1.Width = 450;
            // 
            // labelSkipped
            // 
            this.labelSkipped.Location = new System.Drawing.Point(21, 90);
            this.labelSkipped.Name = "labelSkipped";
            this.labelSkipped.Size = new System.Drawing.Size(485, 22);
            this.labelSkipped.TabIndex = 6;
            this.labelSkipped.Text = "The following item(s) were skipped.";
            this.labelSkipped.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelSkipped.Visible = false;
            // 
            // labelExecutionTime
            // 
            this.labelExecutionTime.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelExecutionTime.Location = new System.Drawing.Point(411, 61);
            this.labelExecutionTime.Name = "labelExecutionTime";
            this.labelExecutionTime.Size = new System.Drawing.Size(95, 24);
            this.labelExecutionTime.TabIndex = 5;
            this.labelExecutionTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelExecutionTime.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(51, 61);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(354, 24);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Initializing...";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelStatus.Visible = false;
            // 
            // imgStatus
            // 
            this.imgStatus.Image = global::DataDirectorySynchronizer.Properties.Resources.progress_pending;
            this.imgStatus.Location = new System.Drawing.Point(24, 61);
            this.imgStatus.Name = "imgStatus";
            this.imgStatus.Size = new System.Drawing.Size(24, 24);
            this.imgStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStatus.TabIndex = 3;
            this.imgStatus.TabStop = false;
            this.imgStatus.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(21, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(485, 36);
            this.label13.TabIndex = 1;
            this.label13.Text = "The wizard has collected enough information to perform the requested operation. T" +
    "o begin, click Execute.";
            // 
            // tipMain
            // 
            this.tipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(574, 415);
            this.Controls.Add(this.wizardControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmWizard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Altimail Server Data Synchronisation Utility";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wpAction.ResumeLayout(false);
            this.wpAction.PerformLayout();
            this.wpDomains.ResumeLayout(false);
            this.wpDomains.PerformLayout();
            this.wpFinish.ResumeLayout(false);
            this.wpFinish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private AeroWizard.WizardControl wizardControl1;
      private AeroWizard.WizardPage wpAction;
      private AeroWizard.WizardPage wpDomains;
      private AeroWizard.WizardPage wpFinish;
      private System.Windows.Forms.RadioButton optRemoveMail;
      private System.Windows.Forms.RadioButton optImportMail;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ListView listViewDomains;
      private System.Windows.Forms.ColumnHeader columnDomainName;
      private System.Windows.Forms.Button btnSelectAll;
      private System.Windows.Forms.Button btnSelectNone;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label labelStatus;
      private System.Windows.Forms.PictureBox imgStatus;
      private System.Windows.Forms.Label labelExecutionTime;
      private System.Windows.Forms.Label labelSkipped;
      private System.Windows.Forms.ListView listProcess;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ToolTip tipMain;
      private System.Windows.Forms.Timer timer1;
   }
}