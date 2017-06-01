using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Windows.Forms;

namespace voice_to_text_prototype
{
    public partial class PopupEvent : Form
    {
        Event eve = new Event();
        Recorder r;
        string pathToEXE;
        Description d;

        string guid;

        bool recordingInProgress = false;

        public PopupEvent(Event e)
        {
            InitializeComponent();
            pathToEXE = Directory.GetCurrentDirectory();
            d = new Description();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (recordingInProgress)
            {
                MessageBox.Show("recording already in progress");
            }
            else
            {

                recordingInProgress = true;
                guid = Guid.NewGuid().ToString();

                d.AudioPaths.Add(guid);
                r = new Recorder(0, pathToEXE + @"\WavStore\", guid + @".wav");
                r.StartRecording();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            r.RecordEnd();


            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$opusenc='" + pathToEXE + @"\opusenc'" + Environment.NewLine + @" & $opusenc --bitrate 64 '" + pathToEXE + @"\WavStore\" + guid + @".wav' '" + pathToEXE + @"\OpusStore\" + guid + @".opus'");

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
    }
}
