namespace AltimailServer.Administrator
{
    partial class ucAntiVirus
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textVirusScanMaxSize = new AltimailServer.Shared.ucText();
            this.labelMaxSizeToScan = new System.Windows.Forms.Label();
            this.radioDeleteAttachments = new AltimailServer.Administrator.Controls.ucRadioButton();
            this.checkNotifyReceiver = new AltimailServer.Administrator.Controls.ucCheckbox();
            this.checkNotifySender = new AltimailServer.Administrator.Controls.ucCheckbox();
            this.radioDeleteEmail = new AltimailServer.Administrator.Controls.ucRadioButton();
            this.labelWhenAVirusIsFound = new System.Windows.Forms.Label();
            this.tabClamAV = new System.Windows.Forms.TabPage();
            this.buttonClamAVTest = new System.Windows.Forms.Button();
            this.labelTCPIPPort = new System.Windows.Forms.Label();
            this.labelHostname = new System.Windows.Forms.Label();
            this.textClamAVPort = new AltimailServer.Shared.ucText();
            this.textClamAVHostName = new AltimailServer.Shared.ucText();
            this.checkClamAVEnabled = new AltimailServer.Administrator.Controls.ucCheckbox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonClamWinTest = new System.Windows.Forms.Button();
            this.buttonAutoDetect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textClamScanDatabase = new AltimailServer.Shared.ucText();
            this.labelClamScanExecutable = new System.Windows.Forms.Label();
            this.textClamScanExecutable = new AltimailServer.Shared.ucText();
            this.checkUseClamWin = new AltimailServer.Administrator.Controls.ucCheckbox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonCustomScannerTest = new System.Windows.Forms.Button();
            this.labelReturnValue = new System.Windows.Forms.Label();
            this.textCustomScannerReturnValue = new AltimailServer.Shared.ucText();
            this.labelScannerExecutable = new System.Windows.Forms.Label();
            this.textCustomScannerExecutable = new AltimailServer.Shared.ucText();
            this.checkUseCustomScanner = new AltimailServer.Administrator.Controls.ucCheckbox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.checkBlockAttachmentsEnabled = new AltimailServer.Administrator.Controls.ucCheckbox();
            this.buttonEditBlockedAttachment = new System.Windows.Forms.Button();
            this.buttonDeleteBlockedAttachment = new System.Windows.Forms.Button();
            this.buttonAddBlockedAttachment = new System.Windows.Forms.Button();
            this.listBlockedAttachments = new AltimailServer.Administrator.ucListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabClamAV.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabClamAV);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(731, 476);
            this.tabControl.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textVirusScanMaxSize);
            this.tabPage1.Controls.Add(this.labelMaxSizeToScan);
            this.tabPage1.Controls.Add(this.radioDeleteAttachments);
            this.tabPage1.Controls.Add(this.checkNotifyReceiver);
            this.tabPage1.Controls.Add(this.checkNotifySender);
            this.tabPage1.Controls.Add(this.radioDeleteEmail);
            this.tabPage1.Controls.Add(this.labelWhenAVirusIsFound);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(723, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textVirusScanMaxSize
            // 
            this.textVirusScanMaxSize.Location = new System.Drawing.Point(9, 152);
            this.textVirusScanMaxSize.Name = "textVirusScanMaxSize";
            this.textVirusScanMaxSize.Number = 0;
            this.textVirusScanMaxSize.Number64 = ((long)(0));
            this.textVirusScanMaxSize.Numeric = true;
            this.textVirusScanMaxSize.Size = new System.Drawing.Size(116, 20);
            this.textVirusScanMaxSize.TabIndex = 27;
            // 
            // labelMaxSizeToScan
            // 
            this.labelMaxSizeToScan.AutoSize = true;
            this.labelMaxSizeToScan.Location = new System.Drawing.Point(7, 136);
            this.labelMaxSizeToScan.Name = "labelMaxSizeToScan";
            this.labelMaxSizeToScan.Size = new System.Drawing.Size(203, 13);
            this.labelMaxSizeToScan.TabIndex = 26;
            this.labelMaxSizeToScan.Text = "Maximum message size to virus scan (KB)";
            // 
            // radioDeleteAttachments
            // 
            this.radioDeleteAttachments.AutoSize = true;
            this.radioDeleteAttachments.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioDeleteAttachments.Location = new System.Drawing.Point(33, 109);
            this.radioDeleteAttachments.Name = "radioDeleteAttachments";
            this.radioDeleteAttachments.Size = new System.Drawing.Size(123, 18);
            this.radioDeleteAttachments.TabIndex = 25;
            this.radioDeleteAttachments.Text = "Delete attachments";
            this.radioDeleteAttachments.UseVisualStyleBackColor = true;
            // 
            // checkNotifyReceiver
            // 
            this.checkNotifyReceiver.AutoSize = true;
            this.checkNotifyReceiver.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkNotifyReceiver.Location = new System.Drawing.Point(59, 86);
            this.checkNotifyReceiver.Name = "checkNotifyReceiver";
            this.checkNotifyReceiver.Size = new System.Drawing.Size(102, 18);
            this.checkNotifyReceiver.TabIndex = 24;
            this.checkNotifyReceiver.Text = "Notify recipient";
            this.checkNotifyReceiver.UseVisualStyleBackColor = true;
            // 
            // checkNotifySender
            // 
            this.checkNotifySender.AutoSize = true;
            this.checkNotifySender.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkNotifySender.Location = new System.Drawing.Point(59, 63);
            this.checkNotifySender.Name = "checkNotifySender";
            this.checkNotifySender.Size = new System.Drawing.Size(94, 18);
            this.checkNotifySender.TabIndex = 23;
            this.checkNotifySender.Text = "Notify sender";
            this.checkNotifySender.UseVisualStyleBackColor = true;
            // 
            // radioDeleteEmail
            // 
            this.radioDeleteEmail.AutoSize = true;
            this.radioDeleteEmail.Checked = true;
            this.radioDeleteEmail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioDeleteEmail.Location = new System.Drawing.Point(33, 40);
            this.radioDeleteEmail.Name = "radioDeleteEmail";
            this.radioDeleteEmail.Size = new System.Drawing.Size(92, 18);
            this.radioDeleteEmail.TabIndex = 22;
            this.radioDeleteEmail.TabStop = true;
            this.radioDeleteEmail.Text = "Delete e-mail";
            this.radioDeleteEmail.UseVisualStyleBackColor = true;
            this.radioDeleteEmail.CheckedChanged += new System.EventHandler(this.radioDeleteEmail_CheckedChanged);
            // 
            // labelWhenAVirusIsFound
            // 
            this.labelWhenAVirusIsFound.AutoSize = true;
            this.labelWhenAVirusIsFound.Location = new System.Drawing.Point(6, 14);
            this.labelWhenAVirusIsFound.Name = "labelWhenAVirusIsFound";
            this.labelWhenAVirusIsFound.Size = new System.Drawing.Size(110, 13);
            this.labelWhenAVirusIsFound.TabIndex = 21;
            this.labelWhenAVirusIsFound.Text = "When a virus is found";
            // 
            // tabClamAV
            // 
            this.tabClamAV.Controls.Add(this.buttonClamAVTest);
            this.tabClamAV.Controls.Add(this.labelTCPIPPort);
            this.tabClamAV.Controls.Add(this.labelHostname);
            this.tabClamAV.Controls.Add(this.textClamAVPort);
            this.tabClamAV.Controls.Add(this.textClamAVHostName);
            this.tabClamAV.Controls.Add(this.checkClamAVEnabled);
            this.tabClamAV.Location = new System.Drawing.Point(4, 22);
            this.tabClamAV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabClamAV.Name = "tabClamAV";
            this.tabClamAV.Size = new System.Drawing.Size(723, 450);
            this.tabClamAV.TabIndex = 4;
            this.tabClamAV.Text = "ClamAV";
            this.tabClamAV.UseVisualStyleBackColor = true;
            // 
            // buttonClamAVTest
            // 
            this.buttonClamAVTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonClamAVTest.Location = new System.Drawing.Point(37, 140);
            this.buttonClamAVTest.Name = "buttonClamAVTest";
            this.buttonClamAVTest.Size = new System.Drawing.Size(114, 27);
            this.buttonClamAVTest.TabIndex = 33;
            this.buttonClamAVTest.Text = "Test...";
            this.buttonClamAVTest.UseVisualStyleBackColor = true;
            this.buttonClamAVTest.Click += new System.EventHandler(this.buttonClamAVTest_Click);
            // 
            // labelTCPIPPort
            // 
            this.labelTCPIPPort.AutoSize = true;
            this.labelTCPIPPort.Location = new System.Drawing.Point(34, 90);
            this.labelTCPIPPort.Name = "labelTCPIPPort";
            this.labelTCPIPPort.Size = new System.Drawing.Size(64, 13);
            this.labelTCPIPPort.TabIndex = 31;
            this.labelTCPIPPort.Text = "TCP/IP port";
            // 
            // labelHostname
            // 
            this.labelHostname.AutoSize = true;
            this.labelHostname.Location = new System.Drawing.Point(34, 43);
            this.labelHostname.Name = "labelHostname";
            this.labelHostname.Size = new System.Drawing.Size(58, 13);
            this.labelHostname.TabIndex = 29;
            this.labelHostname.Text = "Host name";
            // 
            // textClamAVPort
            // 
            this.textClamAVPort.Location = new System.Drawing.Point(37, 106);
            this.textClamAVPort.Name = "textClamAVPort";
            this.textClamAVPort.Number = 0;
            this.textClamAVPort.Number64 = ((long)(0));
            this.textClamAVPort.Numeric = true;
            this.textClamAVPort.Size = new System.Drawing.Size(78, 20);
            this.textClamAVPort.TabIndex = 32;
            // 
            // textClamAVHostName
            // 
            this.textClamAVHostName.Location = new System.Drawing.Point(37, 59);
            this.textClamAVHostName.Name = "textClamAVHostName";
            this.textClamAVHostName.Number = 0;
            this.textClamAVHostName.Number64 = ((long)(0));
            this.textClamAVHostName.Numeric = false;
            this.textClamAVHostName.Size = new System.Drawing.Size(190, 20);
            this.textClamAVHostName.TabIndex = 30;
            // 
            // checkClamAVEnabled
            // 
            this.checkClamAVEnabled.AutoSize = true;
            this.checkClamAVEnabled.Checked = true;
            this.checkClamAVEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkClamAVEnabled.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkClamAVEnabled.Location = new System.Drawing.Point(18, 18);
            this.checkClamAVEnabled.Name = "checkClamAVEnabled";
            this.checkClamAVEnabled.Size = new System.Drawing.Size(91, 18);
            this.checkClamAVEnabled.TabIndex = 14;
            this.checkClamAVEnabled.Text = "Use ClamAV";
            this.checkClamAVEnabled.UseVisualStyleBackColor = true;
            this.checkClamAVEnabled.CheckedChanged += new System.EventHandler(this.checkClamAVEnabled_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonClamWinTest);
            this.tabPage2.Controls.Add(this.buttonAutoDetect);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textClamScanDatabase);
            this.tabPage2.Controls.Add(this.labelClamScanExecutable);
            this.tabPage2.Controls.Add(this.textClamScanExecutable);
            this.tabPage2.Controls.Add(this.checkUseClamWin);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(723, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ClamWin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonClamWinTest
            // 
            this.buttonClamWinTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonClamWinTest.Location = new System.Drawing.Point(37, 140);
            this.buttonClamWinTest.Name = "buttonClamWinTest";
            this.buttonClamWinTest.Size = new System.Drawing.Size(114, 27);
            this.buttonClamWinTest.TabIndex = 34;
            this.buttonClamWinTest.Text = "Test...";
            this.buttonClamWinTest.UseVisualStyleBackColor = true;
            this.buttonClamWinTest.Click += new System.EventHandler(this.buttonClamWinTest_Click);
            // 
            // buttonAutoDetect
            // 
            this.buttonAutoDetect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAutoDetect.Location = new System.Drawing.Point(358, 56);
            this.buttonAutoDetect.Name = "buttonAutoDetect";
            this.buttonAutoDetect.Size = new System.Drawing.Size(100, 25);
            this.buttonAutoDetect.TabIndex = 32;
            this.buttonAutoDetect.Text = "Auto-detect";
            this.buttonAutoDetect.UseVisualStyleBackColor = true;
            this.buttonAutoDetect.Click += new System.EventHandler(this.buttonAutoDetect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Path to ClamScan database";
            // 
            // textClamScanDatabase
            // 
            this.textClamScanDatabase.Location = new System.Drawing.Point(37, 106);
            this.textClamScanDatabase.Name = "textClamScanDatabase";
            this.textClamScanDatabase.Number = 0;
            this.textClamScanDatabase.Number64 = ((long)(0));
            this.textClamScanDatabase.Numeric = false;
            this.textClamScanDatabase.Size = new System.Drawing.Size(315, 20);
            this.textClamScanDatabase.TabIndex = 30;
            // 
            // labelClamScanExecutable
            // 
            this.labelClamScanExecutable.AutoSize = true;
            this.labelClamScanExecutable.Location = new System.Drawing.Point(34, 43);
            this.labelClamScanExecutable.Name = "labelClamScanExecutable";
            this.labelClamScanExecutable.Size = new System.Drawing.Size(110, 13);
            this.labelClamScanExecutable.TabIndex = 29;
            this.labelClamScanExecutable.Text = "ClamScan executable";
            // 
            // textClamScanExecutable
            // 
            this.textClamScanExecutable.Location = new System.Drawing.Point(37, 59);
            this.textClamScanExecutable.Name = "textClamScanExecutable";
            this.textClamScanExecutable.Number = 0;
            this.textClamScanExecutable.Number64 = ((long)(0));
            this.textClamScanExecutable.Numeric = false;
            this.textClamScanExecutable.Size = new System.Drawing.Size(315, 20);
            this.textClamScanExecutable.TabIndex = 28;
            // 
            // checkUseClamWin
            // 
            this.checkUseClamWin.AutoSize = true;
            this.checkUseClamWin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkUseClamWin.Location = new System.Drawing.Point(18, 18);
            this.checkUseClamWin.Name = "checkUseClamWin";
            this.checkUseClamWin.Size = new System.Drawing.Size(96, 18);
            this.checkUseClamWin.TabIndex = 25;
            this.checkUseClamWin.Text = "Use ClamWin";
            this.checkUseClamWin.UseVisualStyleBackColor = true;
            this.checkUseClamWin.CheckedChanged += new System.EventHandler(this.checkUseClamWin_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonCustomScannerTest);
            this.tabPage3.Controls.Add(this.labelReturnValue);
            this.tabPage3.Controls.Add(this.textCustomScannerReturnValue);
            this.tabPage3.Controls.Add(this.labelScannerExecutable);
            this.tabPage3.Controls.Add(this.textCustomScannerExecutable);
            this.tabPage3.Controls.Add(this.checkUseCustomScanner);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(723, 450);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "External virus scanner";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonCustomScannerTest
            // 
            this.buttonCustomScannerTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCustomScannerTest.Location = new System.Drawing.Point(37, 140);
            this.buttonCustomScannerTest.Name = "buttonCustomScannerTest";
            this.buttonCustomScannerTest.Size = new System.Drawing.Size(114, 27);
            this.buttonCustomScannerTest.TabIndex = 37;
            this.buttonCustomScannerTest.Text = "Test...";
            this.buttonCustomScannerTest.UseVisualStyleBackColor = true;
            this.buttonCustomScannerTest.Click += new System.EventHandler(this.buttonCustomScannerTest_Click);
            // 
            // labelReturnValue
            // 
            this.labelReturnValue.AutoSize = true;
            this.labelReturnValue.Location = new System.Drawing.Point(34, 90);
            this.labelReturnValue.Name = "labelReturnValue";
            this.labelReturnValue.Size = new System.Drawing.Size(68, 13);
            this.labelReturnValue.TabIndex = 36;
            this.labelReturnValue.Text = "Return value";
            // 
            // textCustomScannerReturnValue
            // 
            this.textCustomScannerReturnValue.Location = new System.Drawing.Point(37, 106);
            this.textCustomScannerReturnValue.Name = "textCustomScannerReturnValue";
            this.textCustomScannerReturnValue.Number = 0;
            this.textCustomScannerReturnValue.Number64 = ((long)(0));
            this.textCustomScannerReturnValue.Numeric = true;
            this.textCustomScannerReturnValue.Size = new System.Drawing.Size(119, 20);
            this.textCustomScannerReturnValue.TabIndex = 35;
            // 
            // labelScannerExecutable
            // 
            this.labelScannerExecutable.AutoSize = true;
            this.labelScannerExecutable.Location = new System.Drawing.Point(34, 43);
            this.labelScannerExecutable.Name = "labelScannerExecutable";
            this.labelScannerExecutable.Size = new System.Drawing.Size(102, 13);
            this.labelScannerExecutable.TabIndex = 34;
            this.labelScannerExecutable.Text = "Scanner executable";
            // 
            // textCustomScannerExecutable
            // 
            this.textCustomScannerExecutable.Location = new System.Drawing.Point(37, 59);
            this.textCustomScannerExecutable.Name = "textCustomScannerExecutable";
            this.textCustomScannerExecutable.Number = 0;
            this.textCustomScannerExecutable.Number64 = ((long)(0));
            this.textCustomScannerExecutable.Numeric = false;
            this.textCustomScannerExecutable.Size = new System.Drawing.Size(247, 20);
            this.textCustomScannerExecutable.TabIndex = 33;
            // 
            // checkUseCustomScanner
            // 
            this.checkUseCustomScanner.AutoSize = true;
            this.checkUseCustomScanner.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkUseCustomScanner.Location = new System.Drawing.Point(18, 18);
            this.checkUseCustomScanner.Name = "checkUseCustomScanner";
            this.checkUseCustomScanner.Size = new System.Drawing.Size(132, 18);
            this.checkUseCustomScanner.TabIndex = 32;
            this.checkUseCustomScanner.Text = "Use external scanner";
            this.checkUseCustomScanner.UseVisualStyleBackColor = true;
            this.checkUseCustomScanner.CheckedChanged += new System.EventHandler(this.checkUseCustomScanner_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkBlockAttachmentsEnabled);
            this.tabPage4.Controls.Add(this.buttonEditBlockedAttachment);
            this.tabPage4.Controls.Add(this.buttonDeleteBlockedAttachment);
            this.tabPage4.Controls.Add(this.buttonAddBlockedAttachment);
            this.tabPage4.Controls.Add(this.listBlockedAttachments);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(723, 450);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Block attachments";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // checkBlockAttachmentsEnabled
            // 
            this.checkBlockAttachmentsEnabled.AutoSize = true;
            this.checkBlockAttachmentsEnabled.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBlockAttachmentsEnabled.Location = new System.Drawing.Point(8, 8);
            this.checkBlockAttachmentsEnabled.Name = "checkBlockAttachmentsEnabled";
            this.checkBlockAttachmentsEnabled.Size = new System.Drawing.Size(260, 18);
            this.checkBlockAttachmentsEnabled.TabIndex = 51;
            this.checkBlockAttachmentsEnabled.Text = "Block attachments with the following extensions:";
            this.checkBlockAttachmentsEnabled.UseVisualStyleBackColor = true;
            // 
            // buttonEditBlockedAttachment
            // 
            this.buttonEditBlockedAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditBlockedAttachment.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEditBlockedAttachment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonEditBlockedAttachment.Location = new System.Drawing.Point(616, 64);
            this.buttonEditBlockedAttachment.Name = "buttonEditBlockedAttachment";
            this.buttonEditBlockedAttachment.Size = new System.Drawing.Size(100, 25);
            this.buttonEditBlockedAttachment.TabIndex = 50;
            this.buttonEditBlockedAttachment.Text = "&Edit...";
            this.buttonEditBlockedAttachment.UseVisualStyleBackColor = true;
            this.buttonEditBlockedAttachment.Click += new System.EventHandler(this.buttonEditBlockedAttachment_Click);
            // 
            // buttonDeleteBlockedAttachment
            // 
            this.buttonDeleteBlockedAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteBlockedAttachment.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonDeleteBlockedAttachment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDeleteBlockedAttachment.Location = new System.Drawing.Point(616, 96);
            this.buttonDeleteBlockedAttachment.Name = "buttonDeleteBlockedAttachment";
            this.buttonDeleteBlockedAttachment.Size = new System.Drawing.Size(100, 25);
            this.buttonDeleteBlockedAttachment.TabIndex = 49;
            this.buttonDeleteBlockedAttachment.Text = "Remove";
            this.buttonDeleteBlockedAttachment.UseVisualStyleBackColor = true;
            this.buttonDeleteBlockedAttachment.Click += new System.EventHandler(this.buttonDeleteBlockedAttachment_Click);
            // 
            // buttonAddBlockedAttachment
            // 
            this.buttonAddBlockedAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddBlockedAttachment.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAddBlockedAttachment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddBlockedAttachment.Location = new System.Drawing.Point(616, 32);
            this.buttonAddBlockedAttachment.Name = "buttonAddBlockedAttachment";
            this.buttonAddBlockedAttachment.Size = new System.Drawing.Size(100, 25);
            this.buttonAddBlockedAttachment.TabIndex = 48;
            this.buttonAddBlockedAttachment.Text = "&Add...";
            this.buttonAddBlockedAttachment.UseVisualStyleBackColor = true;
            this.buttonAddBlockedAttachment.Click += new System.EventHandler(this.buttonAddBlockedAttachment_Click);
            // 
            // listBlockedAttachments
            // 
            this.listBlockedAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBlockedAttachments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listBlockedAttachments.FullRowSelect = true;
            this.listBlockedAttachments.HideSelection = false;
            this.listBlockedAttachments.Location = new System.Drawing.Point(24, 32);
            this.listBlockedAttachments.Name = "listBlockedAttachments";
            this.listBlockedAttachments.Size = new System.Drawing.Size(584, 408);
            this.listBlockedAttachments.TabIndex = 47;
            this.listBlockedAttachments.UseCompatibleStateImageBehavior = false;
            this.listBlockedAttachments.View = System.Windows.Forms.View.Details;
            this.listBlockedAttachments.SelectedIndexChanged += new System.EventHandler(this.listBlockedAttachments_SelectedIndexChanged);
            this.listBlockedAttachments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBlockedAttachments_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 250;
            // 
            // ucAntiVirus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl);
            this.Name = "ucAntiVirus";
            this.Size = new System.Drawing.Size(731, 476);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabClamAV.ResumeLayout(false);
            this.tabClamAV.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

       private System.Windows.Forms.TabControl tabControl;
       private System.Windows.Forms.TabPage tabPage1;
       private AltimailServer.Shared.ucText textVirusScanMaxSize;
       private System.Windows.Forms.Label labelMaxSizeToScan;
       private AltimailServer.Administrator.Controls.ucRadioButton radioDeleteAttachments;
       private AltimailServer.Administrator.Controls.ucCheckbox checkNotifyReceiver;
       private AltimailServer.Administrator.Controls.ucCheckbox checkNotifySender;
       private AltimailServer.Administrator.Controls.ucRadioButton radioDeleteEmail;
       private System.Windows.Forms.Label labelWhenAVirusIsFound;
       private System.Windows.Forms.TabPage tabPage2;
       private System.Windows.Forms.TabPage tabPage3;
       private System.Windows.Forms.TabPage tabPage4;
       private AltimailServer.Administrator.Controls.ucCheckbox checkUseClamWin;
       private System.Windows.Forms.Label label1;
       private AltimailServer.Shared.ucText textClamScanDatabase;
       private System.Windows.Forms.Label labelClamScanExecutable;
       private AltimailServer.Shared.ucText textClamScanExecutable;
       private System.Windows.Forms.Button buttonAutoDetect;
       private System.Windows.Forms.Label labelReturnValue;
       private AltimailServer.Shared.ucText textCustomScannerReturnValue;
       private System.Windows.Forms.Label labelScannerExecutable;
       private AltimailServer.Shared.ucText textCustomScannerExecutable;
       private AltimailServer.Administrator.Controls.ucCheckbox checkUseCustomScanner;
       private System.Windows.Forms.Button buttonEditBlockedAttachment;
       private System.Windows.Forms.Button buttonDeleteBlockedAttachment;
       private System.Windows.Forms.Button buttonAddBlockedAttachment;
       private ucListView listBlockedAttachments;
       private System.Windows.Forms.ColumnHeader columnHeader1;
       private System.Windows.Forms.ColumnHeader columnHeader2;
       private AltimailServer.Administrator.Controls.ucCheckbox checkBlockAttachmentsEnabled;
       private System.Windows.Forms.TabPage tabClamAV;
       private AltimailServer.Administrator.Controls.ucCheckbox checkClamAVEnabled;
       private System.Windows.Forms.Button buttonClamAVTest;
       private System.Windows.Forms.Label labelTCPIPPort;
       private System.Windows.Forms.Label labelHostname;
       private AltimailServer.Shared.ucText textClamAVPort;
       private AltimailServer.Shared.ucText textClamAVHostName;
       private System.Windows.Forms.Button buttonClamWinTest;
       private System.Windows.Forms.Button buttonCustomScannerTest;

     }
}
