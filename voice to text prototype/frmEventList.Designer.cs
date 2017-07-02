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
            this.treeTasks = new System.Windows.Forms.TreeView();
            this.BtnAddToNewTask = new System.Windows.Forms.Button();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstEvents
            // 
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.Location = new System.Drawing.Point(15, 189);
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
            // treeTasks
            // 
            this.treeTasks.Location = new System.Drawing.Point(389, 189);
            this.treeTasks.Name = "treeTasks";
            this.treeTasks.Size = new System.Drawing.Size(291, 432);
            this.treeTasks.TabIndex = 3;
            this.treeTasks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeTasks_AfterSelect);
            // 
            // BtnAddToNewTask
            // 
            this.BtnAddToNewTask.Location = new System.Drawing.Point(311, 348);
            this.BtnAddToNewTask.Name = "BtnAddToNewTask";
            this.BtnAddToNewTask.Size = new System.Drawing.Size(72, 34);
            this.BtnAddToNewTask.TabIndex = 4;
            this.BtnAddToNewTask.Text = "AddToTask";
            this.BtnAddToNewTask.UseVisualStyleBackColor = true;
            this.BtnAddToNewTask.Click += new System.EventHandler(this.BtnAddToNewTask_Click);
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Location = new System.Drawing.Point(478, 149);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(85, 34);
            this.btnCreateTask.TabIndex = 5;
            this.btnCreateTask.Text = "Create Task";
            this.btnCreateTask.UseVisualStyleBackColor = true;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // EventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 644);
            this.Controls.Add(this.btnCreateTask);
            this.Controls.Add(this.BtnAddToNewTask);
            this.Controls.Add(this.treeTasks);
            this.Controls.Add(this.lblnow);
            this.Controls.Add(this.lblstart);
            this.Controls.Add(this.lstEvents);
            this.Name = "EventList";
            this.Text = "UnTagged Events";
            this.Load += new System.EventHandler(this.EventList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EventList_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Label lblstart;
        private System.Windows.Forms.Label lblnow;
        private System.Windows.Forms.TreeView treeTasks;
        private System.Windows.Forms.Button BtnAddToNewTask;
        private System.Windows.Forms.Button btnCreateTask;
    }
}