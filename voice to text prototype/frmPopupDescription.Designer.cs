namespace voice_to_text_prototype
{
    partial class frmPopupDescription
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
            this.lblEventDescription = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.BtnCreateDescription = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEventDescription
            // 
            this.lblEventDescription.AutoSize = true;
            this.lblEventDescription.Location = new System.Drawing.Point(15, 17);
            this.lblEventDescription.Name = "lblEventDescription";
            this.lblEventDescription.Size = new System.Drawing.Size(35, 13);
            this.lblEventDescription.TabIndex = 0;
            this.lblEventDescription.Text = "label1";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 51);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "label2";
            // 
            // BtnCreateDescription
            // 
            this.BtnCreateDescription.Location = new System.Drawing.Point(254, 133);
            this.BtnCreateDescription.Name = "BtnCreateDescription";
            this.BtnCreateDescription.Size = new System.Drawing.Size(106, 39);
            this.BtnCreateDescription.TabIndex = 2;
            this.BtnCreateDescription.Text = "View Events";
            this.BtnCreateDescription.UseVisualStyleBackColor = true;
            this.BtnCreateDescription.Click += new System.EventHandler(this.BtnCreateDescription_Click);
            // 
            // frmPopupDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 184);
            this.Controls.Add(this.BtnCreateDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblEventDescription);
            this.Name = "frmPopupDescription";
            this.Text = "Popup";
            this.Load += new System.EventHandler(this.frmPopupDescription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEventDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button BtnCreateDescription;
    }
}