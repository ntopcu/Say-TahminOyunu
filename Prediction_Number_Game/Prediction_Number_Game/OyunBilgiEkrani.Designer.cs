namespace Prediction_Number_Game
{
    partial class bilgiEkran_frm
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
            this.bilgi_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bilgi_lbl
            // 
            this.bilgi_lbl.AutoSize = true;
            this.bilgi_lbl.Location = new System.Drawing.Point(13, 13);
            this.bilgi_lbl.Name = "bilgi_lbl";
            this.bilgi_lbl.Size = new System.Drawing.Size(0, 13);
            this.bilgi_lbl.TabIndex = 0;
            // 
            // bilgiEkran_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 558);
            this.Controls.Add(this.bilgi_lbl);
            this.Name = "bilgiEkran_frm";
            this.Text = "Oyun Bilgi Ekranı";
            this.Load += new System.EventHandler(this.bilgiEkran_frm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bilgi_lbl;
    }
}