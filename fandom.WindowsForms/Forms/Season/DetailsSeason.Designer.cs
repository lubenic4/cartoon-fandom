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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // sOrdinalNumber
            // 
            this.sOrdinalNumber.AutoSize = true;
            this.sOrdinalNumber.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold);
            this.sOrdinalNumber.Location = new System.Drawing.Point(12, 9);
            this.sOrdinalNumber.Name = "sOrdinalNumber";
            this.sOrdinalNumber.Size = new System.Drawing.Size(194, 34);
            this.sOrdinalNumber.TabIndex = 0;
            this.sOrdinalNumber.Text = "SEASON 11";
            // 
            // sNoOfEpisodes
            // 
            this.sNoOfEpisodes.AutoSize = true;
            this.sNoOfEpisodes.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold);
            this.sNoOfEpisodes.Location = new System.Drawing.Point(213, 17);
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
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 146);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(700, 288);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Air date";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Season episode number";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Overall episode number";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 130;
            // 
            // DetailsSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.summaryLabel);
            this.Controls.Add(this.sSummary);
            this.Controls.Add(this.sPremiereDate);
            this.Controls.Add(this.sNoOfEpisodes);
            this.Controls.Add(this.sOrdinalNumber);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}