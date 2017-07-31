using System;
using System.IO;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Media;
using System.Collections.Generic;

namespace Anuket
{
    public partial class frmSettings : Form
    {
        cRecorder r;

        private FolderBrowserDialog folderBrowserDialog1;

        public CoreData _c;

        frmPopupDescription _pd;

        int eventNumer = 0;

        string _selectedPath = "";

        public frmSettings(CoreData c)
        {
            _c = c;

            InitializeComponent();

            r = new cRecorder(0, c.pathToEXE + @"\WavStore\", Guid.NewGuid() + "test.wav");

            UpdateFolderWatch();
        }

        private void saveCoreData()
        {

            Serialiser s = new Serialiser();
            s.SerializeData(_c.pathToEXE + @"\DataStore\test.store", _c);

            UpdateFolderWatch();
        }

        private void UpdateFolderWatch()
        {

            lstWatchPath.Items.Clear();
            lstWatchExtension.Items.Clear();

            if (_c.fileExtensionsToWatch == null)
            {
                _c.fileExtensionsToWatch = new List<string>();
                _c.fileExtensionsToWatch.Add("*");
            }

            foreach (var path in _c.foldersToWatch)
            {
                if (path != "")
                {
                    List<string> toremove = new List<string>();
                    foreach (var extension in _c.fileExtensionsToWatch)
                    {
                        try
                        {
                            FileSystemWatcher watcher = new FileSystemWatcher();
                            watcher.Path = path;
                            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
                            watcher.Changed += new FileSystemEventHandler(OnChanged);
                            watcher.EnableRaisingEvents = true;
                        }
                        catch (Exception)
                        {

                        }


                    }

                    if (toremove != null)
                    {
                        foreach (var item in toremove)
                        {
                            _c.foldersToWatch.Remove(item);
                        }
                    }
                }
                lstWatchPath.Items.Add(path);
            }

            foreach (var extension in _c.fileExtensionsToWatch)
            {
                lstWatchExtension.Items.Add(extension);
            }
        }

        private void addFoldersToWatch()
        {

            folderBrowserDialog1 = new FolderBrowserDialog();
            //folderBrowserDialog1.ShowDialog();

            if (_c.foldersToWatch == null)
            {
                _c.foldersToWatch = new List<string>();
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string watchpath = folderBrowserDialog1.SelectedPath;

                _c.foldersToWatch.Add(watchpath);



                // here make a copy of everything 
                string adjpath = "";
                adjpath = watchpath.Replace(':', '-');
                adjpath = adjpath.Replace('\\', '-');

                string destPath = _c.pathToEXE + @"\DataStore\" + adjpath + @"\" + Guid.NewGuid();

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(watchpath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(watchpath, destPath));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(watchpath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(watchpath, destPath), true);


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

            return cSpeechManager.transcribe(_c, fileName);

        }

        private void playsound(string filepath)
        {
            SoundPlayer simpleSound = new SoundPlayer(filepath);
            simpleSound.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = sendSound(r.FileName.Substring(0, r.FileName.Length - 4) + ".opus");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playsound(r.FilePath + r.FileName);
            
        }

        private void button7_Click(object sender, EventArgs e)
        {


        }


        private string decopus(string filename)
        {
            //decdoe

            string outputName = filename.Substring(0, filename.Length - 1) + ".wav'";

            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$opusdec=' " + _c.pathToEXE + @" \opusdec'" + Environment.NewLine + " & $opusdec " + filename + " " + outputName);

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

            cRecorder.convert(_c, r.FileName.Substring(0,r.FileName.Length-4));

        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            CreateEvent(e.Name, e.FullPath, new Dictionary<string, string>());
        }

        private void button9_Click(object sender, EventArgs e)
        {

            string file = cSpeechManager.synthasizeVoice(_c, txtSend.Text);
            string synthTest = decopus("'" + _c.pathToEXE + @"\" + file + @".opus'");
            playsound(synthTest);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            addFoldersToWatch();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();

            if (_c.fileExtensionsToWatch == null)
            {
                _c.fileExtensionsToWatch = new List<string>();
            }

            _c.fileExtensionsToWatch.Add(txtWatchExtension.Text);

            saveExtensionWatch();
        }

        private void saveExtensionWatch()
        {

            string writeToFile = "";

            foreach (var item in _c.fileExtensionsToWatch)
            {
                writeToFile += item + ",";
            }

            File.WriteAllText(_c.pathToEXE + @"\extensionsToWatch.txt", writeToFile);

            UpdateFolderWatch();
        }

        private void CreateEvent(string filename, string Location, Dictionary<string, string> asd)
        {
            cEvent e = new cEvent(filename, Location, asd);
            if (_c.events == null)
            {
                _c.events = new List<cEvent>();
            }
            _c.events.Add(e);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_c.events != null)
            {
                for (int i = 0; i < _c.events.Count; i++)
                {

                    if (!_c.events[i].popupDisplayed)
                    {
                        if (_pd != null)
                        {
                            _pd.Close();
                            _pd.Dispose();
                            _pd = null;
                        }

                        eventNumer++;
                        _pd = new frmPopupDescription(_c, eventNumer, _c.events[i]);
                        _pd.Show();

                        _c.events[i].popupDisplayed = true;
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmEventList ex = new frmEventList(_c);
            ex.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            _c.events = new List<cEvent>();
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
                d.audioPaths = new List<string>();
                d.audioPaths.Add(_c.pathToEXE + Guid.NewGuid().ToString());
                d.notes = new List<string>();
                d.notes.Add("this is a note + " + Guid.NewGuid().ToString());

                _c.events.Add(ev);
            }

            _c.tasks = new List<cTask>();

            for (int i = 0; i < 10; i++)
            {
                cTask tt = new cTask();
                tt.created = DateTime.Now - TimeSpan.FromSeconds(r.NextDouble() * 500);
                tt.descriptions = new List<cDescription>();
                tt.notes = "asdf;lkjhasdflkjasdflkjasdlkfjasldkjl;askjdfl;kjasdfkljhasdklfhaskdlfhkljfhsgasljhd";
                tt.percentComplete = r.Next(99);
                tt.priority = r.Next(99);
                tt.target = DateTime.Now + TimeSpan.FromHours(r.NextDouble() * 500);
                tt.taskName = "asd;lfjasdl;kjal;skdf" + r.Next(10000).ToString();
                tt.typeOfTask = Convert.ToInt32(cTask.tasktype.Goal);

                _c.tasks.Add(tt);
            }


        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmManageTasks mt = new frmManageTasks(_c);
            mt.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            frmTask ct = new frmTask(_c, new cTask(), false);
            ct.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            frmTaskOverview f = new frmTaskOverview(_c);
            f.Show();

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void lstWatchPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWatchPath.SelectedItem != null)
            {
                _selectedPath = lstWatchPath.SelectedItem.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (_selectedPath != "")
            {
                try
                {
                    _c.foldersToWatch.Remove(_selectedPath);
                    UpdateFolderWatch();
                }
                catch (Exception)
                {
                    MessageBox.Show("could not find path");
                    throw;
                }
            }
        }
    }
}
