using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Anuket
{

    [Serializable()]
    public class cTask : ISerializable
    {
        public string taskName;
        public string notes;
        public DateTime created;
        public DateTime finsihed;
        public DateTime target;
        public bool Show;

        public List<cDescription> descriptions;

        public int priority;
        public Dictionary<string,string> tags;
        public int percentComplete;

        public int typeOfTask;

        public Dictionary<string, int> ttype;

        public  List<cTask> parents;

        public List<cFileEvent> events;


        public enum tasktype
        {
            Goal=0,
            Action=1,
            Project=2
        };

        public override string ToString()
        {
            return taskName;
        }

        public cTask()
        {
            ttype = new Dictionary<string, int>();
            ttype.Add("Goal", 0);
            ttype.Add("ACtion", 1);
            ttype.Add("Project", 2);

            parents = new List<cTask>();
            events = new List<cFileEvent>();
            tags = new Dictionary<string, string>();
            descriptions = new List<cDescription>();
        }

        public cTask(SerializationInfo info, StreamingContext ctxt)
        {
            taskName = (string)info.GetValue("taskName", typeof(string));
            notes = (string)info.GetValue("notes", typeof(string));
            created = (DateTime)info.GetValue("created", typeof(DateTime));
            finsihed = (DateTime)info.GetValue("finsihed", typeof(DateTime));
            target = (DateTime)info.GetValue("target", typeof(DateTime));
            descriptions = (List<cDescription>)info.GetValue("descriptionsA", typeof(List<cDescription>));
            priority = (int)info.GetValue("priority", typeof(int));
            tags = (Dictionary<string,string>)info.GetValue("tags", typeof(Dictionary<string, string>));
            percentComplete = (int)info.GetValue("percentcomplete", typeof(int));
            typeOfTask = (int)info.GetValue("typeOfTask", typeof(int));
            Show = (bool)info.GetValue("show", typeof(bool));
            parents = (List<cTask>)info.GetValue("parents", typeof(List<cTask>));
            events = (List<cFileEvent>)info.GetValue("events", typeof(List<cFileEvent>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("taskName", taskName);
            info.AddValue("notes", notes);
            info.AddValue("created", created);
            info.AddValue("finsihed", finsihed);
            info.AddValue("target", target);
            info.AddValue("descriptionsA", descriptions);
            info.AddValue("priority", priority);
            info.AddValue("tags", tags);
            info.AddValue("percentcomplete", percentComplete);
            info.AddValue("typeOfTask", typeOfTask);
            info.AddValue("show", Show);
            info.AddValue("parents", parents);
            info.AddValue("events", events);
        }

    }
}
