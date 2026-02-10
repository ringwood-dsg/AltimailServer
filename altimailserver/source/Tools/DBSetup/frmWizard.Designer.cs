namespace DBSetup
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
            this.wizardMain = new AeroWizard.WizardControl();
            this.wpWelcome = new AeroWizard.WizardPage();
            this.label1 = new System.Windows.Forms.Label();
            this.wpAction = new AeroWizard.WizardPage();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.optExistingDatabase = new System.Windows.Forms.RadioButton();
            this.optNewDatabase = new System.Windows.Forms.RadioButton();
            this.wpDatabaseType = new AeroWizard.WizardPage();
            this.btnBrowseMySqlConnector = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMySqlConnectorPath = new System.Windows.Forms.TextBox();
            this.optPostgreSQL = new System.Windows.Forms.RadioButton();
            this.optMariaDB = new System.Windows.Forms.RadioButton();
            this.optMySQL = new System.Windows.Forms.RadioButton();
            this.optMSSQL = new System.Windows.Forms.RadioButton();
            this.wpDatabaseConnection = new AeroWizard.WizardPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAuthPassword = new System.Windows.Forms.TextBox();
            this.txtAuthUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.optIntegratedAuth = new System.Windows.Forms.RadioButton();
            this.optServerAuth = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.txtDbPort = new System.Windows.Forms.TextBox();
            this.txtDbServerAddress = new System.Windows.Forms.TextBox();
            this.wpDatabaseService = new AeroWizard.WizardPage();
            this.cboDatabaseService = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.wpFinish = new AeroWizard.WizardPage();
            this.lblProgress1 = new System.Windows.Forms.Label();
            this.imgProgress1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.errNew = new System.Windows.Forms.ErrorProvider(this.components);
            this.dlgBrowseMySqlConnector = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.wizardMain)).BeginInit();
            this.wpWelcome.SuspendLayout();
            this.wpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.wpDatabaseType.SuspendLayout();
            this.wpDatabaseConnection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.wpDatabaseService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.wpFinish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProgress1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNew)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardMain
            // 
            this.wizardMain.BackColor = System.Drawing.Color.White;
            this.wizardMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardMain.FinishButtonText = "&Execute";
            this.wizardMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardMain.Location = new System.Drawing.Point(0, 0);
            this.wizardMain.Name = "wizardMain";
            this.wizardMain.Pages.Add(this.wpWelcome);
            this.wizardMain.Pages.Add(this.wpAction);
            this.wizardMain.Pages.Add(this.wpDatabaseType);
            this.wizardMain.Pages.Add(this.wpDatabaseConnection);
            this.wizardMain.Pages.Add(this.wpDatabaseService);
            this.wizardMain.Pages.Add(this.wpFinish);
            this.wizardMain.Size = new System.Drawing.Size(574, 415);
            this.wizardMain.TabIndex = 0;
            this.wizardMain.Title = "Altimail Server Database Configuration";
            this.wizardMain.TitleIcon = ((System.Drawing.Icon)(resources.GetObject("wizardMain.TitleIcon")));
            this.wizardMain.Cancelling += new System.ComponentModel.CancelEventHandler(this.wizardMain_Cancelling);
            this.wizardMain.Finished += new System.EventHandler(this.wizardMain_Finished);
            this.wizardMain.SelectedPageChanged += new System.EventHandler(this.wizardMain_SelectedPageChanged);
            // 
            // wpWelcome
            // 
            this.wpWelcome.Controls.Add(this.label1);
            this.wpWelcome.Name = "wpWelcome";
            this.wpWelcome.Size = new System.Drawing.Size(527, 261);
            this.wpWelcome.TabIndex = 0;
            this.wpWelcome.Text = "let\'s get started";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 186);
            this.label1.TabIndex = 0;
            this.label1.Text = "This wizard will help guide you through creating a new Altimail Server database o" +
    "r connecting to an existing Altimail Server or hMailServer database.";
            // 
            // wpAction
            // 
            this.wpAction.Controls.Add(this.label2);
            this.wpAction.Controls.Add(this.pictureBox1);
            this.wpAction.Controls.Add(this.label4);
            this.wpAction.Controls.Add(this.label3);
            this.wpAction.Controls.Add(this.optExistingDatabase);
            this.wpAction.Controls.Add(this.optNewDatabase);
            this.wpAction.Name = "wpAction";
            this.wpAction.Size = new System.Drawing.Size(527, 261);
            this.wpAction.TabIndex = 1;
            this.wpAction.Text = "what would you like to do?";
            this.wpAction.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Commit);
            this.wpAction.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Rollback);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(51, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(461, 85);
            this.label2.TabIndex = 4;
            this.label2.Text = "If you are running this utility outside of the installation, take note that your " +
    "existing Altimail Server instance will be updated with the details you specify h" +
    "ere.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DBSetup.Properties.Resources.db_warning;
            this.pictureBox1.Location = new System.Drawing.Point(21, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label4.Location = new System.Drawing.Point(39, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(473, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "This will use an existing Altimail Server or hMailServer database, performing any" +
    " necessary upgrades automatically.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label3.Location = new System.Drawing.Point(39, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(473, 33);
            this.label3.TabIndex = 1;
            this.label3.Text = "This will create a fresh new database for Altimail Server to use.";
            // 
            // optExistingDatabase
            // 
            this.optExistingDatabase.AutoSize = true;
            this.optExistingDatabase.Location = new System.Drawing.Point(21, 79);
            this.optExistingDatabase.Name = "optExistingDatabase";
            this.optExistingDatabase.Size = new System.Drawing.Size(314, 19);
            this.optExistingDatabase.TabIndex = 2;
            this.optExistingDatabase.Text = "Use an existing Altimail Server or hMailServer database.";
            this.optExistingDatabase.UseVisualStyleBackColor = true;
            // 
            // optNewDatabase
            // 
            this.optNewDatabase.AutoSize = true;
            this.optNewDatabase.Checked = true;
            this.optNewDatabase.Location = new System.Drawing.Point(21, 21);
            this.optNewDatabase.Name = "optNewDatabase";
            this.optNewDatabase.Size = new System.Drawing.Size(225, 19);
            this.optNewDatabase.TabIndex = 0;
            this.optNewDatabase.TabStop = true;
            this.optNewDatabase.Text = "Create a new Altimail Server database.";
            this.optNewDatabase.UseVisualStyleBackColor = true;
            // 
            // wpDatabaseType
            // 
            this.wpDatabaseType.Controls.Add(this.btnBrowseMySqlConnector);
            this.wpDatabaseType.Controls.Add(this.label12);
            this.wpDatabaseType.Controls.Add(this.txtMySqlConnectorPath);
            this.wpDatabaseType.Controls.Add(this.optPostgreSQL);
            this.wpDatabaseType.Controls.Add(this.optMariaDB);
            this.wpDatabaseType.Controls.Add(this.optMySQL);
            this.wpDatabaseType.Controls.Add(this.optMSSQL);
            this.wpDatabaseType.Name = "wpDatabaseType";
            this.wpDatabaseType.Size = new System.Drawing.Size(527, 261);
            this.wpDatabaseType.TabIndex = 2;
            this.wpDatabaseType.Text = "choose database type";
            this.wpDatabaseType.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Commit);
            this.wpDatabaseType.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Rollback);
            // 
            // btnBrowseMySqlConnector
            // 
            this.btnBrowseMySqlConnector.Enabled = false;
            this.btnBrowseMySqlConnector.Location = new System.Drawing.Point(457, 72);
            this.btnBrowseMySqlConnector.Name = "btnBrowseMySqlConnector";
            this.btnBrowseMySqlConnector.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseMySqlConnector.TabIndex = 4;
            this.btnBrowseMySqlConnector.Text = "...";
            this.btnBrowseMySqlConnector.UseVisualStyleBackColor = true;
            this.btnBrowseMySqlConnector.Click += new System.EventHandler(this.btnBrowseMySqlConnector_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "MySQL Connector:";
            // 
            // txtMySqlConnectorPath
            // 
            this.txtMySqlConnectorPath.Enabled = false;
            this.txtMySqlConnectorPath.Location = new System.Drawing.Point(150, 72);
            this.txtMySqlConnectorPath.Name = "txtMySqlConnectorPath";
            this.txtMySqlConnectorPath.ReadOnly = true;
            this.txtMySqlConnectorPath.Size = new System.Drawing.Size(304, 23);
            this.txtMySqlConnectorPath.TabIndex = 3;
            // 
            // optPostgreSQL
            // 
            this.optPostgreSQL.AutoSize = true;
            this.optPostgreSQL.Location = new System.Drawing.Point(21, 130);
            this.optPostgreSQL.Name = "optPostgreSQL";
            this.optPostgreSQL.Size = new System.Drawing.Size(86, 19);
            this.optPostgreSQL.TabIndex = 6;
            this.optPostgreSQL.Text = "PostgreSQL";
            this.optPostgreSQL.UseVisualStyleBackColor = true;
            this.optPostgreSQL.CheckedChanged += new System.EventHandler(this.DatabaseEngineType_CheckedChanged);
            // 
            // optMariaDB
            // 
            this.optMariaDB.AutoSize = true;
            this.optMariaDB.Location = new System.Drawing.Point(21, 105);
            this.optMariaDB.Name = "optMariaDB";
            this.optMariaDB.Size = new System.Drawing.Size(149, 19);
            this.optMariaDB.TabIndex = 5;
            this.optMariaDB.Text = "MariaDB 10.5.29 or later";
            this.optMariaDB.UseVisualStyleBackColor = true;
            this.optMariaDB.CheckedChanged += new System.EventHandler(this.DatabaseEngineType_CheckedChanged);
            // 
            // optMySQL
            // 
            this.optMySQL.AutoSize = true;
            this.optMySQL.Location = new System.Drawing.Point(21, 46);
            this.optMySQL.Name = "optMySQL";
            this.optMySQL.Size = new System.Drawing.Size(130, 19);
            this.optMySQL.TabIndex = 1;
            this.optMySQL.Text = "MySQL 5.7.9 or later";
            this.optMySQL.UseVisualStyleBackColor = true;
            this.optMySQL.CheckedChanged += new System.EventHandler(this.DatabaseEngineType_CheckedChanged);
            // 
            // optMSSQL
            // 
            this.optMSSQL.AutoSize = true;
            this.optMSSQL.Checked = true;
            this.optMSSQL.Location = new System.Drawing.Point(21, 21);
            this.optMSSQL.Name = "optMSSQL";
            this.optMSSQL.Size = new System.Drawing.Size(135, 19);
            this.optMSSQL.TabIndex = 0;
            this.optMSSQL.TabStop = true;
            this.optMSSQL.Text = "Microsoft SQL Server";
            this.optMSSQL.UseVisualStyleBackColor = true;
            this.optMSSQL.CheckedChanged += new System.EventHandler(this.DatabaseEngineType_CheckedChanged);
            // 
            // wpDatabaseConnection
            // 
            this.wpDatabaseConnection.Controls.Add(this.groupBox1);
            this.wpDatabaseConnection.Controls.Add(this.label7);
            this.wpDatabaseConnection.Controls.Add(this.label6);
            this.wpDatabaseConnection.Controls.Add(this.label5);
            this.wpDatabaseConnection.Controls.Add(this.txtDbName);
            this.wpDatabaseConnection.Controls.Add(this.txtDbPort);
            this.wpDatabaseConnection.Controls.Add(this.txtDbServerAddress);
            this.wpDatabaseConnection.Name = "wpDatabaseConnection";
            this.wpDatabaseConnection.Size = new System.Drawing.Size(527, 261);
            this.wpDatabaseConnection.TabIndex = 3;
            this.wpDatabaseConnection.Text = "provide connection details";
            this.wpDatabaseConnection.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Commit);
            this.wpDatabaseConnection.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Rollback);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAuthPassword);
            this.groupBox1.Controls.Add(this.txtAuthUsername);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.optIntegratedAuth);
            this.groupBox1.Controls.Add(this.optServerAuth);
            this.groupBox1.Location = new System.Drawing.Point(24, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AUTHENTICATION";
            // 
            // txtAuthPassword
            // 
            this.txtAuthPassword.Location = new System.Drawing.Point(114, 77);
            this.txtAuthPassword.Name = "txtAuthPassword";
            this.txtAuthPassword.Size = new System.Drawing.Size(137, 23);
            this.txtAuthPassword.TabIndex = 4;
            this.txtAuthPassword.UseSystemPasswordChar = true;
            this.txtAuthPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtAuthUsername
            // 
            this.txtAuthUsername.Location = new System.Drawing.Point(114, 48);
            this.txtAuthUsername.Name = "txtAuthUsername";
            this.txtAuthUsername.Size = new System.Drawing.Size(137, 23);
            this.txtAuthUsername.TabIndex = 2;
            this.txtAuthUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Username";
            // 
            // optIntegratedAuth
            // 
            this.optIntegratedAuth.AutoSize = true;
            this.optIntegratedAuth.Location = new System.Drawing.Point(15, 106);
            this.optIntegratedAuth.Name = "optIntegratedAuth";
            this.optIntegratedAuth.Size = new System.Drawing.Size(236, 19);
            this.optIntegratedAuth.TabIndex = 5;
            this.optIntegratedAuth.Text = "Use Integrated Windows authentication.";
            this.optIntegratedAuth.UseVisualStyleBackColor = true;
            this.optIntegratedAuth.CheckedChanged += new System.EventHandler(this.AuthenticationMode_CheckedChanged);
            // 
            // optServerAuth
            // 
            this.optServerAuth.AutoSize = true;
            this.optServerAuth.Checked = true;
            this.optServerAuth.Location = new System.Drawing.Point(15, 23);
            this.optServerAuth.Name = "optServerAuth";
            this.optServerAuth.Size = new System.Drawing.Size(161, 19);
            this.optServerAuth.TabIndex = 0;
            this.optServerAuth.TabStop = true;
            this.optServerAuth.Text = "Use server authentication.";
            this.optServerAuth.UseVisualStyleBackColor = true;
            this.optServerAuth.CheckedChanged += new System.EventHandler(this.AuthenticationMode_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Database Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Server Address";
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(293, 39);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(171, 23);
            this.txtDbName.TabIndex = 5;
            this.txtDbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtDbPort
            // 
            this.txtDbPort.Location = new System.Drawing.Point(202, 39);
            this.txtDbPort.Name = "txtDbPort";
            this.txtDbPort.Size = new System.Drawing.Size(68, 23);
            this.txtDbPort.TabIndex = 3;
            this.txtDbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtDbServerAddress
            // 
            this.txtDbServerAddress.Location = new System.Drawing.Point(24, 39);
            this.txtDbServerAddress.Name = "txtDbServerAddress";
            this.txtDbServerAddress.Size = new System.Drawing.Size(154, 23);
            this.txtDbServerAddress.TabIndex = 1;
            this.txtDbServerAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // wpDatabaseService
            // 
            this.wpDatabaseService.Controls.Add(this.cboDatabaseService);
            this.wpDatabaseService.Controls.Add(this.label11);
            this.wpDatabaseService.Controls.Add(this.label10);
            this.wpDatabaseService.Controls.Add(this.pictureBox2);
            this.wpDatabaseService.Name = "wpDatabaseService";
            this.wpDatabaseService.Size = new System.Drawing.Size(527, 261);
            this.wpDatabaseService.TabIndex = 4;
            this.wpDatabaseService.Text = "select database service";
            this.wpDatabaseService.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Commit);
            this.wpDatabaseService.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Rollback);
            // 
            // cboDatabaseService
            // 
            this.cboDatabaseService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDatabaseService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDatabaseService.DisplayMember = "Name";
            this.cboDatabaseService.FormattingEnabled = true;
            this.cboDatabaseService.Location = new System.Drawing.Point(62, 204);
            this.cboDatabaseService.Name = "cboDatabaseService";
            this.cboDatabaseService.Size = new System.Drawing.Size(402, 23);
            this.cboDatabaseService.TabIndex = 5;
            this.cboDatabaseService.ValueMember = "Value";
            this.cboDatabaseService.SelectedIndexChanged += new System.EventHandler(this.cboDatabaseService_SelectedIndexChanged);
            this.cboDatabaseService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Database Engine Service";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(59, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(455, 143);
            this.label10.TabIndex = 0;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DBSetup.Properties.Resources.dependency_warning;
            this.pictureBox2.Location = new System.Drawing.Point(21, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // wpFinish
            // 
            this.wpFinish.Controls.Add(this.lblProgress1);
            this.wpFinish.Controls.Add(this.imgProgress1);
            this.wpFinish.Controls.Add(this.label13);
            this.wpFinish.Name = "wpFinish";
            this.wpFinish.Size = new System.Drawing.Size(527, 261);
            this.wpFinish.TabIndex = 5;
            this.wpFinish.Text = "ready";
            this.wpFinish.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Commit);
            this.wpFinish.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPage_Rollback);
            // 
            // lblProgress1
            // 
            this.lblProgress1.Location = new System.Drawing.Point(51, 82);
            this.lblProgress1.Name = "lblProgress1";
            this.lblProgress1.Size = new System.Drawing.Size(455, 20);
            this.lblProgress1.TabIndex = 2;
            this.lblProgress1.Text = "Creating database...";
            this.lblProgress1.Visible = false;
            // 
            // imgProgress1
            // 
            this.imgProgress1.Image = global::DBSetup.Properties.Resources.progress_pending;
            this.imgProgress1.Location = new System.Drawing.Point(24, 78);
            this.imgProgress1.Name = "imgProgress1";
            this.imgProgress1.Size = new System.Drawing.Size(24, 24);
            this.imgProgress1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgProgress1.TabIndex = 1;
            this.imgProgress1.TabStop = false;
            this.imgProgress1.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(21, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(485, 40);
            this.label13.TabIndex = 0;
            this.label13.Text = "The wizard has collected enough information to perform the requested operation. T" +
    "o begin, click Execute.";
            // 
            // errNew
            // 
            this.errNew.ContainerControl = this;
            this.errNew.Icon = ((System.Drawing.Icon)(resources.GetObject("errNew.Icon")));
            // 
            // dlgBrowseMySqlConnector
            // 
            this.dlgBrowseMySqlConnector.DefaultExt = "dll";
            this.dlgBrowseMySqlConnector.FileName = "libmysql";
            this.dlgBrowseMySqlConnector.Filter = "Dynamic Link Libraries|*.dll";
            this.dlgBrowseMySqlConnector.Title = "Select the MySQL Connector to use.";
            // 
            // frmWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(574, 415);
            this.Controls.Add(this.wizardMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Altimail Server Database Setup Utility";
            ((System.ComponentModel.ISupportInitialize)(this.wizardMain)).EndInit();
            this.wpWelcome.ResumeLayout(false);
            this.wpAction.ResumeLayout(false);
            this.wpAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.wpDatabaseType.ResumeLayout(false);
            this.wpDatabaseType.PerformLayout();
            this.wpDatabaseConnection.ResumeLayout(false);
            this.wpDatabaseConnection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.wpDatabaseService.ResumeLayout(false);
            this.wpDatabaseService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.wpFinish.ResumeLayout(false);
            this.wpFinish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProgress1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNew)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private AeroWizard.WizardControl wizardMain;
      private AeroWizard.WizardPage wpWelcome;
      private AeroWizard.WizardPage wpAction;
      private AeroWizard.WizardPage wpDatabaseType;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.RadioButton optExistingDatabase;
      private System.Windows.Forms.RadioButton optNewDatabase;
      private System.Windows.Forms.Label label4;
      private AeroWizard.WizardPage wpDatabaseConnection;
      private AeroWizard.WizardPage wpDatabaseService;
      private AeroWizard.WizardPage wpFinish;
      private System.Windows.Forms.RadioButton optPostgreSQL;
      private System.Windows.Forms.RadioButton optMariaDB;
      private System.Windows.Forms.RadioButton optMySQL;
      private System.Windows.Forms.RadioButton optMSSQL;
      private System.Windows.Forms.TextBox txtDbServerAddress;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox txtDbName;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox txtAuthPassword;
      private System.Windows.Forms.TextBox txtAuthUsername;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.RadioButton optIntegratedAuth;
      private System.Windows.Forms.RadioButton optServerAuth;
      private System.Windows.Forms.PictureBox pictureBox2;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.TextBox txtDbPort;
      private System.Windows.Forms.ErrorProvider errNew;
      private System.Windows.Forms.ComboBox cboDatabaseService;
      private System.Windows.Forms.PictureBox imgProgress1;
      private System.Windows.Forms.Label lblProgress1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Button btnBrowseMySqlConnector;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.TextBox txtMySqlConnectorPath;
      private System.Windows.Forms.OpenFileDialog dlgBrowseMySqlConnector;
   }
}