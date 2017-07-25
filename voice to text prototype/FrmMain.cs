using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voice_to_text_prototype
{
    public partial class FrmMain : Form
    {
        public CoreData c = new CoreData();

        int eventNumer = 0;

        frmPopupDescription _pd;

        Timer checkEvent = new Timer();

        int saveTimer = 0;

        public FrmMain()
        {
            InitializeComponent();

            c = loadCoreData();

            initialiseFolderWatch();

            checkEvent.Tick += CheckEvent_Tick;
            checkEvent.Interval = 10000;
            checkEvent.Enabled = true;

        }

        private void CheckEvent_Tick(object sender, EventArgs e)
        {
            if (c.events != null)
            {
                for (int i = 0; i < c.events.Count; i++)
                {

                    if (!c.events[i].popupDisplayed)
                    {
                        if (_pd != null)
                        {
                            _pd.Close();
                            _pd.Dispose();
                            _pd = null;
                        }

                        eventNumer++;
                        _pd = new frmPopupDescription(c, eventNumer, c.events[i]);
                        _pd.Show();

                        c.events[i].popupDisplayed = true;
                    }
                }
            }

            saveTimer++;

            if (saveTimer > 100)
            {
                saveData();
            }
        }

        private void saveData()
        {
            Serialiser s = new Serialiser();
            s.SerializeData(c.pathToEXE + @"\DataStore\test.store", c);
        }

        private CoreData loadCoreData()
        {
            CoreData loaded = new CoreData();
            Serialiser loader = new Serialiser();
            try
            {
                loaded = loader.DeSerializeData(c.pathToEXE + @"\DataStore\test.store");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Not Loaded");
            }

            return loaded;
        }


        private void initialiseFolderWatch()
        {
            try
            {
                string[] folderarray = File.ReadAllText(c.pathToEXE + @"\foldersToWatch.txt").Split(',');

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

                    string[] extensionArray = File.ReadAllText(c.pathToEXE + @"\extensionsToWatch.txt").Split(',');

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

            }

        }

        private void UpdateFolderWatch()
        {

            if (c.fileExtensionsToWatch == null)
            {
                c.fileExtensionsToWatch = new List<string>();
                c.fileExtensionsToWatch.Add("*");
            }

            foreach (var path in c.foldersToWatch)
            {
                if (path != "")
                {
                    List<string> toremove = new List<string>();
                    foreach (var extension in c.fileExtensionsToWatch)
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
                            c.foldersToWatch.Remove(item);
                        }
                    }
                }

            }

        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            cEvent ev = new cEvent(e.Name, e.FullPath, new Dictionary<string, string>());
            if (c.events == null)
            {
                c.events = new List<cEvent>();
            }
            c.events.Add(ev);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings fs = new frmSettings(c);
            fs.Show();
        }

        private void btnTaskOverview_Click(object sender, EventArgs e)
        {
            frmTaskOverview fto = new frmTaskOverview(c);
            fto.Show();
        }

        private void btnManageTasks_Click(object sender, EventArgs e)
        {
            frmManageTasks fmt = new frmManageTasks(c);
            fmt.Show();
        }

        private void btnShowEventlist_Click(object sender, EventArgs e)
        {
            frmEventList fel = new frmEventList(c);
            fel.Show();
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            frmTask ft = new frmTask(c, new cTask(), false);
            ft.Show();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            saveData();
        }
    }
}
