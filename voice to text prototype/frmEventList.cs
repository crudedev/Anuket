using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace voice_to_text_prototype
{
    public partial class EventList : Form
    {
        frmForm1 _f;

        string _selectedNode;

        public EventList(frmForm1 f)
        {
            InitializeComponent();
            _f = f;
        }

        private void EventList_Load(object sender, EventArgs e)
        {
            foreach (var item in _f.c.events)
            {
                //datetimeOfEvent.ToString() + item.Value.fileName
                lstEvents.Items.Add(item.Value);
            }

            foreach (var item in _f.c.tasks)
            {
                if (item.Value.parents.Count == 0)
                {
                    TreeNode t = treeTasks.Nodes.Add(item.Value.taskName);
                    AddTreeNode(t, 0);
                }

            }
        }



        private void AddTreeNode(TreeNode t, int depth)
        {
            if (depth > 100)
            {
                return;
            }

            foreach (var subitem in _f.c.tasks)
            {
                foreach (var parent in subitem.Value.parents)
                {
                    if (parent.taskName == t.Text)
                    {
                        TreeNode n= t.Nodes.Add(subitem.Value.taskName);
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

            foreach (var ev in _f.c.events)
            {
                if (start == new DateTime())
                {
                    start = ev.Value.datetimeOfEvent;
                    end = ev.Value.datetimeOfEvent;
                }

                if (ev.Value.datetimeOfEvent < start)
                {
                    start = ev.Value.datetimeOfEvent;
                }

                if (ev.Value.datetimeOfEvent > end)
                {
                    end = ev.Value.datetimeOfEvent;
                }
            }


            TimeSpan t = end.Subtract(start);
            double deltaSeconds = t.TotalSeconds;

            lblstart.Text = "Start: " + start.ToString();
            lblnow.Text = "Now: " + end.ToString();


            int index = 0;

            foreach (var ev in _f.c.events)
            {
                index++;
                double width = 700;
                TimeSpan ts = ev.Value.datetimeOfEvent.Subtract(start);
                double seconds = ts.TotalSeconds;

                double pixelpersecond = width / deltaSeconds;

                int xCord = Convert.ToInt32(pixelpersecond * seconds);

                e.Graphics.DrawLine(pen, xCord + 100, 80, xCord + 100, 120);

                e.Graphics.DrawString("Event: " + index.ToString(), font, brush, xCord, 50 - index);

            }

        }

        private void treeTasks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedNode = e.Node.Text;
        }

        private void BtnAddToNewTask_Click(object sender, EventArgs e)
        {
            if(_selectedNode != "")
            {
                foreach (var item in _f.c.tasks)
                {
                    if(item.Value.taskName == _selectedNode)
                    {
                        if(item.Value.events == null)
                        {
                            item.Value.events = new List<cEvent>();
                        }
                        item.Value.events.Add((cEvent)lstEvents.SelectedItem);
                    }
                }
            }
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            frmTask f = new frmTask(_f,new cTask(),false);
        }
    }
}
