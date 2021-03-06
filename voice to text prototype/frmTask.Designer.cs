﻿namespace Anuket
{
    partial class frmTask
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.PercentComplete = new System.Windows.Forms.ProgressBar();
            this.targetDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.cmbAddTags = new System.Windows.Forms.ComboBox();
            this.txtNewTag = new System.Windows.Forms.TextBox();
            this.btnCreateTag = new System.Windows.Forms.Button();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.cmbTypeTask = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Parent = new System.Windows.Forms.Label();
            this.cmbParent = new System.Windows.Forms.ComboBox();
            this.lstDescriptions = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddDescription = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(25, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(629, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Task Name:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(25, 74);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(235, 178);
            this.txtNotes.TabIndex = 1;
            this.txtNotes.Text = "task Notes";
            // 
            // PercentComplete
            // 
            this.PercentComplete.Location = new System.Drawing.Point(272, 228);
            this.PercentComplete.Name = "PercentComplete";
            this.PercentComplete.Size = new System.Drawing.Size(388, 23);
            this.PercentComplete.TabIndex = 2;
            this.PercentComplete.Click += new System.EventHandler(this.PercentComplete_Click);
            // 
            // targetDate
            // 
            this.targetDate.Location = new System.Drawing.Point(282, 84);
            this.targetDate.Name = "targetDate";
            this.targetDate.Size = new System.Drawing.Size(200, 20);
            this.targetDate.TabIndex = 3;
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.cmbPriority.Location = new System.Drawing.Point(282, 115);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(121, 21);
            this.cmbPriority.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "100 = low, 0 = high";
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(27, 287);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(233, 160);
            this.lstTags.TabIndex = 6;
            // 
            // cmbAddTags
            // 
            this.cmbAddTags.FormattingEnabled = true;
            this.cmbAddTags.Location = new System.Drawing.Point(303, 312);
            this.cmbAddTags.Name = "cmbAddTags";
            this.cmbAddTags.Size = new System.Drawing.Size(150, 21);
            this.cmbAddTags.TabIndex = 7;
            // 
            // txtNewTag
            // 
            this.txtNewTag.Location = new System.Drawing.Point(505, 312);
            this.txtNewTag.Name = "txtNewTag";
            this.txtNewTag.Size = new System.Drawing.Size(174, 20);
            this.txtNewTag.TabIndex = 8;
            this.txtNewTag.Text = "New Tag";
            // 
            // btnCreateTag
            // 
            this.btnCreateTag.Location = new System.Drawing.Point(548, 339);
            this.btnCreateTag.Name = "btnCreateTag";
            this.btnCreateTag.Size = new System.Drawing.Size(77, 32);
            this.btnCreateTag.TabIndex = 9;
            this.btnCreateTag.Text = "Create Tag";
            this.btnCreateTag.UseVisualStyleBackColor = true;
            this.btnCreateTag.Click += new System.EventHandler(this.btnCreateTag_Click);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(335, 339);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(68, 30);
            this.btnAddTag.TabIndex = 10;
            this.btnAddTag.Text = "Add Tag";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // cmbTypeTask
            // 
            this.cmbTypeTask.FormattingEnabled = true;
            this.cmbTypeTask.Location = new System.Drawing.Point(282, 157);
            this.cmbTypeTask.Name = "cmbTypeTask";
            this.cmbTypeTask.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeTask.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Type of task";
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Location = new System.Drawing.Point(938, 420);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(77, 32);
            this.btnCreateTask.TabIndex = 13;
            this.btnCreateTask.Text = "Create Task";
            this.btnCreateTask.UseVisualStyleBackColor = true;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Percentage Complete";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Target date";
            // 
            // Parent
            // 
            this.Parent.AutoSize = true;
            this.Parent.Location = new System.Drawing.Point(443, 53);
            this.Parent.Name = "Parent";
            this.Parent.Size = new System.Drawing.Size(38, 13);
            this.Parent.TabIndex = 17;
            this.Parent.Text = "Parent";
            // 
            // cmbParent
            // 
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Location = new System.Drawing.Point(282, 50);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Size = new System.Drawing.Size(121, 21);
            this.cmbParent.TabIndex = 16;
            // 
            // lstDescriptions
            // 
            this.lstDescriptions.FormattingEnabled = true;
            this.lstDescriptions.Location = new System.Drawing.Point(705, 45);
            this.lstDescriptions.Name = "lstDescriptions";
            this.lstDescriptions.Size = new System.Drawing.Size(310, 342);
            this.lstDescriptions.TabIndex = 18;
            this.lstDescriptions.SelectedIndexChanged += new System.EventHandler(this.lstDescriptions_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(702, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Descriptions";
            // 
            // btnAddDescription
            // 
            this.btnAddDescription.Location = new System.Drawing.Point(705, 420);
            this.btnAddDescription.Name = "btnAddDescription";
            this.btnAddDescription.Size = new System.Drawing.Size(95, 32);
            this.btnAddDescription.TabIndex = 20;
            this.btnAddDescription.Text = "Add Descriptions";
            this.btnAddDescription.UseVisualStyleBackColor = true;
            this.btnAddDescription.Click += new System.EventHandler(this.btnAddDescription_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Task Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Task Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Tags";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Select A Tag";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(511, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Name a new tag";
            // 
            // frmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 464);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAddDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstDescriptions);
            this.Controls.Add(this.Parent);
            this.Controls.Add(this.cmbParent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTypeTask);
            this.Controls.Add(this.btnAddTag);
            this.Controls.Add(this.btnCreateTag);
            this.Controls.Add(this.txtNewTag);
            this.Controls.Add(this.cmbAddTags);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.targetDate);
            this.Controls.Add(this.PercentComplete);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtName);
            this.Name = "frmTask";
            this.Text = "CreateTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ProgressBar PercentComplete;
        private System.Windows.Forms.DateTimePicker targetDate;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.ComboBox cmbAddTags;
        private System.Windows.Forms.TextBox txtNewTag;
        private System.Windows.Forms.Button btnCreateTag;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.ComboBox cmbTypeTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Parent;
        private System.Windows.Forms.ComboBox cmbParent;
        private System.Windows.Forms.ListBox lstDescriptions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}