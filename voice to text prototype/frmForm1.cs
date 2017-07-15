using System;
using System.IO;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Media;
using System.Collections.Generic;

namespace voice_to_text_prototype
{
    public partial class frmForm1 : Form
    {
        cRecorder r;

        readonly string stCredentials;
        readonly string tsCredentials;

        readonly string pathToEXE;


        private FolderBrowserDialog folderBrowserDialog1;

        List<frmDescribeEvent> popupEvents;

        public CoreData c = new CoreData();

        frmPopupDescription _pd;

        int eventNumer = 0;

        public frmForm1()
        {
            InitializeComponent();
            pathToEXE = Directory.GetCurrentDirectory();

            r = new cRecorder(0, pathToEXE + @"\WavStore\", Guid.NewGuid() + "test.wav");

            stCredentials = File.ReadAllText(pathToEXE + @"\stcredentials.txt");
            tsCredentials = File.ReadAllText(pathToEXE + @"\tscredentials.txt");

            loadCoreData();

            popupEvents = new List<frmDescribeEvent>();
            c.events = new List<cEvent>();

            try
            {
                string[] folderarray = File.ReadAllText(pathToEXE + @"\foldersToWatch.txt").Split(',');

                if (c.foldersToWatch == null)
                {
                    c.foldersToWatch = new List<string>();
                }


                foreach (var item in folderarray)
                {
                    if (item != "")
                    {
                        if (!c.foldersToWatch.Contains(item))
                            c.foldersToWatch.Add(item);
                    }

                }
                if (c.foldersToWatch == null)
                {
                    throw new Exception();
                }

                try
                {

                    string[] extensionArray = File.ReadAllText(pathToEXE + @"\extensionsToWatch.txt").Split(',');

                    if (c.fileExtensionsToWatch == null)
                    {
                        c.fileExtensionsToWatch = new List<string>();
                    }

                    foreach (var item in extensionArray)
                    {
                        if (!c.fileExtensionsToWatch.Contains(item))
                            c.fileExtensionsToWatch.Add(item);
                    }

                    if (c.fileExtensionsToWatch.Count == 0)
                    {
                        c.fileExtensionsToWatch.Add("*");
                    }

                }
                catch (Exception ex)
                {
                    c.fileExtensionsToWatch = new List<string>();

                    c.fileExtensionsToWatch.Add("*");
                }

                UpdateFolderWatch();
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

            timer1.Enabled = true;

        }

        internal void UpdateTasks()
        {
            if (c.tasks == null)
            {
                c.tasks = new  List<cTask>();
            }
            lstTask.Items.Clear();
            foreach (var item in c.tasks)
            {
                lstTask.Items.Add(item.taskName);
            }
        }

        private void saveCoreData()
        {

            Serialiser s = new Serialiser();
            s.SerializeData(pathToEXE + @"\DataStore\test.store", c);

            UpdateFolderWatch();
        }

        private CoreData loadCoreData()
        {
            CoreData loaded = new CoreData();
            Serialiser loader = new Serialiser();
            try
            {
                loaded = loader.DeSerializeData(pathToEXE + @"\DataStore\test.store");
            }
            catch (Exception)
            {
                MessageBox.Show("Data Not Loaded");
            }

            return loaded;
        }

        private void UpdateFolderWatch()
        {

            lstWatchPath.Items.Clear();
            lstWatchExtension.Items.Clear();

            if (c.fileExtensionsToWatch == null)
            {
                c.fileExtensionsToWatch = new List<string>();
                c.fileExtensionsToWatch.Add("*");
            }

            foreach (var path in c.foldersToWatch)
            {
                if (path != "")
                {
                    foreach (var extension in c.fileExtensionsToWatch)
                    {

                        FileSystemWatcher watcher = new FileSystemWatcher();
                        watcher.Path = path;
                        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
                        watcher.Changed += new FileSystemEventHandler(OnChanged);
                        watcher.EnableRaisingEvents = true;

                    }
                }
                lstWatchPath.Items.Add(path);
            }

            foreach (var extension in c.fileExtensionsToWatch)
            {
                lstWatchExtension.Items.Add(extension);
            }
        }

        private void addFoldersToWatch()
        {

            folderBrowserDialog1 = new FolderBrowserDialog();
            //folderBrowserDialog1.ShowDialog();

            if (c.foldersToWatch == null)
            {
                c.foldersToWatch = new List<string>();
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                c.foldersToWatch.Add(folderBrowserDialog1.SelectedPath);
            }

            saveCoreData();
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
                    string curlstring = @"$curl='" + pathToEXE + @"\curl'" + Environment.NewLine + @"& $curl -X POST -u  " + stCredentials + @" --header 'Content-Type: audio/ogg;codecs=opus' --header 'Transfer-Encoding: chunked' --data-binary '@" + pathToEXE + @"\OpusStore\" + fileName + @"' 'https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?continuous=true' --insecure";

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
            playsound(pathToEXE + @"\WavStore\lol.wav");

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

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            CreateEvent(e.Name, e.FullPath, new Dictionary<string, string>());
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
            addFoldersToWatch();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();

            if (c.fileExtensionsToWatch == null)
            {
                c.fileExtensionsToWatch = new List<string>();
            }

            c.fileExtensionsToWatch.Add(txtWatchExtension.Text);

            saveExtensionWatch();
        }

        private void saveExtensionWatch()
        {

            string writeToFile = "";

            foreach (var item in c.fileExtensionsToWatch)
            {
                writeToFile += item + ",";
            }

            File.WriteAllText(pathToEXE + @"\extensionsToWatch.txt", writeToFile);

            UpdateFolderWatch();
        }

        private void CreateEvent(string filename, string Location, Dictionary<string, string> asd)
        {
            cEvent e = new cEvent(filename, Location, asd);
            if (c.events == null)
            {
                c.events = new List<cEvent>();
            }
            c.events.Add(e);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (c.events != null)
            {
                for (int i = 0; i < c.events.Count; i++)
                {

                    if (!c.events[i].popupDisplayed)
                    {
                        if(_pd!=null)
                        {
                        _pd.Close();
                        _pd.Dispose();
                        _pd = null;
                        }
 
                        eventNumer++;
                        _pd = new frmPopupDescription(this, eventNumer, c.events[i]);
                        _pd.Show(); 

                        c.events[i].popupDisplayed = true;
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmEventList ex = new frmEventList(this);
            ex.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            c.events = new List<cEvent>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {

                cEvent ev = new cEvent();
                ev.datetimeOfEvent = DateTime.Now.AddMinutes(r.Next(10));
                ev.datetimeOfEvent = ev.datetimeOfEvent.AddSeconds(r.Next(50));
                ev.fileName = Guid.NewGuid().ToString();
                ev.popupDisplayed = true;
                ev.descriptions = new List<cDescription>();

                cDescription d = new cDescription();
                d.AudioPaths = new List<string>();
                d.AudioPaths.Add(pathToEXE + Guid.NewGuid().ToString());
                d.notes = new List<string>();
                d.notes.Add("this is a note + " + Guid.NewGuid().ToString());

                c.events.Add(ev);
            }


        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmManageTasks mt = new frmManageTasks(this);
            mt.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            frmTask ct = new frmTask(this, new cTask(), false);
            ct.Show();
        }
    }
}
