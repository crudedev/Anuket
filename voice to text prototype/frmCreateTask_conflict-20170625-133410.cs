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
    public partial class frmCreateTask : Form
    {
        frmForm1 _f;

        cTask _t;

        public frmCreateTask(frmForm1 f)
        {
            _f = f;
            InitializeComponent();
            updateTags();
            _t = new cTask();
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
            if(_f.c.tags == null)
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
            foreach (var item in _f.c.tags)
            {
                cmbAddTags.Items.Add(item.Value);
            }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {

        }
    }
}
