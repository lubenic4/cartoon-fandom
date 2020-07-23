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
            this.sOrdinalNumber = new System.Windows.Forms.Label();
            this.sNoOfEpisodes = new System.Windows.Forms.Label();
            this.sPremiereDate = new System.Windows.Forms.Label();
            this.sSummary = new System.Windows.Forms.Label();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sOrdinalNumber
            // 
            this.sOrdinalNumber.AutoSize = true;
            this.sOrdinalNumber.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold);
            this.sOrdinalNumber.Location = new System.Drawing.Point(12, 9);
            this.sOrdinalNumber.Name = "sOrdinalNumber";
            this.sOrdinalNumber.Size = new System.Drawing.Size(174, 34);
            this.sOrdinalNumber.TabIndex = 0;
            this.sOrdinalNumber.Text = "SEASON 0";
            // 
            // sNoOfEpisodes
            // 
            this.sNoOfEpisodes.AutoSize = true;
            this.sNoOfEpisodes.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.sNoOfEpisodes.Location = new System.Drawing.Point(185, 19);
            this.sNoOfEpisodes.Name = "sNoOfEpisodes";
            this.sNoOfEpisodes.Size = new System.Drawing.Size(117, 17);
            this.sNoOfEpisodes.TabIndex = 1;
            this.sNoOfEpisodes.Text = "(01 episodes)";
            // 
            // sPremiereDate
            // 
            this.sPremiereDate.AutoSize = true;
            this.sPremiereDate.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sPremiereDate.Location = new System.Drawing.Point(15, 43);
            this.sPremiereDate.Name = "sPremiereDate";
            this.sPremiereDate.Size = new System.Drawing.Size(215, 17);
            this.sPremiereDate.TabIndex = 2;
            this.sPremiereDate.Text = "Premiere date 01-01-2000";
            // 
            // sSummary
            // 
            this.sSummary.AutoSize = true;
            this.sSummary.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sSummary.Location = new System.Drawing.Point(15, 107);
            this.sSummary.Name = "sSummary";
            this.sSummary.Size = new System.Drawing.Size(48, 17);
            this.sSummary.TabIndex = 3;
            this.sSummary.Text = "label1";
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.summaryLabel.Location = new System.Drawing.Point(15, 80);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(81, 17);
            this.summaryLabel.TabIndex = 4;
            this.summaryLabel.Text = "Summary";
            // 
            // DetailsSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.summaryLabel);
            this.Controls.Add(this.sSummary);
            this.Controls.Add(this.sPremiereDate);
            this.Controls.Add(this.sNoOfEpisodes);
            this.Controls.Add(this.sOrdinalNumber);
            this.Name = "DetailsSeason";
            this.Text = "DetailsSeason";
            this.Load += new System.EventHandler(this.DetailsSeason_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sOrdinalNumber;
        private System.Windows.Forms.Label sNoOfEpisodes;
        private System.Windows.Forms.Label sPremiereDate;
        private System.Windows.Forms.Label sSummary;
        private System.Windows.Forms.Label summaryLabel;
    }
}