namespace DemExam
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.partnerPanel = new System.Windows.Forms.Panel();
            this.addPartner = new System.Windows.Forms.Button();
            this.historyPartnerbtn = new System.Windows.Forms.Button();
            this.downloadDbbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // partnerPanel
            // 
            this.partnerPanel.AutoScroll = true;
            this.partnerPanel.Location = new System.Drawing.Point(15, 17);
            this.partnerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partnerPanel.Name = "partnerPanel";
            this.partnerPanel.Size = new System.Drawing.Size(904, 501);
            this.partnerPanel.TabIndex = 0;
            // 
            // addPartner
            // 
            this.addPartner.Location = new System.Drawing.Point(728, 527);
            this.addPartner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addPartner.Name = "addPartner";
            this.addPartner.Size = new System.Drawing.Size(191, 46);
            this.addPartner.TabIndex = 1;
            this.addPartner.Text = "Добавить партнёра";
            this.addPartner.UseVisualStyleBackColor = true;
            this.addPartner.Click += new System.EventHandler(this.addPartner_Click);
            // 
            // historyPartnerbtn
            // 
            this.historyPartnerbtn.Location = new System.Drawing.Point(529, 527);
            this.historyPartnerbtn.Margin = new System.Windows.Forms.Padding(4);
            this.historyPartnerbtn.Name = "historyPartnerbtn";
            this.historyPartnerbtn.Size = new System.Drawing.Size(191, 46);
            this.historyPartnerbtn.TabIndex = 2;
            this.historyPartnerbtn.Text = "История партнёра";
            this.historyPartnerbtn.UseVisualStyleBackColor = true;
            this.historyPartnerbtn.Click += new System.EventHandler(this.historyPartnerbtn_Click);
            // 
            // downloadDbbtn
            // 
            this.downloadDbbtn.Location = new System.Drawing.Point(330, 526);
            this.downloadDbbtn.Margin = new System.Windows.Forms.Padding(4);
            this.downloadDbbtn.Name = "downloadDbbtn";
            this.downloadDbbtn.Size = new System.Drawing.Size(191, 46);
            this.downloadDbbtn.TabIndex = 3;
            this.downloadDbbtn.Text = "Загрузить данные в бд";
            this.downloadDbbtn.UseVisualStyleBackColor = true;
            this.downloadDbbtn.Click += new System.EventHandler(this.downloadDbbtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.downloadDbbtn);
            this.Controls.Add(this.historyPartnerbtn);
            this.Controls.Add(this.addPartner);
            this.Controls.Add(this.partnerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.Text = "Главное окно";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel partnerPanel;
        private System.Windows.Forms.Button addPartner;
        private System.Windows.Forms.Button historyPartnerbtn;
        private System.Windows.Forms.Button downloadDbbtn;
    }
}