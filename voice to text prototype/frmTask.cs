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
    public partial class frmTask : Form
    {
        frmForm1 _f;

        cTask _t;

        bool _extant = false;

        public frmTask(frmForm1 f, cTask t, bool extant)
        {
            _f = f;
            _t = t;
            if (_t == null)
            {
                _t = new cTask();
            }

            _extant = extant;


            InitializeComponent();
            updateTags();

            foreach (var item in _t.ttype)
            {
                cmbTypeTask.Items.Add(item.Key);
            }


            txtName.Text = _t.taskName;
            txtNotes.Text = _t.notes;
            foreach (var item in _t.tags)
            {
                lstTags.Items.Add(item);
            }

            try
            {
                targetDate.Value = _t.target;
            }
            catch (Exception)
            {

            }

            cmbParent.Items.Clear();
            if (_f.c.tasks != null)
            {
                foreach (var item in _f.c.tasks)
                {
                    cmbParent.Items.Add(item.taskName);
                }
            }

            cmbPriority.Text = _t.priority.ToString();
            cmbTypeTask.SelectedValue = _t.typeOfTask;
            PercentComplete.Value = _t.percentComplete;


        }

        private void PercentComplete_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int x = me.X;

            double delta = x;

            double percent = delta / PercentComplete.Width;

            PercentComplete.Value = Convert.ToInt32(percent * 100);

        }

        private void btnCreateTag_Click(object sender, EventArgs e)
        {
            if (_f.c.tags == null)
            {
                _f.c.tags = new Dictionary<string, string>();
            }

            try
            {
                _f.c.tags.Add(txtNewTag.Text, txtNewTag.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("tag already exists");
            }
            updateTags();

        }


        private void updateTags()
        {
            if (_f.c.tags == null)
            {
                _f.c.tags = new Dictionary<string, string>();
            }
            cmbAddTags.Items.Clear();
            foreach (var item in _f.c.tags)
            {
                cmbAddTags.Items.Add(item.Value);
            }

            if (_t.tags == null)
            {
                _t.tags = new Dictionary<string, string>();
            }
            lstTags.Items.Clear();
            foreach (var item in _t.tags)
            {
                lstTags.Items.Add(item.Value);
            }



        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            if (_t.tags == null)
            {
                _t.tags = new Dictionary<string, string>();
            }
            try
            {
                _t.tags.Add(_f.c.tags[cmbAddTags.Text], _f.c.tags[cmbAddTags.Text]);
            }
            catch (Exception)
            {
                MessageBox.Show("Tag already used on this task or tag not added to tag collection");
            }
            updateTags();

        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            _t.created = DateTime.Now;
            _t.notes = txtNotes.Text;
            _t.percentComplete = PercentComplete.Value;
            _t.priority = Convert.ToInt32(cmbPriority.Text);
            _t.target = targetDate.Value.Date;
            _t.taskName = txtName.Text;
            if (cmbTypeTask.Text != "")
            {
                _t.typeOfTask = _t.ttype[cmbTypeTask.Text];
            }
            _t.Show = true;

            if (_f.c.tasks == null)
            {
                _f.c.tasks = new List<cTask>();
            }
            if (!_extant)
            {
                _f.c.tasks.Add(_t);
            }


            if (_t.parents == null)
            {
                _t.parents = new List<cTask>();
            }

            if (cmbParent.Text != "")
            {
                foreach (var item in _f.c.tasks)
                {
                    if (item.taskName == cmbParent.Text)
                    {
                        _t.parents.Add(item);
                    }
                }
            }

            _f.UpdateTasks();

            this.Close();

        }
    }
}
