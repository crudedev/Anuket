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
        
        public frmPopupDescription(int EventNumber, cEvent ev)
        {
            InitializeComponent();
            lblEventDescription.Text = "Event: " + EventNumber.ToString() + " # " + ev.fileName;
            lblDescription.Text = "File Updated";

        }

        private void frmPopupDescription_Load(object sender, EventArgs e)
        {

        }
    }
}
