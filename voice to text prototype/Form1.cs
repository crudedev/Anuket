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

            r = new Recorder(0, @"C:\", Guid.NewGuid() + "test.wav");

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
                PowerShellInstance.AddScript(@"$ffmpeg='C:\ffmpeg'" + Environment.NewLine + @" & $ffmpeg -i C:\lol.wav -acodec libopus -b:a 64k -vbr on -compression_level 10 C:\output.ogg");

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
                    string curlstring = @"$curl='C:\curl'" + Environment.NewLine + @"& $curl -X POST -u  " + credentials + @" --header 'Content-Type: audio/ogg;codecs=opus' --header 'Transfer-Encoding: chunked' --data-binary @C:\output.ogg 'https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?continuous=true' --insecure";

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

        private void button7_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$opusdec='C:\opusdec'" + Environment.NewLine + @" & $opusdec C:\lol.wav.opus C:\lol5.wav ");
                //opusenc --bitrate 64 What_A_Feeling.wav What_A_Feeling_64.opus
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

        private void button8_Click(object sender, EventArgs e)
        {
            //encode

            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$opusenc='C:\opusenc'" + Environment.NewLine + @" & $opusenc --bitrate 64 C:\lol.wav C:\lol.wav.opus");
                //opusenc --bitrate 64 What_A_Feeling.wav What_A_Feeling_64.opus
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
    }
}
