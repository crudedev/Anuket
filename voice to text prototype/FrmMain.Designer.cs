namespace voice_to_text_prototype
{
    partial class FrmMain
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
            this.btnTaskOverview = new System.Windows.Forms.Button();
            this.btnNewTask = new System.Windows.Forms.Button();
            this.btnManageTasks = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnShowEventlist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTaskOverview
            // 
            this.btnTaskOverview.Location = new System.Drawing.Point(123, 165);
            this.btnTaskOverview.Name = "btnTaskOverview";
            this.btnTaskOverview.Size = new System.Drawing.Size(92, 19);
            this.btnTaskOverview.TabIndex = 28;
            this.btnTaskOverview.Text = "Tasks Overview";
            this.btnTaskOverview.UseVisualStyleBackColor = true;
            this.btnTaskOverview.Click += new System.EventHandler(this.btnTaskOverview_Click);
            // 
            // btnNewTask
            // 
            this.btnNewTask.Location = new System.Drawing.Point(123, 140);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(92, 19);
            this.btnNewTask.TabIndex = 27;
            this.btnNewTask.Text = "New Task";
            this.btnNewTask.UseVisualStyleBackColor = true;
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // btnManageTasks
            // 
            this.btnManageTasks.Location = new System.Drawing.Point(123, 190);
            this.btnManageTasks.Name = "btnManageTasks";
            this.btnManageTasks.Size = new System.Drawing.Size(92, 23);
            this.btnManageTasks.TabIndex = 30;
            this.btnManageTasks.Text = "manage tasks";
            this.btnManageTasks.UseVisualStyleBackColor = true;
            this.btnManageTasks.Click += new System.EventHandler(this.btnManageTasks_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(100, 26);
            this.btnSettings.TabIndex = 31;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnShowEventlist
            // 
            this.btnShowEventlist.Location = new System.Drawing.Point(123, 70);
            this.btnShowEventlist.Name = "btnShowEventlist";
            this.btnShowEventlist.Size = new System.Drawing.Size(91, 27);
            this.btnShowEventlist.TabIndex = 32;
            this.btnShowEventlist.Text = "show event list";
            this.btnShowEventlist.UseVisualStyleBackColor = true;
            this.btnShowEventlist.Click += new System.EventHandler(this.btnShowEventlist_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 586);
            this.Controls.Add(this.btnShowEventlist);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnManageTasks);
            this.Controls.Add(this.btnTaskOverview);
            this.Controls.Add(this.btnNewTask);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTaskOverview;
        private System.Windows.Forms.Button btnNewTask;
        private System.Windows.Forms.Button btnManageTasks;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnShowEventlist;
    }
}