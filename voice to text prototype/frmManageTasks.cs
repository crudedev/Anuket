﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anuket
{
    public partial class frmManageTasks : Form
    {
        CoreData _c;

        cTask SelectedTask;

        public frmManageTasks(CoreData c)
        {
            _c = c;
            InitializeComponent();
            updateList();

        }

        public void updateList()
        {
            lstTasks.Items.Clear();


            foreach (var item in _c.tasks)
            {
                //if (item.Show == true)
                //{
                    lstTasks.Items.Add(item);
                //}
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTask = (cTask)lstTasks.SelectedItem;
        }

        private void frmManageTasks_Load(object sender, EventArgs e)
        {

        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            List<cTask> todelete = new List<cTask>();

            foreach (var item in _c.tasks)
            {
                if (item == SelectedTask)
                {
                    todelete.Add(item);
                }
            }

            foreach (var item in todelete)
            {
                _c.tasks.Remove(item);
            }
            updateList();
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            SelectedTask.finsihed = DateTime.Now;
            SelectedTask.percentComplete = 100;
            updateList();
        }

        private void btnHideTask_Click(object sender, EventArgs e)
        {
            SelectedTask.Show = false;
            updateList();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            frmTask ft = new frmTask(_c, SelectedTask,true);
            ft.Show();
        }
    }
}
