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
    public partial class frmPopupDescription : Form
    {
        frmForm1 _f;
        public frmPopupDescription(frmForm1 f, int EventNumber, cEvent ev)
        {
            InitializeComponent();
            _f = f;
            lblEventDescription.Text = "Event: " + EventNumber.ToString() + " # " + ev.fileName;
            lblDescription.Text = "File Updated";
    
        }

        private void frmPopupDescription_Load(object sender, EventArgs e)
        {

        }

        private void BtnCreateDescription_Click(object sender, EventArgs e)
        {
            frmEventList fel = new frmEventList(_f);
            fel.Show();
            this.Close();
        }
    }
}
