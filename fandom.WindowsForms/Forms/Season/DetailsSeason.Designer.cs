namespace fandom.WindowsForms.Forms.Season
{
    partial class DetailsSeason
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
            this.sName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sName
            // 
            this.sName.AutoSize = true;
            this.sName.Location = new System.Drawing.Point(89, 110);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(46, 17);
            this.sName.TabIndex = 0;
            this.sName.Text = "label1";
            // 
            // DetailsSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sName);
            this.Name = "DetailsSeason";
            this.Text = "DetailsSeason";
            this.Load += new System.EventHandler(this.DetailsSeason_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sName;
    }
}