namespace voice_to_text_prototype
{
    partial class frmTaskOverview
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
            this.label2 = new System.Windows.Forms.Label();
            this.treeTasks = new System.Windows.Forms.TreeView();
            this.lblTargetDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTaskType = new System.Windows.Forms.Label();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.PercentComplete = new System.Windows.Forms.ProgressBar();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tasks";
            // 
            // treeTasks
            // 
            this.treeTasks.Location = new System.Drawing.Point(12, 78);
            this.treeTasks.Name = "treeTasks";
            this.treeTasks.Size = new System.Drawing.Size(291, 599);
            this.treeTasks.TabIndex = 10;
            this.treeTasks.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeTasks_NodeMouseClick);
            // 
            // lblTargetDate
            // 
            this.lblTargetDate.AutoSize = true;
            this.lblTargetDate.Location = new System.Drawing.Point(633, 118);
            this.lblTargetDate.Name = "lblTargetDate";
            this.lblTargetDate.Size = new System.Drawing.Size(62, 13);
            this.lblTargetDate.TabIndex = 28;
            this.lblTargetDate.Text = "Target date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(613, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Percentage Complete";
            // 
            // lblTaskType
            // 
            this.lblTaskType.AutoSize = true;
            this.lblTaskType.Location = new System.Drawing.Point(633, 175);
            this.lblTaskType.Name = "lblTaskType";
            this.lblTaskType.Size = new System.Drawing.Size(66, 13);
            this.lblTaskType.TabIndex = 26;
            this.lblTaskType.Text = "Type of task";
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(368, 326);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(233, 186);
            this.lstTags.TabIndex = 24;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(633, 144);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(89, 13);
            this.lblPriority.TabIndex = 23;
            this.lblPriority.Text = "Priority out of 100";
            // 
            // PercentComplete
            // 
            this.PercentComplete.Enabled = false;
            this.PercentComplete.Location = new System.Drawing.Point(613, 293);
            this.PercentComplete.Name = "PercentComplete";
            this.PercentComplete.Size = new System.Drawing.Size(388, 23);
            this.PercentComplete.TabIndex = 20;
            // 
            // txtNotes
            // 
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(366, 115);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(235, 202);
            this.txtNotes.TabIndex = 19;
            this.txtNotes.Text = "task Notes";
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(365, 78);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(65, 13);
            this.lblTaskName.TabIndex = 29;
            this.lblTaskName.Text = "Task Name:";
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Location = new System.Drawing.Point(780, 541);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(85, 43);
            this.btnCreateTask.TabIndex = 30;
            this.btnCreateTask.Text = "EditTask";
            this.btnCreateTask.UseVisualStyleBackColor = true;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // frmTaskOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 689);
            this.Controls.Add(this.btnCreateTask);
            this.Controls.Add(this.lblTaskName);
            this.Controls.Add(this.lblTargetDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTaskType);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.PercentComplete);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeTasks);
            this.Name = "frmTaskOverview";
            this.Text = "frmTaskOverview";
            this.Load += new System.EventHandler(this.frmTaskOverview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeTasks;
        private System.Windows.Forms.Label lblTargetDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTaskType;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ProgressBar PercentComplete;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Button btnCreateTask;
    }
}