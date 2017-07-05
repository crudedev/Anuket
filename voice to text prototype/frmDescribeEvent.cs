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

        bool recordingInProgress = false;
        CoreData _c;

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
                d.AudioPaths.Add(_guid[_guid.Count-1]);

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

           
        }

        private void btnSaveDescription_Click(object sender, EventArgs e)
        {

        }
    }
}
