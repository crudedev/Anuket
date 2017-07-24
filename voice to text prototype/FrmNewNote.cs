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
        FrmReviewDescriptions _frd;
        public FrmNewNote(cDescription d, FrmReviewDescriptions frd)
        {
            InitializeComponent();
            _d = d;
            _frd = frd;
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            if (TxtNote.Text != "")
            {
                _d.notes.Add(TxtNote.Text);
                _frd.UpdatePanels();
                this.Close();
            }
            else
            {
                MessageBox.Show("No Note To Save");
            }

        }

        private void FrmNewNote_Load(object sender, EventArgs e)
        {

        }
    }
}
