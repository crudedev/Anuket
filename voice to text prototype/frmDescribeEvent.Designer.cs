namespace Anuket
{
    partial class frmDescribeEvent
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
            this.txtTransciption = new System.Windows.Forms.TextBox();
            this.btnSaveDescription = new System.Windows.Forms.Button();
            this.btnStartAudio = new System.Windows.Forms.Button();
            this.btnStopAudio = new System.Windows.Forms.Button();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.btnTranscribe = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTransciption
            // 
            this.txtTransciption.Enabled = false;
            this.txtTransciption.Location = new System.Drawing.Point(420, 94);
            this.txtTransciption.Multiline = true;
            this.txtTransciption.Name = "txtTransciption";
            this.txtTransciption.Size = new System.Drawing.Size(521, 79);
            this.txtTransciption.TabIndex = 0;
            // 
            // btnSaveDescription
            // 
            this.btnSaveDescription.Location = new System.Drawing.Point(947, 253);
            this.btnSaveDescription.Name = "btnSaveDescription";
            this.btnSaveDescription.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDescription.TabIndex = 1;
            this.btnSaveDescription.Text = "Save Text";
            this.btnSaveDescription.UseVisualStyleBackColor = true;
            this.btnSaveDescription.Click += new System.EventHandler(this.btnSaveDescription_Click);
            // 
            // btnStartAudio
            // 
            this.btnStartAudio.Location = new System.Drawing.Point(420, 51);
            this.btnStartAudio.Name = "btnStartAudio";
            this.btnStartAudio.Size = new System.Drawing.Size(75, 23);
            this.btnStartAudio.TabIndex = 2;
            this.btnStartAudio.Text = "Start Audio";
            this.btnStartAudio.UseVisualStyleBackColor = true;
            this.btnStartAudio.Click += new System.EventHandler(this.btnStartAudio_Click);
            // 
            // btnStopAudio
            // 
            this.btnStopAudio.Location = new System.Drawing.Point(519, 51);
            this.btnStopAudio.Name = "btnStopAudio";
            this.btnStopAudio.Size = new System.Drawing.Size(75, 23);
            this.btnStopAudio.TabIndex = 3;
            this.btnStopAudio.Text = "Stop Audio";
            this.btnStopAudio.UseVisualStyleBackColor = true;
            this.btnStopAudio.Click += new System.EventHandler(this.btnStopAudio_Click);
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(417, 12);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(65, 13);
            this.lblTaskName.TabIndex = 4;
            this.lblTaskName.Text = "Task Name:";
            // 
            // btnTranscribe
            // 
            this.btnTranscribe.Location = new System.Drawing.Point(700, 51);
            this.btnTranscribe.Name = "btnTranscribe";
            this.btnTranscribe.Size = new System.Drawing.Size(75, 23);
            this.btnTranscribe.TabIndex = 5;
            this.btnTranscribe.Text = "Transcribe";
            this.btnTranscribe.UseVisualStyleBackColor = true;
            this.btnTranscribe.Click += new System.EventHandler(this.btnTranscribe_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(420, 192);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(521, 84);
            this.txtNotes.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "textComment";
            // 
            // lstEvents
            // 
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.Location = new System.Drawing.Point(12, 12);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(386, 264);
            this.lstEvents.TabIndex = 8;
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Location = new System.Drawing.Point(947, 51);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(75, 23);
            this.btnAttachFile.TabIndex = 9;
            this.btnAttachFile.Text = "Attach File";
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "textTranscription";
            // 
            // frmDescribeEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnTranscribe);
            this.Controls.Add(this.lblTaskName);
            this.Controls.Add(this.btnStopAudio);
            this.Controls.Add(this.btnStartAudio);
            this.Controls.Add(this.btnSaveDescription);
            this.Controls.Add(this.txtTransciption);
            this.Name = "frmDescribeEvent";
            this.Text = "Popup";
            this.Load += new System.EventHandler(this.frmPopupEvent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransciption;
        private System.Windows.Forms.Button btnSaveDescription;
        private System.Windows.Forms.Button btnStartAudio;
        private System.Windows.Forms.Button btnStopAudio;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Button btnTranscribe;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.Label label1;
    }
}