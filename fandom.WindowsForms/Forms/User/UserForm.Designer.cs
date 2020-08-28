namespace fandom.WindowsForms.Forms
{
    partial class UserForm
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
            this.addEpisodeButton = new System.Windows.Forms.Button();
            this.episodesLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // addEpisodeButton
            // 
            this.addEpisodeButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.addEpisodeButton.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEpisodeButton.Location = new System.Drawing.Point(109, 13);
            this.addEpisodeButton.Margin = new System.Windows.Forms.Padding(2);
            this.addEpisodeButton.Name = "addEpisodeButton";
            this.addEpisodeButton.Size = new System.Drawing.Size(100, 22);
            this.addEpisodeButton.TabIndex = 5;
            this.addEpisodeButton.Text = "+ NEW USER";
            this.addEpisodeButton.UseVisualStyleBackColor = false;
            this.addEpisodeButton.Click += new System.EventHandler(this.addEpisodeButton_Click);
            // 
            // episodesLabel
            // 
            this.episodesLabel.AutoSize = true;
            this.episodesLabel.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.episodesLabel.Location = new System.Drawing.Point(11, 9);
            this.episodesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.episodesLabel.Name = "episodesLabel";
            this.episodesLabel.Size = new System.Drawing.Size(94, 26);
            this.episodesLabel.TabIndex = 4;
            this.episodesLabel.Text = "USERS";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 64);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(730, 536);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Email";
            this.columnHeader2.Width = 230;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Roles";
            this.columnHeader3.Width = 230;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(754, 612);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.addEpisodeButton);
            this.Controls.Add(this.episodesLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addEpisodeButton;
        private System.Windows.Forms.Label episodesLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}