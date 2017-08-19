using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Anuket
{
    public partial class frmEventList : Form
    {
        CoreData _c;

        cTask _selectedTask;

        public frmEventList(CoreData c)
        {
            InitializeComponent();
            _c = c;
        }

        private void EventList_Load(object sender, EventArgs e)
        {
            updateEventsAndTasks();
        }

        private void updateEventsAndTasks()
        {
            lstEvents.Items.Clear();
            foreach (var item in _c.events)
            {
                if (item.assaignedToTask == false)
                {
                    lstEvents.Items.Add(item);
                }
            }

            treeTasks.Nodes.Clear();
            foreach (var item in _c.tasks)
            {
                if (item.parents.Count == 0)
                {
                    TreeNode t = treeTasks.Nodes.Add(item.taskName);
                    AddTreeNode(t, 0);
                }
            }

            if (_selectedTask != null)
            {
                updateEventsUnderTask(_selectedTask);
            }
        }



        private void AddTreeNode(TreeNode t, int depth)
        {
            if (depth > 100)
            {
                return;
            }

            foreach (var subitem in _c.tasks)
            {
                foreach (var parent in subitem.parents)
                {
                    if (parent.taskName == t.Text)
                    {
                        TreeNode n = t.Nodes.Add(subitem.taskName);
                        AddTreeNode(n, depth++);
                    }
                }
            }

        }

        private void EventList_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 100, 0));
            pen.Width = 4;
            e.Graphics.DrawLine(pen, 20, 100, 800, 100);

            DateTime start = new DateTime();
            DateTime end = new DateTime();

            Font font = new Font("Arial", 8);
            SolidBrush brush = new SolidBrush(Color.Black);

            foreach (var ev in _c.events)
            {
                if (start == new DateTime())
                {
                    start = ev.datetimeOfEvent;
                    end = ev.datetimeOfEvent;
                }

                if (ev.datetimeOfEvent < start)
                {
                    start = ev.datetimeOfEvent;
                }

                if (ev.datetimeOfEvent > end)
                {
                    end = ev.datetimeOfEvent;
                }
            }


            TimeSpan t = end.Subtract(start);
            double deltaSeconds = t.TotalSeconds;

            lblstart.Text = "Start: " + start.ToString();
            lblnow.Text = "Now: " + end.ToString();


            int index = 0;

            foreach (var ev in _c.events)
            {
                index++;
                double width = 700;
                TimeSpan ts = ev.datetimeOfEvent.Subtract(start);
                double seconds = ts.TotalSeconds;

                if (seconds != 0)
                {
                    double pixelpersecond = width / deltaSeconds;

                    int xCord = Convert.ToInt32(pixelpersecond * seconds);

                    e.Graphics.DrawLine(pen, xCord + 100, 80, xCord + 100, 120);

                    e.Graphics.DrawString("Event: " + index.ToString(), font, brush, xCord, 50 - index);
                }

            }

        }

        private void treeTasks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (var item in _c.tasks)
            {
                if (item.taskName == e.Node.Text)
                {
                    _selectedTask = item;
                    updateEventsUnderTask(item);
                }
            }
        }

        private void updateEventsUnderTask(cTask value)
        {
            int undescribed = 0;
            lstEventsInTask.Items.Clear();
            if (value.events != null)

            {
                foreach (var item in value.events)
                {
                    lstEventsInTask.Items.Add(item);
                    if (item.described == false)
                    {
                        undescribed++;
                    }
                }
            }
            lblEventsInTask.Text = "Events (" + undescribed.ToString() + ") Undescribed";
        }

        private void BtnAddToNewTask_Click(object sender, EventArgs e)
        {
            if (_selectedTask != null)
            {
                foreach (var item in _c.tasks)
                {
                    if (item.taskName == _selectedTask.taskName)
                    {
                        if (item.events == null)
                        {
                            item.events = new List<cFileEvent>();
                        }
                        cFileEvent ev = (cFileEvent)lstEvents.SelectedItem;
                        item.events.Add(ev);
                        ev.assaignedToTask = true;
                    }
                }
            }
            updateEventsAndTasks();
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            frmTask f = new frmTask(_c, new cTask(), false);
            f.Show();
        }

        private void btnDescrineChanges_Click(object sender, EventArgs e)
        {
            if (_selectedTask != null)
            {
                frmDescribeEvent fde = new frmDescribeEvent(_selectedTask, _c);
                fde.Show();
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            frmTask f = new frmTask(_c, _selectedTask, true);
            f.Show();
        }
    }
}
