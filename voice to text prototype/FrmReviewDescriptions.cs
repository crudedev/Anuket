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
    public partial class FrmReviewDescriptions : Form
    {
        cDescription _d;
        int _selectedNoteIndex;
        int _selectedAudioIndex;
        int _selectedFileIndex;

        public FrmReviewDescriptions(cDescription d)
        {
            InitializeComponent();
            _d = d;
        }

        private void FrmReviewDescriptions_Load(object sender, EventArgs e)
        {
            UpdatePanels();

        }

        public void UpdatePanels()
        {
            lstNotes.Items.Clear();
            foreach (var item in _d.notes)
            {
                string shortNote = "";
                if (item.Length > 50)
                {
                    shortNote = item.Substring(0, 50) + ".....";
                }
                else
                {
                    shortNote = item;
                }
                lstNotes.Items.Add(shortNote);
            }

            lstAudio.Items.Clear();
            foreach (var item in _d.audioPaths)
            {
                lstAudio.Items.Add(item);
            }


            lstAttachments.Items.Clear();
            foreach (var item in _d.attachments)
            {
                lstAttachments.Items.Add(item);
            }

            if (_d.notes != null)
            {
                if (_selectedNoteIndex != -1)
                {
                    txtNote.Text = _d.notes[_selectedNoteIndex];
                }
            }
            if (_d.transcriptions != null)
            {
                if (_selectedAudioIndex != -1)
                {
                    txtTranscription.Text = _d.transcriptions[_selectedAudioIndex];
                }
            }


        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedNoteIndex = lstNotes.SelectedIndex;
            UpdatePanels();
        }

        private void lstAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAudioIndex = lstAudio.SelectedIndex;
            UpdatePanels();
        }

        private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedFileIndex = lstAttachments.SelectedIndex;
            UpdatePanels();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //to be implemented
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmNewNote frn = new FrmNewNote(_d,this);
            frn.Show();
        }
    }
}
