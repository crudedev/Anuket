using System;
using System.IO;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Media;
using System.Collections.Generic;

namespace voice_to_text_prototype
{
    public partial class Form1 : Form
    {
        Recorder r;

        readonly string stCredentials;
        readonly string tsCredentials;

        readonly string pathToEXE;

        List<string> foldersToWatch;
        List<string> fileExtensionsToWatch;
        List<string> exclusionList;
        private FolderBrowserDialog folderBrowserDialog1;

        public Form1()
        {
            InitializeComponent();
            pathToEXE = Directory.GetCurrentDirectory();

            r = new Recorder(0, pathToEXE + @"\WavStore\", Guid.NewGuid() + "test.wav");

            stCredentials = File.ReadAllText(pathToEXE + @"\stcredentials.txt");
            tsCredentials = File.ReadAllText(pathToEXE + @"\tscredentials.txt");



            try
            {
                string[] folderarray = File.ReadAllText(pathToEXE + @"\foldersToWatch.txt").Split(',');

                foreach (var item in folderarray)
                {
                    foldersToWatch.Add(item);
                    saveFolderWatch();

                }

                if (foldersToWatch == null)
                {
                    throw new Exception();
                }
            }

            catch (Exception ex)
            {

                DialogResult dialogResult = MessageBox.Show("No folders to watch detected would you like to add one", "No refernce found", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    addFoldersToWatch();
                }
                else if (dialogResult == DialogResult.No)
                {

                }




            }

        }

        private void saveFolderWatch()
        {
            string writeToFile = "";

            foreach (var item in foldersToWatch)
            {
                writeToFile += item + ",";
            }

            File.WriteAllText(pathToEXE + @"\foldersToWatch.txt", writeToFile);

            UpdateFolderWatch();
        }

        private void UpdateFolderWatch()
        {

            foreach (var path in foldersToWatch)
            {
                if (fileExtensionsToWatch.Count > 0)
                {
                    fileExtensionsToWatch.Add("*");
                }
                foreach (var extension in fileExtensionsToWatch)
                {

                    FileSystemWatcher watcher = new FileSystemWatcher();
                    watcher.Path = path;
                    watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    watcher.Filter = "*." + extension;
                    watcher.Changed += new FileSystemEventHandler(OnChanged);
                    watcher.EnableRaisingEvents = true;
                }

            }

        }

        private void addFoldersToWatch()
        {

            folderBrowserDialog1 = new FolderBrowserDialog();
            //folderBrowserDialog1.ShowDialog();

            if (foldersToWatch == null)
            {
                foldersToWatch = new List<string>();
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foldersToWatch.Add(folderBrowserDialog1.SelectedPath);
            }

            saveFolderWatch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r.StartRecording();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r.RecordEnd();
        }

        private string sendSound(string fileName)
        {

            string ret = "";
            try
            {

                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    string curlstring = @"$curl='" + pathToEXE + @"\curl'" + Environment.NewLine + @"& $curl -X POST -u  " + stCredentials + @" --header 'Content-Type: audio/ogg;codecs=opus' --header 'Transfer-Encoding: chunked' --data-binary '" + pathToEXE + @"OpusStore\" + fileName + @"' 'https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?continuous=true' --insecure";

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




        private void playsound(string filepath)
        {
            SoundPlayer simpleSound = new SoundPlayer(filepath);
            simpleSound.Play();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = sendSound("lol.opus");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playsound(pathToEXE + @"\WavStore\test.wav");

        }

        private void button7_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string lol = decopus("'" + pathToEXE + @"\Hello_World.opus'");
            playsound(lol);
        }

        private string decopus(string filename)
        {
            //decdoe

            string outputName = filename.Substring(0, filename.Length - 1) + ".wav'";

            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$opusdec=' " + pathToEXE + @" \opusdec'" + Environment.NewLine + " & $opusdec " + filename + " " + outputName);

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

            return outputName;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            encopus();
        }

        private void encopus()
        {
            //encode

            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$opusenc='" + pathToEXE + @"\opusenc'" + Environment.NewLine + @" & $opusenc --bitrate 64 '" + pathToEXE + @"\WavStore\lol.wav' '" + pathToEXE + @"\OpusStore\lol.opus'");

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = pathToEXE + @"\watch";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.cs";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {

        }



        private void button9_Click(object sender, EventArgs e)
        {




            string ret = "";
            try
            {

                using (PowerShell PowerShellInstance = PowerShell.Create())
                {

                    string data =
@"$data = @{
    text = "" " + txtSend.Text + @" ""
}";

                    string curlstring = @"$curl='" + pathToEXE + @"\curl'" + Environment.NewLine + data + Environment.NewLine +

                        @"& ConvertTo-Json $data  -Compress | &$curl -X POST -u " + tsCredentials + @" --header 'Content-Type: application/json' --header 'Accept: audio/ogg;codecs=opus' --data '@-'  --output '" + pathToEXE + @"\hello_world.opus' 'https://stream.watsonplatform.net/text-to-speech/api/v1/synthesize?voice=en-GB_KateVoice' --insecure";


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
            catch (Exception ex)
            {

                throw;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            watch();
        }
    }
}
