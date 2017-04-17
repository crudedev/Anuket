using System;
using System.IO;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Media;

namespace voice_to_text_prototype
{
    public partial class Form1 : Form
    {
        Recorder r;

        readonly string credentials;

        public Form1()
        {
            InitializeComponent();

            r = new Recorder(0, @"C:\", "test.wav");

            credentials = File.ReadAllText(@"C:\credentials.txt");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            r.StartRecording();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r.RecordEnd();
        }

        private void button4_ClickAsync(object sender, EventArgs e)
        {
            convertSound();
        }


        private void convertSound()
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$flac='C:\flac'" + Environment.NewLine + @" & $flac C:\test.wav");

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
        }

        private string sendSound()
        {

            string ret = "";
            try
            {

                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    string curlstring = @"$curl='C:\curl'" + Environment.NewLine + @"& $curl -X POST -u  " + credentials + @" --header 'Content-Type: audio/flac' --header 'Transfer-Encoding: chunked' --data-binary @C:\test.flac 'https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?continuous=true' --insecure";

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
            catch (Exception e)
            {

                throw;
            }

            return ret;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = sendSound();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\test.wav");
            simpleSound.Play();
        }
    }
}
