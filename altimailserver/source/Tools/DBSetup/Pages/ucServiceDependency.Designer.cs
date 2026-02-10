namespace DBSetup.Pages
{
   partial class ucServiceDependency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucServiceDependency));
            this.labelDependency = new System.Windows.Forms.Label();
            this.comboServices = new System.Windows.Forms.ComboBox();
            this.labelService = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDependency
            // 
            this.labelDependency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDependency.Location = new System.Drawing.Point(8, 8);
            this.labelDependency.Name = "labelDependency";
            this.labelDependency.Size = new System.Drawing.Size(433, 96);
            this.labelDependency.TabIndex = 0;
            this.labelDependency.Text = resources.GetString("labelDependency.Text");
            // 
            // comboServices
            // 
            this.comboServices.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboServices.FormattingEnabled = true;
            this.comboServices.Location = new System.Drawing.Point(40, 147);
            this.comboServices.Name = "comboServices";
            this.comboServices.Size = new System.Drawing.Size(368, 21);
            this.comboServices.Sorted = true;
            this.comboServices.TabIndex = 1;
            // 
            // labelService
            // 
            this.labelService.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelService.AutoSize = true;
            this.labelService.Location = new System.Drawing.Point(40, 131);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(132, 13);
            this.labelService.TabIndex = 2;
            this.labelService.Text = "Database Engine Service";
            // 
            // ucServiceDependency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.labelService);
            this.Controls.Add(this.comboServices);
            this.Controls.Add(this.labelDependency);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucServiceDependency";
            this.Size = new System.Drawing.Size(451, 224);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelDependency;
      private System.Windows.Forms.ComboBox comboServices;
      private System.Windows.Forms.Label labelService;
   }
}
