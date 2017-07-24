using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Windows.Forms;

namespace voice_to_text_prototype
{
    public partial class frmDescribeEvent : Form
    {
        cTask _task = new cTask();
        cRecorder r;
        cDescription d;

        List<string> _guid;
        List<string> _transcriptions;

        bool recordingInProgress = false;
        CoreData _c;

        List<string> _filePaths;

        public frmDescribeEvent(cTask t, CoreData c)
        {
            _c = c;
            InitializeComponent();

            d = new cDescription();
            _task = t;

            foreach (var item in _task.events)
            {
                if (item.described == false)
                {
                    lstEvents.Items.Add(item);
                }
            }
            _guid = new List<string>();
        }

        private void btnStartAudio_Click(object sender, EventArgs e)
        {
            if (recordingInProgress)
            {
                MessageBox.Show("recording already in progress");
            }
            else
            {

                recordingInProgress = true;
                _guid.Add(Guid.NewGuid().ToString());
                d.audioPaths.Add(_guid[_guid.Count - 1]);

                r = new cRecorder(0, _c.pathToEXE + @"\WavStore\", _guid[_guid.Count - 1] + @".wav");
                r.StartRecording();

            }
        }

        private void btnStopAudio_Click(object sender, EventArgs e)
        {
            r.RecordEnd();

            cRecorder.convert(_c, _guid[_guid.Count - 1]);

            recordingInProgress = false;
        }

        private void frmPopupEvent_Load(object sender, EventArgs e)
        {
            lblTaskName.Text = "Task: " + _task.taskName;
        }

        private void btnTranscribe_Click(object sender, EventArgs e)
        {
            string ret = "";

            if (_guid.Count != 0)
            {
                cSpeechManager.transcribe(_c, _guid[_guid.Count - 1]);
            }

            txtTransciption.Text = ret;

            if (_transcriptions == null)
            {
                _transcriptions = new List<string>();
            }
            _transcriptions.Add(ret);

        }

        private void btnSaveDescription_Click(object sender, EventArgs e)
        {
            d.audioPaths = _guid;

            if (txtNotes.Text != "")
            {
                d.notes = new List<string>();
                d.notes.Add(txtNotes.Text);
            }

            d.transcriptions = _transcriptions;

            if (_task.descriptions == null)
            {
                _task.descriptions = new List<cDescription>();
            }
            _task.descriptions.Add(d);

            this.Close();
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog dia = new OpenFileDialog();
             
            string newFilename="";
            string fileName = "";

            if (dia.ShowDialog() == DialogResult.OK)
            {


                Stream file = dia.OpenFile();

                string[]  fileNameParts = dia.FileName.Split('.');
                newFilename = Guid.NewGuid() + "." + fileNameParts[fileNameParts.Length - 1];
                FileStream fileStream = File.Create(_c.pathToEXE + @"\DataStore\" + newFilename , (int)file.Length);
                byte[] bytesInStream = new byte[file.Length];
                file.Read(bytesInStream, 0, bytesInStream.Length);
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                fileStream.Flush();
                fileStream.Close();
            }

            d.attachments.Add(newFilename, fileName);

        }
    }
}
