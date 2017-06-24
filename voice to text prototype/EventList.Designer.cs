namespace voice_to_text_prototype
{
    partial class EventList
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
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.lblstart = new System.Windows.Forms.Label();
            this.lblnow = new System.Windows.Forms.Label();
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstEvents
            // 
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.Location = new System.Drawing.Point(420, 152);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(290, 433);
            this.lstEvents.TabIndex = 0;
            // 
            // lblstart
            // 
            this.lblstart.AutoSize = true;
            this.lblstart.Location = new System.Drawing.Point(12, 42);
            this.lblstart.Name = "lblstart";
            this.lblstart.Size = new System.Drawing.Size(27, 13);
            this.lblstart.TabIndex = 1;
            this.lblstart.Text = "start";
            // 
            // lblnow
            // 
            this.lblnow.AutoSize = true;
            this.lblnow.Location = new System.Drawing.Point(802, 42);
            this.lblnow.Name = "lblnow";
            this.lblnow.Size = new System.Drawing.Size(27, 13);
            this.lblnow.TabIndex = 2;
            this.lblnow.Text = "now";
            // 
            // lstNodes
            // 
            this.lstNodes.FormattingEnabled = true;
            this.lstNodes.Location = new System.Drawing.Point(12, 152);
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.Size = new System.Drawing.Size(290, 433);
            this.lstNodes.TabIndex = 3;
            // 
            // EventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 644);
            this.Controls.Add(this.lstNodes);
            this.Controls.Add(this.lblnow);
            this.Controls.Add(this.lblstart);
            this.Controls.Add(this.lstEvents);
            this.Name = "EventList";
            this.Text = "EventList";
            this.Load += new System.EventHandler(this.EventList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EventList_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Label lblstart;
        private System.Windows.Forms.Label lblnow;
        private System.Windows.Forms.ListBox lstNodes;
    }
}