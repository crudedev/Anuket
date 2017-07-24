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

                r = new cRecorder(0, _c.pathToEXE + @"\WavStore\", _guid + @".wav");
                r.StartRecording();

            }
        }

        private void btnStopAudio_Click(object sender, EventArgs e)
        {
            r.RecordEnd();


            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$opusenc='" + _c.pathToEXE + @"\opusenc'" + Environment.NewLine + @" & $opusenc --bitrate 64 '" + _c.pathToEXE + @"\WavStore\" + _guid + @".wav' '" + _c.pathToEXE + @"\OpusStore\" + _guid + @".opus'");

                try
                {

                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                    foreach (PSObject outputItem in PSOutput)
                    {
                        if (outputItem != null)
                        {
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            recordingInProgress = false;
        }

        private void frmPopupEvent_Load(object sender, EventArgs e)
        {
            lblTaskName.Text = "Task: " + _task.taskName;
        }

        private void btnTranscribe_Click(object sender, EventArgs e)
        {
            string ret = "";
            try
            {

                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    string curlstring = @"$curl='" + _c.pathToEXE + @"\curl'" + Environment.NewLine + @"& $curl -X POST -u  " + _c.stCredentials + @" --header 'Content-Type: audio/ogg;codecs=opus' --header 'Transfer-Encoding: chunked' --data-binary '@" + _c.pathToEXE + @"\OpusStore\" + _guid + @"' 'https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?continuous=true' --insecure";

                    PowerShellInstance.AddScript(curlstring);

                    try
                    {

                        Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                        foreach (PSObject outputItem in PSOutput)
                        {
                            if (outputItem != null)
                            {
                                ret += outputItem;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            catch (Exception exx)
            {

                throw;
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

            if(_task.descriptions == null)
            {
                _task.descriptions = new List<cDescription>();
            }
            _task.descriptions.Add(d);

            this.Close();
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                Stream file = d.OpenFile();

                string[] fileNameParts = d.FileName.Split('.');
                FileStream fileStream = File.Create(_c.pathToEXE + @"\DataStore\" + Guid.NewGuid() + "." + fileNameParts[fileNameParts.Length - 1], (int)file.Length);
                byte[] bytesInStream = new byte[file.Length];
                file.Read(bytesInStream, 0, bytesInStream.Length);
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                fileStream.Flush();
                fileStream.Close();
            }


            //show a list of attached files



        }
    }
}
