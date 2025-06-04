namespace DBSetup.Pages
{
   partial class ucPerformTask
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
            this.labelEnoughInformation = new System.Windows.Forms.Label();
            this.textLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelEnoughInformation
            // 
            this.labelEnoughInformation.Location = new System.Drawing.Point(8, 8);
            this.labelEnoughInformation.Name = "labelEnoughInformation";
            this.labelEnoughInformation.Size = new System.Drawing.Size(536, 20);
            this.labelEnoughInformation.TabIndex = 0;
            this.labelEnoughInformation.Text = "The wizard has enough information to finish the operation. Click next to perform " +
    "the selected tasks.";
            // 
            // textLog
            // 
            this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLog.Location = new System.Drawing.Point(8, 29);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textLog.Size = new System.Drawing.Size(535, 241);
            this.textLog.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(11, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(532, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seeing SQL Syntax errors appearing?\r\nPlease cancel this wizard, uninstall hMailSe" +
    "rver 5.8.0 and install 5.8.1 instead.";
            // 
            // ucPerformTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.labelEnoughInformation);
            this.Name = "ucPerformTask";
            this.Size = new System.Drawing.Size(553, 305);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelEnoughInformation;
      private System.Windows.Forms.TextBox textLog;
      private System.Windows.Forms.Label label1;
   }
}
