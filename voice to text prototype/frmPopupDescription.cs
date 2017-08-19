using System;
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
    public partial class frmPopupDescription : Form
    {
        CoreData _c;
        public frmPopupDescription(CoreData c, int EventNumber, cFileEvent ev)
        {
            InitializeComponent();
            _c = c;
            lblEventDescription.Text = "Event: " + EventNumber.ToString() + " # " + ev.fileName;
            lblDescription.Text = "File Updated";
    
        }

        private void frmPopupDescription_Load(object sender, EventArgs e)
        {

        }

        private void BtnCreateDescription_Click(object sender, EventArgs e)
        {
            frmEventList fel = new frmEventList(_c);
            fel.Show();
            this.Close();
        }
    }
}
