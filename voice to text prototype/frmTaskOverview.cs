using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voice_to_text_prototype
{
    public partial class frmTaskOverview : Form
    {
        CoreData _c;
        List<cTask> goals;

        cTask selectedTask;

        public frmTaskOverview(CoreData c)
        {
            InitializeComponent();
            _c = c;
            UpdateGoalList(0);

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

        public void UpdateGoalList(int startingNumber)
        {

            treeTasks.Nodes.Clear();
            foreach (var item in _c.tasks)
            {

                if (item.parents.Count == 0)
                {
                    TreeNode t = treeTasks.Nodes.Add(item.taskName);
                    AddTreeNode(t, 0);
                }
            }

        }

        private void frmTaskOverview_Load(object sender, EventArgs e)
        {

        }


        private void treeTasks_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string lel = e.Node.Text;

            foreach (var t in _c.tasks)
            {
                if (t.taskName == lel)
                {
                    lblTaskName.Text = t.taskName;
                    txtNotes.Text = t.notes;
                    lblTargetDate.Text = t.target.ToLongDateString();
                    lblPriority.Text = t.priority.ToString();
                    lblTaskType.Text = t.typeOfTask.ToString();

                    lstTags.Items.Clear();
                    foreach (var tag in t.tags)
                    {
                        lstTags.Items.Add(tag);
                    }

                    PercentComplete.Value = t.percentComplete;

                    selectedTask = t;

                    break;
                }
            }
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            frmTask ft = new frmTask(_c, selectedTask, true);
            ft.Show(); 
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            frmTask ft = new frmTask(_c, new cTask(), false);
            ft.Show();
        }
    }
}
