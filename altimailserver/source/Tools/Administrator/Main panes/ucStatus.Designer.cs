
namespace AltimailServer.Administrator
{
    partial class ucStatus
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
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOpenImap4 = new System.Windows.Forms.Label();
            this.lblOpenPop3 = new System.Windows.Forms.Label();
            this.lblOpenSmtp = new System.Windows.Forms.Label();
            this.lblSpamIdentifiedCount = new System.Windows.Forms.Label();
            this.lblVirusDetectedCount = new System.Windows.Forms.Label();
            this.lblProcessedMessageCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIMAP = new System.Windows.Forms.Label();
            this.labelPOP3 = new System.Windows.Forms.Label();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelSMTP = new System.Windows.Forms.Label();
            this.labelCurrentSessions = new System.Windows.Forms.Label();
            this.labelStartTimeTitle = new System.Windows.Forms.Label();
            this.labelCurrentStatusTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDBVersion = new System.Windows.Forms.Label();
            this.labelMessagesContainingSpam = new System.Windows.Forms.Label();
            this.labelCurrentStatus = new System.Windows.Forms.Label();
            this.labelMessagesContainingVirus = new System.Windows.Forms.Label();
            this.labelProcessedMessages = new System.Windows.Forms.Label();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelServerHost = new System.Windows.Forms.Label();
            this.labelServerType = new System.Windows.Forms.Label();
            this.buttonShowWarning = new System.Windows.Forms.Button();
            this.listWarnings = new AltimailServer.Administrator.ucListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelWarnings = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.tabLogging = new System.Windows.Forms.TabPage();
            this.btnStartLiveLog = new System.Windows.Forms.Button();
            this.listLiveLog = new AltimailServer.Administrator.ucListView();
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSession = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnThread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripLiveLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemOnlyIncludeThisSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabDeliveryQueue = new System.Windows.Forms.TabPage();
            this.labelNumberOfMessages = new System.Windows.Forms.Label();
            this.buttonRefreshDeliveryQueue = new System.Windows.Forms.Button();
            this.listDeliveryQueue = new AltimailServer.Administrator.ucListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNextTry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNoOfTries = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuDeliveryQueue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSendNow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearQueue = new System.Windows.Forms.Button();
            this.timerLiveLog = new System.Windows.Forms.Timer(this.components);
            this.timerServerStats = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.tabLogging.SuspendLayout();
            this.contextMenuStripLiveLog.SuspendLayout();
            this.tabDeliveryQueue.SuspendLayout();
            this.contextMenuDeliveryQueue.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabServer);
            this.tabControl.Controls.Add(this.tabLogging);
            this.tabControl.Controls.Add(this.tabDeliveryQueue);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(733, 404);
            this.tabControl.TabIndex = 0;
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.label9);
            this.tabServer.Controls.Add(this.lblOpenImap4);
            this.tabServer.Controls.Add(this.lblOpenPop3);
            this.tabServer.Controls.Add(this.lblOpenSmtp);
            this.tabServer.Controls.Add(this.lblSpamIdentifiedCount);
            this.tabServer.Controls.Add(this.lblVirusDetectedCount);
            this.tabServer.Controls.Add(this.lblProcessedMessageCount);
            this.tabServer.Controls.Add(this.label8);
            this.tabServer.Controls.Add(this.label7);
            this.tabServer.Controls.Add(this.label6);
            this.tabServer.Controls.Add(this.label5);
            this.tabServer.Controls.Add(this.label2);
            this.tabServer.Controls.Add(this.label4);
            this.tabServer.Controls.Add(this.label3);
            this.tabServer.Controls.Add(this.labelIMAP);
            this.tabServer.Controls.Add(this.labelPOP3);
            this.tabServer.Controls.Add(this.labelStartTime);
            this.tabServer.Controls.Add(this.labelSMTP);
            this.tabServer.Controls.Add(this.labelCurrentSessions);
            this.tabServer.Controls.Add(this.labelStartTimeTitle);
            this.tabServer.Controls.Add(this.labelCurrentStatusTitle);
            this.tabServer.Controls.Add(this.label1);
            this.tabServer.Controls.Add(this.labelDBVersion);
            this.tabServer.Controls.Add(this.labelMessagesContainingSpam);
            this.tabServer.Controls.Add(this.labelCurrentStatus);
            this.tabServer.Controls.Add(this.labelMessagesContainingVirus);
            this.tabServer.Controls.Add(this.labelProcessedMessages);
            this.tabServer.Controls.Add(this.buttonStartStop);
            this.tabServer.Controls.Add(this.labelName);
            this.tabServer.Controls.Add(this.labelServerHost);
            this.tabServer.Controls.Add(this.labelServerType);
            this.tabServer.Controls.Add(this.buttonShowWarning);
            this.tabServer.Controls.Add(this.listWarnings);
            this.tabServer.Controls.Add(this.labelWarnings);
            this.tabServer.Controls.Add(this.labelVersion);
            this.tabServer.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(725, 378);
            this.tabServer.TabIndex = 0;
            this.tabServer.Text = " STATUS ";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Altimail Server Engine:";
            // 
            // lblOpenImap4
            // 
            this.lblOpenImap4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOpenImap4.AutoSize = true;
            this.lblOpenImap4.Location = new System.Drawing.Point(503, 151);
            this.lblOpenImap4.Name = "lblOpenImap4";
            this.lblOpenImap4.Size = new System.Drawing.Size(11, 13);
            this.lblOpenImap4.TabIndex = 39;
            this.lblOpenImap4.Text = "-";
            // 
            // lblOpenPop3
            // 
            this.lblOpenPop3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOpenPop3.AutoSize = true;
            this.lblOpenPop3.Location = new System.Drawing.Point(503, 134);
            this.lblOpenPop3.Name = "lblOpenPop3";
            this.lblOpenPop3.Size = new System.Drawing.Size(11, 13);
            this.lblOpenPop3.TabIndex = 38;
            this.lblOpenPop3.Text = "-";
            // 
            // lblOpenSmtp
            // 
            this.lblOpenSmtp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOpenSmtp.AutoSize = true;
            this.lblOpenSmtp.Location = new System.Drawing.Point(503, 117);
            this.lblOpenSmtp.Name = "lblOpenSmtp";
            this.lblOpenSmtp.Size = new System.Drawing.Size(11, 13);
            this.lblOpenSmtp.TabIndex = 37;
            this.lblOpenSmtp.Text = "-";
            // 
            // lblSpamIdentifiedCount
            // 
            this.lblSpamIdentifiedCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSpamIdentifiedCount.AutoSize = true;
            this.lblSpamIdentifiedCount.Location = new System.Drawing.Point(503, 71);
            this.lblSpamIdentifiedCount.Name = "lblSpamIdentifiedCount";
            this.lblSpamIdentifiedCount.Size = new System.Drawing.Size(11, 13);
            this.lblSpamIdentifiedCount.TabIndex = 36;
            this.lblSpamIdentifiedCount.Text = "-";
            // 
            // lblVirusDetectedCount
            // 
            this.lblVirusDetectedCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVirusDetectedCount.AutoSize = true;
            this.lblVirusDetectedCount.Location = new System.Drawing.Point(503, 54);
            this.lblVirusDetectedCount.Name = "lblVirusDetectedCount";
            this.lblVirusDetectedCount.Size = new System.Drawing.Size(11, 13);
            this.lblVirusDetectedCount.TabIndex = 35;
            this.lblVirusDetectedCount.Text = "-";
            // 
            // lblProcessedMessageCount
            // 
            this.lblProcessedMessageCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProcessedMessageCount.AutoSize = true;
            this.lblProcessedMessageCount.Location = new System.Drawing.Point(503, 37);
            this.lblProcessedMessageCount.Name = "lblProcessedMessageCount";
            this.lblProcessedMessageCount.Size = new System.Drawing.Size(11, 13);
            this.lblProcessedMessageCount.TabIndex = 34;
            this.lblProcessedMessageCount.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Version:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Database:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Server Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Database Type:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(379, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "PROCESSING STATS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Server Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Altimail Server 6";
            // 
            // labelIMAP
            // 
            this.labelIMAP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelIMAP.AutoSize = true;
            this.labelIMAP.Location = new System.Drawing.Point(380, 151);
            this.labelIMAP.Name = "labelIMAP";
            this.labelIMAP.Size = new System.Drawing.Size(83, 13);
            this.labelIMAP.TabIndex = 23;
            this.labelIMAP.Text = "IMAP Sessions:";
            // 
            // labelPOP3
            // 
            this.labelPOP3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPOP3.AutoSize = true;
            this.labelPOP3.Location = new System.Drawing.Point(379, 134);
            this.labelPOP3.Name = "labelPOP3";
            this.labelPOP3.Size = new System.Drawing.Size(84, 13);
            this.labelPOP3.TabIndex = 22;
            this.labelPOP3.Text = "POP3 Sessions:";
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelStartTime.Location = new System.Drawing.Point(119, 71);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(15, 13);
            this.labelStartTime.TabIndex = 21;
            this.labelStartTime.Text = "--";
            // 
            // labelSMTP
            // 
            this.labelSMTP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelSMTP.AutoSize = true;
            this.labelSMTP.Location = new System.Drawing.Point(379, 117);
            this.labelSMTP.Name = "labelSMTP";
            this.labelSMTP.Size = new System.Drawing.Size(84, 13);
            this.labelSMTP.TabIndex = 21;
            this.labelSMTP.Text = "SMTP Sessions:";
            // 
            // labelCurrentSessions
            // 
            this.labelCurrentSessions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelCurrentSessions.AutoSize = true;
            this.labelCurrentSessions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelCurrentSessions.Location = new System.Drawing.Point(379, 101);
            this.labelCurrentSessions.Name = "labelCurrentSessions";
            this.labelCurrentSessions.Size = new System.Drawing.Size(90, 13);
            this.labelCurrentSessions.TabIndex = 17;
            this.labelCurrentSessions.Text = "OPEN SESSIONS";
            // 
            // labelStartTimeTitle
            // 
            this.labelStartTimeTitle.AutoSize = true;
            this.labelStartTimeTitle.Location = new System.Drawing.Point(13, 71);
            this.labelStartTimeTitle.Name = "labelStartTimeTitle";
            this.labelStartTimeTitle.Size = new System.Drawing.Size(89, 13);
            this.labelStartTimeTitle.TabIndex = 20;
            this.labelStartTimeTitle.Text = "Server Up Since:";
            // 
            // labelCurrentStatusTitle
            // 
            this.labelCurrentStatusTitle.AutoSize = true;
            this.labelCurrentStatusTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelCurrentStatusTitle.Location = new System.Drawing.Point(13, 54);
            this.labelCurrentStatusTitle.Name = "labelCurrentStatusTitle";
            this.labelCurrentStatusTitle.Size = new System.Drawing.Size(84, 13);
            this.labelCurrentStatusTitle.TabIndex = 0;
            this.labelCurrentStatusTitle.Text = "Current Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(133, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "(use Windows Service Manager to start/stop/restart the service)";
            // 
            // labelDBVersion
            // 
            this.labelDBVersion.AutoSize = true;
            this.labelDBVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelDBVersion.Location = new System.Drawing.Point(119, 152);
            this.labelDBVersion.Name = "labelDBVersion";
            this.labelDBVersion.Size = new System.Drawing.Size(15, 13);
            this.labelDBVersion.TabIndex = 18;
            this.labelDBVersion.Text = "--";
            // 
            // labelMessagesContainingSpam
            // 
            this.labelMessagesContainingSpam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelMessagesContainingSpam.AutoSize = true;
            this.labelMessagesContainingSpam.Location = new System.Drawing.Point(379, 71);
            this.labelMessagesContainingSpam.Name = "labelMessagesContainingSpam";
            this.labelMessagesContainingSpam.Size = new System.Drawing.Size(91, 13);
            this.labelMessagesContainingSpam.TabIndex = 20;
            this.labelMessagesContainingSpam.Text = "Identified Spam:";
            // 
            // labelCurrentStatus
            // 
            this.labelCurrentStatus.AutoSize = true;
            this.labelCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelCurrentStatus.Location = new System.Drawing.Point(119, 54);
            this.labelCurrentStatus.Name = "labelCurrentStatus";
            this.labelCurrentStatus.Size = new System.Drawing.Size(15, 13);
            this.labelCurrentStatus.TabIndex = 2;
            this.labelCurrentStatus.Text = "--";
            // 
            // labelMessagesContainingVirus
            // 
            this.labelMessagesContainingVirus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelMessagesContainingVirus.AutoSize = true;
            this.labelMessagesContainingVirus.Location = new System.Drawing.Point(379, 54);
            this.labelMessagesContainingVirus.Name = "labelMessagesContainingVirus";
            this.labelMessagesContainingVirus.Size = new System.Drawing.Size(96, 13);
            this.labelMessagesContainingVirus.TabIndex = 19;
            this.labelMessagesContainingVirus.Text = "Viruses Detected:";
            // 
            // labelProcessedMessages
            // 
            this.labelProcessedMessages.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelProcessedMessages.AutoSize = true;
            this.labelProcessedMessages.Location = new System.Drawing.Point(379, 37);
            this.labelProcessedMessages.Name = "labelProcessedMessages";
            this.labelProcessedMessages.Size = new System.Drawing.Size(114, 13);
            this.labelProcessedMessages.TabIndex = 18;
            this.labelProcessedMessages.Text = "Processed Messages:";
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonStartStop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartStop.Location = new System.Drawing.Point(136, 179);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(100, 25);
            this.buttonStartStop.TabIndex = 3;
            this.buttonStartStop.Text = "Start Altimail";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelName.Location = new System.Drawing.Point(119, 135);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(15, 13);
            this.labelName.TabIndex = 15;
            this.labelName.Text = "--";
            // 
            // labelServerHost
            // 
            this.labelServerHost.AutoSize = true;
            this.labelServerHost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelServerHost.Location = new System.Drawing.Point(119, 118);
            this.labelServerHost.Name = "labelServerHost";
            this.labelServerHost.Size = new System.Drawing.Size(15, 13);
            this.labelServerHost.TabIndex = 13;
            this.labelServerHost.Text = "--";
            // 
            // labelServerType
            // 
            this.labelServerType.AutoSize = true;
            this.labelServerType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelServerType.Location = new System.Drawing.Point(119, 101);
            this.labelServerType.Name = "labelServerType";
            this.labelServerType.Size = new System.Drawing.Size(15, 13);
            this.labelServerType.TabIndex = 11;
            this.labelServerType.Text = "--";
            // 
            // buttonShowWarning
            // 
            this.buttonShowWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowWarning.Enabled = false;
            this.buttonShowWarning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonShowWarning.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowWarning.Location = new System.Drawing.Point(659, 244);
            this.buttonShowWarning.Name = "buttonShowWarning";
            this.buttonShowWarning.Size = new System.Drawing.Size(60, 25);
            this.buttonShowWarning.TabIndex = 9;
            this.buttonShowWarning.Text = "Show";
            this.buttonShowWarning.UseVisualStyleBackColor = true;
            this.buttonShowWarning.Click += new System.EventHandler(this.buttonShowWarning_Click);
            // 
            // listWarnings
            // 
            this.listWarnings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listWarnings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listWarnings.FullRowSelect = true;
            this.listWarnings.HideSelection = false;
            this.listWarnings.Location = new System.Drawing.Point(11, 244);
            this.listWarnings.Name = "listWarnings";
            this.listWarnings.ShowItemToolTips = true;
            this.listWarnings.Size = new System.Drawing.Size(642, 128);
            this.listWarnings.TabIndex = 8;
            this.listWarnings.UseCompatibleStateImageBehavior = false;
            this.listWarnings.View = System.Windows.Forms.View.Details;
            this.listWarnings.SelectedIndexChanged += new System.EventHandler(this.listWarnings_SelectedIndexChanged);
            this.listWarnings.DoubleClick += new System.EventHandler(this.listWarnings_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Severity";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 300;
            // 
            // labelWarnings
            // 
            this.labelWarnings.AutoSize = true;
            this.labelWarnings.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarnings.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarnings.Location = new System.Drawing.Point(8, 228);
            this.labelWarnings.Name = "labelWarnings";
            this.labelWarnings.Size = new System.Drawing.Size(137, 13);
            this.labelWarnings.TabIndex = 7;
            this.labelWarnings.Text = "Configuration warnings";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelVersion.Location = new System.Drawing.Point(119, 37);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(31, 13);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "6.0.0";
            // 
            // tabLogging
            // 
            this.tabLogging.Controls.Add(this.btnStartLiveLog);
            this.tabLogging.Controls.Add(this.listLiveLog);
            this.tabLogging.Controls.Add(this.btnClear);
            this.tabLogging.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabLogging.Location = new System.Drawing.Point(4, 22);
            this.tabLogging.Name = "tabLogging";
            this.tabLogging.Size = new System.Drawing.Size(725, 378);
            this.tabLogging.TabIndex = 2;
            this.tabLogging.Text = " LOGGING ";
            this.tabLogging.UseVisualStyleBackColor = true;
            // 
            // btnStartLiveLog
            // 
            this.btnStartLiveLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStartLiveLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLiveLog.Location = new System.Drawing.Point(16, 8);
            this.btnStartLiveLog.Name = "btnStartLiveLog";
            this.btnStartLiveLog.Size = new System.Drawing.Size(100, 25);
            this.btnStartLiveLog.TabIndex = 4;
            this.btnStartLiveLog.Text = "Start";
            this.btnStartLiveLog.UseVisualStyleBackColor = true;
            this.btnStartLiveLog.Click += new System.EventHandler(this.btnStartLiveLog_Click);
            // 
            // listLiveLog
            // 
            this.listLiveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listLiveLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnType,
            this.columnSession,
            this.columnThread,
            this.columnTime,
            this.columnIP,
            this.columnText});
            this.listLiveLog.ContextMenuStrip = this.contextMenuStripLiveLog;
            this.listLiveLog.FullRowSelect = true;
            this.listLiveLog.HideSelection = false;
            this.listLiveLog.Location = new System.Drawing.Point(16, 40);
            this.listLiveLog.Name = "listLiveLog";
            this.listLiveLog.Size = new System.Drawing.Size(699, 324);
            this.listLiveLog.TabIndex = 6;
            this.listLiveLog.UseCompatibleStateImageBehavior = false;
            this.listLiveLog.View = System.Windows.Forms.View.Details;
            // 
            // columnType
            // 
            this.columnType.Text = "Type";
            this.columnType.Width = 64;
            // 
            // columnSession
            // 
            this.columnSession.Text = "Session";
            // 
            // columnThread
            // 
            this.columnThread.Text = "Thread";
            // 
            // columnTime
            // 
            this.columnTime.Text = "Time";
            this.columnTime.Width = 100;
            // 
            // columnIP
            // 
            this.columnIP.Text = "IP";
            // 
            // columnText
            // 
            this.columnText.Text = "Text";
            this.columnText.Width = 250;
            // 
            // contextMenuStripLiveLog
            // 
            this.contextMenuStripLiveLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOnlyIncludeThisSessionToolStripMenuItem});
            this.contextMenuStripLiveLog.Name = "contextMenuStripLiveLog";
            this.contextMenuStripLiveLog.Size = new System.Drawing.Size(205, 26);
            // 
            // menuItemOnlyIncludeThisSessionToolStripMenuItem
            // 
            this.menuItemOnlyIncludeThisSessionToolStripMenuItem.Name = "menuItemOnlyIncludeThisSessionToolStripMenuItem";
            this.menuItemOnlyIncludeThisSessionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.menuItemOnlyIncludeThisSessionToolStripMenuItem.Text = "Only include this session";
            this.menuItemOnlyIncludeThisSessionToolStripMenuItem.Click += new System.EventHandler(this.menuItemOnlyIncludeThisSessionToolStripMenuItem_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(122, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 25);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tabDeliveryQueue
            // 
            this.tabDeliveryQueue.Controls.Add(this.labelNumberOfMessages);
            this.tabDeliveryQueue.Controls.Add(this.buttonRefreshDeliveryQueue);
            this.tabDeliveryQueue.Controls.Add(this.listDeliveryQueue);
            this.tabDeliveryQueue.Controls.Add(this.btnClearQueue);
            this.tabDeliveryQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabDeliveryQueue.Location = new System.Drawing.Point(4, 22);
            this.tabDeliveryQueue.Name = "tabDeliveryQueue";
            this.tabDeliveryQueue.Size = new System.Drawing.Size(725, 378);
            this.tabDeliveryQueue.TabIndex = 3;
            this.tabDeliveryQueue.Text = " DELIVERY QUEUE ";
            this.tabDeliveryQueue.UseVisualStyleBackColor = true;
            // 
            // labelNumberOfMessages
            // 
            this.labelNumberOfMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNumberOfMessages.AutoSize = true;
            this.labelNumberOfMessages.Location = new System.Drawing.Point(16, 360);
            this.labelNumberOfMessages.Name = "labelNumberOfMessages";
            this.labelNumberOfMessages.Size = new System.Drawing.Size(0, 13);
            this.labelNumberOfMessages.TabIndex = 10;
            // 
            // buttonRefreshDeliveryQueue
            // 
            this.buttonRefreshDeliveryQueue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRefreshDeliveryQueue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshDeliveryQueue.Location = new System.Drawing.Point(16, 8);
            this.buttonRefreshDeliveryQueue.Name = "buttonRefreshDeliveryQueue";
            this.buttonRefreshDeliveryQueue.Size = new System.Drawing.Size(100, 25);
            this.buttonRefreshDeliveryQueue.TabIndex = 7;
            this.buttonRefreshDeliveryQueue.Text = "Refresh";
            this.buttonRefreshDeliveryQueue.UseVisualStyleBackColor = true;
            this.buttonRefreshDeliveryQueue.Click += new System.EventHandler(this.buttonRefreshDeliveryQueue_Click);
            // 
            // listDeliveryQueue
            // 
            this.listDeliveryQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDeliveryQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnCreated,
            this.columnFrom,
            this.columnTo,
            this.columnNextTry,
            this.columnNoOfTries,
            this.columnFilename});
            this.listDeliveryQueue.ContextMenuStrip = this.contextMenuDeliveryQueue;
            this.listDeliveryQueue.FullRowSelect = true;
            this.listDeliveryQueue.HideSelection = false;
            this.listDeliveryQueue.Location = new System.Drawing.Point(16, 40);
            this.listDeliveryQueue.Name = "listDeliveryQueue";
            this.listDeliveryQueue.Size = new System.Drawing.Size(706, 312);
            this.listDeliveryQueue.TabIndex = 9;
            this.listDeliveryQueue.UseCompatibleStateImageBehavior = false;
            this.listDeliveryQueue.View = System.Windows.Forms.View.Details;
            this.listDeliveryQueue.SelectedIndexChanged += new System.EventHandler(this.listDeliveryQueue_SelectedIndexChanged);
            this.listDeliveryQueue.DoubleClick += new System.EventHandler(this.listDeliveryQueue_DoubleClick);
            // 
            // columnID
            // 
            this.columnID.Tag = "Numeric";
            this.columnID.Text = "ID";
            this.columnID.Width = 40;
            // 
            // columnCreated
            // 
            this.columnCreated.Text = "Created";
            this.columnCreated.Width = 100;
            // 
            // columnFrom
            // 
            this.columnFrom.Text = "From";
            this.columnFrom.Width = 100;
            // 
            // columnTo
            // 
            this.columnTo.Text = "To";
            this.columnTo.Width = 100;
            // 
            // columnNextTry
            // 
            this.columnNextTry.Text = "Next try";
            this.columnNextTry.Width = 140;
            // 
            // columnNoOfTries
            // 
            this.columnNoOfTries.Tag = "Numeric";
            this.columnNoOfTries.Text = "Number of retries";
            this.columnNoOfTries.Width = 70;
            // 
            // columnFilename
            // 
            this.columnFilename.Text = "File name";
            this.columnFilename.Width = 150;
            // 
            // contextMenuDeliveryQueue
            // 
            this.contextMenuDeliveryQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShow,
            this.menuItemSendNow,
            this.menuItemDelete});
            this.contextMenuDeliveryQueue.Name = "contextMenuDeliveryQueue";
            this.contextMenuDeliveryQueue.Size = new System.Drawing.Size(127, 70);
            // 
            // menuItemShow
            // 
            this.menuItemShow.Name = "menuItemShow";
            this.menuItemShow.Size = new System.Drawing.Size(126, 22);
            this.menuItemShow.Text = "Show";
            this.menuItemShow.Click += new System.EventHandler(this.menuItemShow_Click);
            // 
            // menuItemSendNow
            // 
            this.menuItemSendNow.Name = "menuItemSendNow";
            this.menuItemSendNow.Size = new System.Drawing.Size(126, 22);
            this.menuItemSendNow.Text = "Send now";
            this.menuItemSendNow.Click += new System.EventHandler(this.menuItemSendNow_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(126, 22);
            this.menuItemDelete.Text = "Remove";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClearQueue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearQueue.Location = new System.Drawing.Point(122, 8);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(100, 25);
            this.btnClearQueue.TabIndex = 8;
            this.btnClearQueue.Text = "Clear queue";
            this.btnClearQueue.UseVisualStyleBackColor = true;
            this.btnClearQueue.Click += new System.EventHandler(this.btnClearQueue_Click);
            // 
            // timerLiveLog
            // 
            this.timerLiveLog.Interval = 1000;
            this.timerLiveLog.Tick += new System.EventHandler(this.timerLiveLog_Tick);
            // 
            // timerServerStats
            // 
            this.timerServerStats.Enabled = true;
            this.timerServerStats.Interval = 2000;
            this.timerServerStats.Tick += new System.EventHandler(this.timerServerStats_Tick);
            // 
            // ucStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucStatus";
            this.Size = new System.Drawing.Size(733, 404);
            this.tabControl.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.tabLogging.ResumeLayout(false);
            this.contextMenuStripLiveLog.ResumeLayout(false);
            this.tabDeliveryQueue.ResumeLayout(false);
            this.tabDeliveryQueue.PerformLayout();
            this.contextMenuDeliveryQueue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.Label labelCurrentStatusTitle;
        private System.Windows.Forms.TabPage tabLogging;
        private System.Windows.Forms.TabPage tabDeliveryQueue;
        private System.Windows.Forms.Label labelCurrentStatus;
       private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Label labelWarnings;
        private System.Windows.Forms.Label labelVersion;
        private AltimailServer.Administrator.ucListView listLiveLog;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStartLiveLog;
        private System.Windows.Forms.ColumnHeader columnSession;
        private System.Windows.Forms.ColumnHeader columnThread;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.ColumnHeader columnIP;
        private System.Windows.Forms.ColumnHeader columnText;
        private System.Windows.Forms.Timer timerLiveLog;
        private System.Windows.Forms.Button buttonRefreshDeliveryQueue;
        private AltimailServer.Administrator.ucListView listDeliveryQueue;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnCreated;
        private System.Windows.Forms.ColumnHeader columnFrom;
        private System.Windows.Forms.ColumnHeader columnTo;
        private System.Windows.Forms.ColumnHeader columnNextTry;
        private System.Windows.Forms.ColumnHeader columnNoOfTries;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ContextMenuStrip contextMenuDeliveryQueue;
        private System.Windows.Forms.ToolStripMenuItem menuItemSendNow;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
       private ucListView listWarnings;
       private System.Windows.Forms.ColumnHeader columnHeader1;
       private System.Windows.Forms.ColumnHeader columnHeader2;
       private System.Windows.Forms.ColumnHeader columnHeader3;
       private System.Windows.Forms.Button buttonShowWarning;
       private System.Windows.Forms.Label labelNumberOfMessages;
       private System.Windows.Forms.ContextMenuStrip contextMenuStripLiveLog;
       private System.Windows.Forms.ToolStripMenuItem menuItemOnlyIncludeThisSessionToolStripMenuItem;
       private System.Windows.Forms.Label labelServerType;
       private System.Windows.Forms.Label labelName;
       private System.Windows.Forms.Label labelServerHost;
       private System.Windows.Forms.ToolStripMenuItem menuItemShow;
       private System.Windows.Forms.Timer timerServerStats;
       private System.Windows.Forms.Label labelDBVersion;
       private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label labelStartTime;
      private System.Windows.Forms.Label labelStartTimeTitle;
      private System.Windows.Forms.Label labelIMAP;
      private System.Windows.Forms.Label labelPOP3;
      private System.Windows.Forms.Label labelSMTP;
      private System.Windows.Forms.Label labelMessagesContainingSpam;
      private System.Windows.Forms.Label labelMessagesContainingVirus;
      private System.Windows.Forms.Label labelProcessedMessages;
      private System.Windows.Forms.Label labelCurrentSessions;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label lblProcessedMessageCount;
      private System.Windows.Forms.Label lblOpenImap4;
      private System.Windows.Forms.Label lblOpenPop3;
      private System.Windows.Forms.Label lblOpenSmtp;
      private System.Windows.Forms.Label lblSpamIdentifiedCount;
      private System.Windows.Forms.Label lblVirusDetectedCount;
      private System.Windows.Forms.Label label9;
   }
}
