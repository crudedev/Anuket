namespace voice_to_text_prototype
{
    partial class FrmNewNote
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
            this.TxtNote = new System.Windows.Forms.TextBox();
            this.btnSaveNote = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtNote
            // 
            this.TxtNote.Location = new System.Drawing.Point(12, 26);
            this.TxtNote.Multiline = true;
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(439, 386);
            this.TxtNote.TabIndex = 0;
            // 
            // btnSaveNote
            // 
            this.btnSaveNote.Location = new System.Drawing.Point(294, 422);
            this.btnSaveNote.Name = "btnSaveNote";
            this.btnSaveNote.Size = new System.Drawing.Size(128, 42);
            this.btnSaveNote.TabIndex = 1;
            this.btnSaveNote.Text = "Save Note";
            this.btnSaveNote.UseVisualStyleBackColor = true;
            this.btnSaveNote.Click += new System.EventHandler(this.btnSaveNote_Click);
            // 
            // FrmNewNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 476);
            this.Controls.Add(this.btnSaveNote);
            this.Controls.Add(this.TxtNote);
            this.Name = "FrmNewNote";
            this.Text = "NewNote";
            this.Load += new System.EventHandler(this.FrmNewNote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNote;
        private System.Windows.Forms.Button btnSaveNote;
    }
}