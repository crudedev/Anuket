﻿namespace voice_to_text_prototype
{
    partial class frmForm1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.lstWatchExtension = new System.Windows.Forms.ListBox();
            this.lstWatchPath = new System.Windows.Forms.ListBox();
            this.txtWatchExtension = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.lstTask = new System.Windows.Forms.ListBox();
            this.button14 = new System.Windows.Forms.Button();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.button15 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 308);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 123);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "speech to text result";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(27, 133);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "play";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(26, 232);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 34);
            this.button5.TabIndex = 6;
            this.button5.Text = "Transcribe";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(556, 172);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 27);
            this.button6.TabIndex = 9;
            this.button6.Text = "decode + play";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(27, 177);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 27);
            this.button8.TabIndex = 11;
            this.button8.Text = "encode";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(416, 31);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(327, 131);
            this.txtSend.TabIndex = 12;
            this.txtSend.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(448, 172);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 27);
            this.button9.TabIndex = 13;
            this.button9.Text = "Send";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(467, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "AddWatchFolder";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(335, 214);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(119, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "AddWatchExtension";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // lstWatchExtension
            // 
            this.lstWatchExtension.FormattingEnabled = true;
            this.lstWatchExtension.Location = new System.Drawing.Point(335, 269);
            this.lstWatchExtension.Name = "lstWatchExtension";
            this.lstWatchExtension.Size = new System.Drawing.Size(119, 160);
            this.lstWatchExtension.TabIndex = 16;
            this.lstWatchExtension.Visible = false;
            // 
            // lstWatchPath
            // 
            this.lstWatchPath.FormattingEnabled = true;
            this.lstWatchPath.Location = new System.Drawing.Point(467, 269);
            this.lstWatchPath.Name = "lstWatchPath";
            this.lstWatchPath.Size = new System.Drawing.Size(444, 160);
            this.lstWatchPath.TabIndex = 17;
            // 
            // txtWatchExtension
            // 
            this.txtWatchExtension.Location = new System.Drawing.Point(335, 243);
            this.txtWatchExtension.Name = "txtWatchExtension";
            this.txtWatchExtension.Size = new System.Drawing.Size(119, 20);
            this.txtWatchExtension.TabIndex = 18;
            this.txtWatchExtension.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(758, 123);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(91, 27);
            this.button10.TabIndex = 19;
            this.button10.Text = "show event list";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(765, 180);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(92, 36);
            this.button11.TabIndex = 20;
            this.button11.Text = "create dummy events";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(222, 80);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(92, 19);
            this.button12.TabIndex = 21;
            this.button12.Text = "New Task";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(222, 105);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(92, 19);
            this.button13.TabIndex = 22;
            this.button13.Text = "New Goal";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // lstTask
            // 
            this.lstTask.FormattingEnabled = true;
            this.lstTask.Location = new System.Drawing.Point(924, 29);
            this.lstTask.Name = "lstTask";
            this.lstTask.Size = new System.Drawing.Size(205, 316);
            this.lstTask.TabIndex = 23;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(978, 351);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(92, 36);
            this.button14.TabIndex = 24;
            this.button14.Text = "manage tasks";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(510, 211);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(121, 21);
            this.cmbPriority.TabIndex = 25;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(222, 180);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(92, 19);
            this.button15.TabIndex = 26;
            this.button15.Text = "Goal Overview";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // frmForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 443);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.lstTask);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.txtWatchExtension);
            this.Controls.Add(this.lstWatchPath);
            this.Controls.Add(this.lstWatchExtension);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "frmForm1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListBox lstWatchExtension;
        private System.Windows.Forms.ListBox lstWatchPath;
        private System.Windows.Forms.TextBox txtWatchExtension;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ListBox lstTask;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Button button15;
    }
}

