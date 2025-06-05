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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radioMSSQL
            // 
            this.radioMSSQL.AutoSize = true;
            this.radioMSSQL.Checked = true;
            this.radioMSSQL.Location = new System.Drawing.Point(8, 8);
            this.radioMSSQL.Name = "radioMSSQL";
            this.radioMSSQL.Size = new System.Drawing.Size(126, 17);
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
            this.radioMySQL.Size = new System.Drawing.Size(106, 17);
            this.radioMySQL.TabIndex = 1;
            this.radioMySQL.TabStop = true;
            this.radioMySQL.Text = "MySQL/MariaDB";
            this.radioMySQL.UseVisualStyleBackColor = true;
            // 
            // radioPGSQL
            // 
            this.radioPGSQL.AutoSize = true;
            this.radioPGSQL.Location = new System.Drawing.Point(8, 147);
            this.radioPGSQL.Name = "radioPGSQL";
            this.radioPGSQL.Size = new System.Drawing.Size(82, 17);
            this.radioPGSQL.TabIndex = 2;
            this.radioPGSQL.TabStop = true;
            this.radioPGSQL.Text = "PostgreSQL";
            this.radioPGSQL.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(25, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "The required connector for MySQL/MariaDB is not included in AltimailServer.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(25, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "You will need to copy the required `libmysql.dll` file to the installed directory" +
    ", inside the `BIN` folder.";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(25, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(415, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Please ensure you are using the 64-bit libmysql.dll file.";
            // 
            // ucSelectDatabaseType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioPGSQL);
            this.Controls.Add(this.radioMySQL);
            this.Controls.Add(this.radioMSSQL);
            this.Name = "ucSelectDatabaseType";
            this.Size = new System.Drawing.Size(457, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RadioButton radioMSSQL;
      private System.Windows.Forms.RadioButton radioMySQL;
      private System.Windows.Forms.RadioButton radioPGSQL;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
   }
}
