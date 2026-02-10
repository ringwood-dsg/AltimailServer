using AltimailServer.Shared;

namespace DBSetup
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
            this.wizard = new AltimailServer.Shared.ucWizard();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard.Location = new System.Drawing.Point(0, 0);
            this.wizard.Margin = new System.Windows.Forms.Padding(60, 30, 60, 30);
            this.wizard.Name = "wizard";
            this.wizard.Size = new System.Drawing.Size(844, 519);
            this.wizard.TabIndex = 0;
            this.wizard.Cancel += new System.EventHandler(this.wizard_OnCancel);
            this.wizard.PageChanged += new AltimailServer.Shared.ucWizard.PageChangedEventHandler(this.wizard_PageChanged);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(844, 519);
            this.Controls.Add(this.wizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(48, 24, 48, 24);
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Altimail Server Database Setup Utility";
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.ResumeLayout(false);

      }

      #endregion

      private ucWizard wizard;
   }
}

