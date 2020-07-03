namespace fandom.WindowsForms.Forms
{
    partial class HomeMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeMDI));
            this.logo = new System.Windows.Forms.PictureBox();
            this.characterLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.episodeLabel = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.dashboardLabel = new System.Windows.Forms.Label();
            this.seasonLabel = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(13, 16);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(246, 51);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // characterLabel
            // 
            this.characterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.characterLabel.AutoSize = true;
            this.characterLabel.Font = new System.Drawing.Font("Calibri", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterLabel.Location = new System.Drawing.Point(77, 380);
            this.characterLabel.Name = "characterLabel";
            this.characterLabel.Size = new System.Drawing.Size(119, 29);
            this.characterLabel.TabIndex = 3;
            this.characterLabel.Text = "Characters";
            this.characterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.characterLabel.Click += new System.EventHandler(this.characterLabel_Click);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Calibri", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(101, 310);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(67, 29);
            this.userLabel.TabIndex = 4;
            this.userLabel.Text = "Users";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.userLabel.Click += new System.EventHandler(this.userLabel_Click);
            // 
            // episodeLabel
            // 
            this.episodeLabel.AutoSize = true;
            this.episodeLabel.Font = new System.Drawing.Font("Calibri", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.episodeLabel.Location = new System.Drawing.Point(85, 240);
            this.episodeLabel.Name = "episodeLabel";
            this.episodeLabel.Size = new System.Drawing.Size(100, 29);
            this.episodeLabel.TabIndex = 1;
            this.episodeLabel.Text = "Episodes";
            this.episodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.episodeLabel.Click += new System.EventHandler(this.episodeLabel_Click);
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.Controls.Add(this.dashboardLabel);
            this.sidebarPanel.Controls.Add(this.seasonLabel);
            this.sidebarPanel.Controls.Add(this.logo);
            this.sidebarPanel.Controls.Add(this.userLabel);
            this.sidebarPanel.Controls.Add(this.episodeLabel);
            this.sidebarPanel.Controls.Add(this.characterLabel);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(274, 753);
            this.sidebarPanel.TabIndex = 10;
            // 
            // dashboardLabel
            // 
            this.dashboardLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dashboardLabel.AutoSize = true;
            this.dashboardLabel.Font = new System.Drawing.Font("Calibri", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardLabel.Location = new System.Drawing.Point(71, 100);
            this.dashboardLabel.Name = "dashboardLabel";
            this.dashboardLabel.Size = new System.Drawing.Size(123, 29);
            this.dashboardLabel.TabIndex = 6;
            this.dashboardLabel.Text = "Dashboard";
            this.dashboardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dashboardLabel.Click += new System.EventHandler(this.dashboardLabel_Click);
            // 
            // seasonLabel
            // 
            this.seasonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.seasonLabel.AutoSize = true;
            this.seasonLabel.Font = new System.Drawing.Font("Calibri", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seasonLabel.Location = new System.Drawing.Point(86, 170);
            this.seasonLabel.Name = "seasonLabel";
            this.seasonLabel.Size = new System.Drawing.Size(93, 29);
            this.seasonLabel.TabIndex = 5;
            this.seasonLabel.Text = "Seasons";
            this.seasonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.seasonLabel.Click += new System.EventHandler(this.seasonLabel_Click);
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(274, 0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(1116, 753);
            this.formPanel.TabIndex = 11;
            // 
            // HomeMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 753);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.sidebarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomeMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeMDI";
            this.Load += new System.EventHandler(this.HomeMDI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label characterLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label episodeLabel;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label seasonLabel;
        private System.Windows.Forms.Label dashboardLabel;
        private System.Windows.Forms.Panel formPanel;
    }
}



