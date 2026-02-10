namespace DBSetup.Pages
{
   partial class ucSelectDatabaseType
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
            this.radioMSSQL = new System.Windows.Forms.RadioButton();
            this.radioMySQL = new System.Windows.Forms.RadioButton();
            this.radioPGSQL = new System.Windows.Forms.RadioButton();
            this.radioMariaDB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioMSSQL
            // 
            this.radioMSSQL.AutoSize = true;
            this.radioMSSQL.Checked = true;
            this.radioMSSQL.Location = new System.Drawing.Point(8, 8);
            this.radioMSSQL.Name = "radioMSSQL";
            this.radioMSSQL.Size = new System.Drawing.Size(130, 17);
            this.radioMSSQL.TabIndex = 0;
            this.radioMSSQL.TabStop = true;
            this.radioMSSQL.Text = "Microsoft SQL Server";
            this.radioMSSQL.UseVisualStyleBackColor = true;
            // 
            // radioMySQL
            // 
            this.radioMySQL.AutoSize = true;
            this.radioMySQL.Location = new System.Drawing.Point(8, 40);
            this.radioMySQL.Name = "radioMySQL";
            this.radioMySQL.Size = new System.Drawing.Size(132, 17);
            this.radioMySQL.TabIndex = 1;
            this.radioMySQL.TabStop = true;
            this.radioMySQL.Text = "MySQL (5.7.9 or later)";
            this.radioMySQL.UseVisualStyleBackColor = true;
            // 
            // radioPGSQL
            // 
            this.radioPGSQL.AutoSize = true;
            this.radioPGSQL.Location = new System.Drawing.Point(8, 105);
            this.radioPGSQL.Name = "radioPGSQL";
            this.radioPGSQL.Size = new System.Drawing.Size(83, 17);
            this.radioPGSQL.TabIndex = 3;
            this.radioPGSQL.TabStop = true;
            this.radioPGSQL.Text = "PostgreSQL";
            this.radioPGSQL.UseVisualStyleBackColor = true;
            // 
            // radioMariaDB
            // 
            this.radioMariaDB.AutoSize = true;
            this.radioMariaDB.Location = new System.Drawing.Point(8, 72);
            this.radioMariaDB.Name = "radioMariaDB";
            this.radioMariaDB.Size = new System.Drawing.Size(154, 17);
            this.radioMariaDB.TabIndex = 2;
            this.radioMariaDB.TabStop = true;
            this.radioMariaDB.Text = "MariaDB (10.5.29 or later)";
            this.radioMariaDB.UseVisualStyleBackColor = true;
            // 
            // ucSelectDatabaseType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.radioPGSQL);
            this.Controls.Add(this.radioMySQL);
            this.Controls.Add(this.radioMariaDB);
            this.Controls.Add(this.radioMSSQL);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucSelectDatabaseType";
            this.Size = new System.Drawing.Size(457, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RadioButton radioMSSQL;
      private System.Windows.Forms.RadioButton radioMySQL;
      private System.Windows.Forms.RadioButton radioPGSQL;
      private System.Windows.Forms.RadioButton radioMariaDB;
   }
}
