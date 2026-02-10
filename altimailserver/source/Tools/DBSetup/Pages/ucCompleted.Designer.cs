namespace DBSetup.Pages
{
   partial class ucCompleted
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
            this.labelOperationPerformed = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOperationPerformed
            // 
            this.labelOperationPerformed.AutoSize = true;
            this.labelOperationPerformed.Location = new System.Drawing.Point(62, 8);
            this.labelOperationPerformed.Name = "labelOperationPerformed";
            this.labelOperationPerformed.Size = new System.Drawing.Size(298, 13);
            this.labelOperationPerformed.TabIndex = 1;
            this.labelOperationPerformed.Text = "The wizard has completed. Press Close to exit the wizard.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ucCompleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelOperationPerformed);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucCompleted";
            this.Size = new System.Drawing.Size(499, 196);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelOperationPerformed;
      private System.Windows.Forms.PictureBox pictureBox1;
   }
}
