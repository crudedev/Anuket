using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Anuket
{

    [Serializable()]
    public class CoreData : ISerializable
    {
        public List<cDescription> descriptions;
        public List<cFileEvent> events;
        public List<cTask> tasks;

        public List<string> foldersToWatch;
        public List<string> fileExtensionsToWatch;
        public List<string> exclusionList;

        public Dictionary<string, string> tags;

        public readonly string stCredentials;
        public readonly string tsCredentials;

        public string pathToEXE;

        public CoreData()
        {
            descriptions = new List<cDescription>();
            events = new List<cFileEvent>();
            tasks = new List<cTask>();
            foldersToWatch = new List<string>();
            fileExtensionsToWatch = new List<string>();
            exclusionList = new List<string>();
            tags = new Dictionary<string, string>();


            pathToEXE = Directory.GetCurrentDirectory();

            stCredentials = File.ReadAllText(pathToEXE + @"\stcredentials.txt");
            tsCredentials = File.ReadAllText(pathToEXE + @"\tscredentials.txt");


        }

        public CoreData(SerializationInfo info, StreamingContext ctxt)
        {
            descriptions = (List<cDescription>)info.GetValue("descriptions", typeof(List<cDescription>));
            events = (List<cFileEvent>)info.GetValue("event", typeof(List<cFileEvent>));
            foldersToWatch = (List<string>)info.GetValue("folderstowatch", typeof(List<string>));
            fileExtensionsToWatch = (List<string>)info.GetValue("fileExtensionsToWatch", typeof(List<string>));
            exclusionList = (List<string>)info.GetValue("exclusionList", typeof(List<string>));
            tasks = (List<cTask>)info.GetValue("tasks", typeof(List<cTask>));
            tags = (Dictionary<string, string>)info.GetValue("tags", typeof(Dictionary<string, string>));
            pathToEXE = Directory.GetCurrentDirectory();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("descriptions", descriptions);
            info.AddValue("event", events);
            info.AddValue("folderstowatch", foldersToWatch);
            info.AddValue("fileExtensionsToWatch", fileExtensionsToWatch);
            info.AddValue("exclusionList", exclusionList);
            info.AddValue("tasks", tasks);
            info.AddValue("tags", tags);
            pathToEXE = Directory.GetCurrentDirectory();
        }
    }
}
