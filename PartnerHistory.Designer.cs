namespace DemExam
{
    partial class PartnerHistory
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
            this.namePartnertxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.historybtn = new System.Windows.Forms.Button();
            this.historyPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // namePartnertxt
            // 
            this.namePartnertxt.Location = new System.Drawing.Point(29, 43);
            this.namePartnertxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.namePartnertxt.Name = "namePartnertxt";
            this.namePartnertxt.Size = new System.Drawing.Size(178, 25);
            this.namePartnertxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование партнёра";
            // 
            // historybtn
            // 
            this.historybtn.Location = new System.Drawing.Point(241, 17);
            this.historybtn.Name = "historybtn";
            this.historybtn.Size = new System.Drawing.Size(128, 51);
            this.historybtn.TabIndex = 2;
            this.historybtn.Text = "Показать историю";
            this.historybtn.UseVisualStyleBackColor = true;
            this.historybtn.Click += new System.EventHandler(this.historybtn_Click);
            // 
            // historyPanel
            // 
            this.historyPanel.AutoScroll = true;
            this.historyPanel.Location = new System.Drawing.Point(12, 87);
            this.historyPanel.Name = "historyPanel";
            this.historyPanel.Size = new System.Drawing.Size(909, 489);
            this.historyPanel.TabIndex = 3;
            // 
            // PartnerHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.historyPanel);
            this.Controls.Add(this.historybtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namePartnertxt);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PartnerHistory";
            this.Text = "История партнёра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox namePartnertxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button historybtn;
        private System.Windows.Forms.Panel historyPanel;
    }
}