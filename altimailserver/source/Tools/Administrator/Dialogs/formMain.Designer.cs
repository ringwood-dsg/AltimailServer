namespace AltimailServer.Administrator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeNodes = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.labelTopCaption = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSelectLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSynchronisationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelpIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slConnection = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelTopBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(2, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeNodes);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.buttonHelp);
            this.splitContainer.Panel2.Controls.Add(this.buttonSave);
            this.splitContainer.Panel2.Controls.Add(this.panelTopBar);
            this.splitContainer.Panel2.Controls.Add(this.panelMain);
            this.splitContainer.Size = new System.Drawing.Size(786, 524);
            this.splitContainer.SplitterDistance = 282;
            this.splitContainer.TabIndex = 9;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // treeNodes
            // 
            this.treeNodes.BackColor = System.Drawing.SystemColors.Window;
            this.treeNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.treeNodes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.treeNodes.ImageIndex = 0;
            this.treeNodes.ImageList = this.imageList;
            this.treeNodes.LineColor = System.Drawing.Color.Silver;
            this.treeNodes.Location = new System.Drawing.Point(0, 0);
            this.treeNodes.Name = "treeNodes";
            this.treeNodes.SelectedImageIndex = 0;
            this.treeNodes.Size = new System.Drawing.Size(282, 524);
            this.treeNodes.TabIndex = 0;
            this.treeNodes.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeNodes_BeforeExpand);
            this.treeNodes.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeNodes_AfterExpand);
            this.treeNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeNodes_AfterSelect);
            this.treeNodes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeNodes_MouseUp);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "star.ico");
            this.imageList.Images.SetKeyName(1, "world.ico");
            this.imageList.Images.SetKeyName(2, "server.ico");
            this.imageList.Images.SetKeyName(3, "folder.ico");
            this.imageList.Images.SetKeyName(4, "user.ico");
            this.imageList.Images.SetKeyName(5, "arrow_switch.ico");
            this.imageList.Images.SetKeyName(6, "arrow_out.ico");
            this.imageList.Images.SetKeyName(7, "arrow_out.ico");
            this.imageList.Images.SetKeyName(8, "page_white_go.ico");
            this.imageList.Images.SetKeyName(9, "server_connect.ico");
            this.imageList.Images.SetKeyName(10, "connect.ico");
            this.imageList.Images.SetKeyName(11, "routing_intersection_right.ico");
            this.imageList.Images.SetKeyName(12, "connect.ico");
            this.imageList.Images.SetKeyName(13, "spam_filter.ico");
            this.imageList.Images.SetKeyName(14, "email_delete.ico");
            this.imageList.Images.SetKeyName(15, "time_delete.ico");
            this.imageList.Images.SetKeyName(16, "email_link.ico");
            this.imageList.Images.SetKeyName(17, "bug_delete.ico");
            this.imageList.Images.SetKeyName(18, "directory_listing.ico");
            this.imageList.Images.SetKeyName(19, "understanding.ico");
            this.imageList.Images.SetKeyName(20, "stop.ico");
            this.imageList.Images.SetKeyName(21, "rosette.ico");
            this.imageList.Images.SetKeyName(22, "construction.ico");
            this.imageList.Images.SetKeyName(23, "arrow_in.ico");
            this.imageList.Images.SetKeyName(24, "arrow_branch.ico");
            this.imageList.Images.SetKeyName(25, "speedometer.ico");
            this.imageList.Images.SetKeyName(26, "text_align_justity.ico");
            this.imageList.Images.SetKeyName(27, "source_code.ico");
            this.imageList.Images.SetKeyName(28, "multitool.ico");
            this.imageList.Images.SetKeyName(29, "disk.ico");
            this.imageList.Images.SetKeyName(30, "compass.ico");
            this.imageList.Images.SetKeyName(31, "arrow_out.ico");
            this.imageList.Images.SetKeyName(32, "heart.ico");
            this.imageList.Images.SetKeyName(33, "information.ico");
            this.imageList.Images.SetKeyName(34, "setting_tools.ico");
            this.imageList.Images.SetKeyName(35, "chart_organisation.ico");
            this.imageList.Images.SetKeyName(36, "tree-home.ico");
            this.imageList.Images.SetKeyName(37, "tree-server-settings.ico");
            this.imageList.Images.SetKeyName(38, "tree-domain.ico");
            this.imageList.Images.SetKeyName(39, "tree-server-protocols.ico");
            this.imageList.Images.SetKeyName(40, "tree-protocol.ico");
            this.imageList.Images.SetKeyName(41, "tree-anti-virus.ico");
            this.imageList.Images.SetKeyName(42, "tree-logging.ico");
            this.imageList.Images.SetKeyName(43, "tree-ports.ico");
            this.imageList.Images.SetKeyName(44, "tree-performance.ico");
            this.imageList.Images.SetKeyName(45, "tree-rules.ico");
            this.imageList.Images.SetKeyName(46, "tree-ssl-tls.ico");
            this.imageList.Images.SetKeyName(47, "tree-ssl-tls-settings.ico");
            this.imageList.Images.SetKeyName(48, "tree-settings-advanced.ico");
            this.imageList.Images.SetKeyName(49, "tree-scripts.ico");
            this.imageList.Images.SetKeyName(50, "tree-server-sendout.ico");
            this.imageList.Images.SetKeyName(51, "tree-smtp-forwarding.ico");
            this.imageList.Images.SetKeyName(52, "tree-ip-ranges.ico");
            this.imageList.Images.SetKeyName(53, "tree-domain-accounts.ico");
            this.imageList.Images.SetKeyName(54, "tree-incoming-relays.ico");
            this.imageList.Images.SetKeyName(55, "tree-incoming-relay.ico");
            this.imageList.Images.SetKeyName(56, "tree-server-message.ico");
            this.imageList.Images.SetKeyName(57, "tree-server-messages.ico");
            this.imageList.Images.SetKeyName(58, "tree-auto-ban.ico");
            this.imageList.Images.SetKeyName(59, "tree-tools.ico");
            this.imageList.Images.SetKeyName(60, "tree-server-status.ico");
            this.imageList.Images.SetKeyName(61, "tree-backup.ico");
            this.imageList.Images.SetKeyName(62, "tree-ssl-tls-certificate.ico");
            this.imageList.Images.SetKeyName(63, "tree-mx-query.ico");
            this.imageList.Images.SetKeyName(64, "tree-domain-account.ico");
            this.imageList.Images.SetKeyName(65, "tree-anti-spam.ico");
            this.imageList.Images.SetKeyName(66, "tree-smtp-routes.ico");
            this.imageList.Images.SetKeyName(67, "tree-folder.ico");
            this.imageList.Images.SetKeyName(68, "tree-diagnostics.ico");
            this.imageList.Images.SetKeyName(69, "tree-imap-group.ico");
            this.imageList.Images.SetKeyName(70, "tree-smtp-route.ico");
            this.imageList.Images.SetKeyName(71, "tree-alias.ico");
            this.imageList.Images.SetKeyName(72, "tree-aliases.ico");
            this.imageList.Images.SetKeyName(73, "tree-distribution-lists.ico");
            this.imageList.Images.SetKeyName(74, "tree-domains.ico");
            this.imageList.Images.SetKeyName(75, "tree-lookup-antispam.ico");
            this.imageList.Images.SetKeyName(76, "tree-port.ico");
            this.imageList.Images.SetKeyName(77, "tree-blacklist.ico");
            this.imageList.Images.SetKeyName(78, "tree-greylist.ico");
            this.imageList.Images.SetKeyName(79, "tree-whitelist.ico");
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonHelp.Image = global::AltimailServer.Administrator.Properties.Resources.HelpApplication_16x;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHelp.Location = new System.Drawing.Point(5, 492);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(89, 25);
            this.buttonHelp.TabIndex = 5;
            this.buttonHelp.Text = "&Help";
            this.buttonHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSave.Location = new System.Drawing.Point(403, 492);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(89, 25);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopBar.Controls.Add(this.labelTopCaption);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(500, 27);
            this.panelTopBar.TabIndex = 3;
            // 
            // labelTopCaption
            // 
            this.labelTopCaption.AutoSize = true;
            this.labelTopCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopCaption.ForeColor = System.Drawing.Color.Black;
            this.labelTopCaption.Location = new System.Drawing.Point(3, 5);
            this.labelTopCaption.Name = "labelTopCaption";
            this.labelTopCaption.Size = new System.Drawing.Size(45, 16);
            this.labelTopCaption.TabIndex = 0;
            this.labelTopCaption.Text = "label1";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Location = new System.Drawing.Point(5, 33);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(494, 453);
            this.panelMain.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.tOOLSToolStripMenuItem,
            this.menuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(792, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConnect,
            this.toolStripMenuItem2,
            this.preferencesToolStripMenuItem,
            this.menuItemSelectLanguage,
            this.toolStripSeparator1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(57, 20);
            this.menuItemFile.Text = "&System";
            // 
            // menuItemConnect
            // 
            this.menuItemConnect.Name = "menuItemConnect";
            this.menuItemConnect.Size = new System.Drawing.Size(180, 22);
            this.menuItemConnect.Text = "C&hange Connection";
            this.menuItemConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Enabled = false;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.preferencesToolStripMenuItem.Text = "&Preferences";
            // 
            // menuItemSelectLanguage
            // 
            this.menuItemSelectLanguage.Enabled = false;
            this.menuItemSelectLanguage.Name = "menuItemSelectLanguage";
            this.menuItemSelectLanguage.Size = new System.Drawing.Size(180, 22);
            this.menuItemSelectLanguage.Text = "Select language...";
            this.menuItemSelectLanguage.Click += new System.EventHandler(this.menuItemSelectLanguage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemExit.Size = new System.Drawing.Size(180, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // tOOLSToolStripMenuItem
            // 
            this.tOOLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataSynchronisationToolStripMenuItem});
            this.tOOLSToolStripMenuItem.Enabled = false;
            this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
            this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.tOOLSToolStripMenuItem.Text = "&Tools";
            // 
            // dataSynchronisationToolStripMenuItem
            // 
            this.dataSynchronisationToolStripMenuItem.Name = "dataSynchronisationToolStripMenuItem";
            this.dataSynchronisationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.dataSynchronisationToolStripMenuItem.Text = "&Data Synchronisation";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelpIndex,
            this.toolStripMenuItem1,
            this.menuItemHelpAbout});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemHelpIndex
            // 
            this.menuItemHelpIndex.Name = "menuItemHelpIndex";
            this.menuItemHelpIndex.Size = new System.Drawing.Size(186, 22);
            this.menuItemHelpIndex.Text = "H&elp";
            this.menuItemHelpIndex.Click += new System.EventHandler(this.menuItemHelpIndex_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // menuItemHelpAbout
            // 
            this.menuItemHelpAbout.Name = "menuItemHelpAbout";
            this.menuItemHelpAbout.Size = new System.Drawing.Size(186, 22);
            this.menuItemHelpAbout.Text = "&About Altimail Server";
            this.menuItemHelpAbout.Click += new System.EventHandler(this.menuItemHelpAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slConnection
            // 
            this.slConnection.Image = global::AltimailServer.Administrator.Properties.Resources.Disconnected;
            this.slConnection.Name = "slConnection";
            this.slConnection.Size = new System.Drawing.Size(94, 17);
            this.slConnection.Text = "Connecting...";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Altimail Server Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formMain_KeyDown);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeNodes;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label labelTopCaption;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button buttonSave;
       private System.Windows.Forms.ImageList imageList;
       private System.Windows.Forms.Button buttonHelp;
       private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
       private System.Windows.Forms.ToolStripMenuItem menuItemHelpIndex;
       private System.Windows.Forms.ToolStripMenuItem menuItemHelpAbout;
       private System.Windows.Forms.ToolStripMenuItem menuItemSelectLanguage;
      private System.Windows.Forms.ToolStripMenuItem tOOLSToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem dataSynchronisationToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel slConnection;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
   }
}

