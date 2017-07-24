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
    public partial class FrmNewNote : Form
    {
        cDescription _d;
        public FrmNewNote(cDescription d)
        {
            InitializeComponent();
            _d = d;
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            if (TxtNote.Text != "")
            {
                _d.notes.Add(TxtNote.Text);
            }
            else
            {
                MessageBox.Show("No Note To Save");
            }

        }
    }
}
