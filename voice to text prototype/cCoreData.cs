using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{

    [Serializable()]
    public class CoreData : ISerializable
    {
        public Dictionary<Guid, cDescription> descriptions;
        public Dictionary<Guid, cEvent> events;
        public Dictionary<Guid, cNode> nodes;
        public Dictionary<Guid, cTask> tasks;

        public List<string> foldersToWatch;
        public List<string> fileExtensionsToWatch;
        public List<string> exclusionList;

        public Dictionary<string, string> tags;

        public CoreData()
        {
            descriptions = new Dictionary<Guid, cDescription>();
            events = new Dictionary<Guid, cEvent>();
            nodes = new Dictionary<Guid, cNode>();
            tasks = new Dictionary<Guid, cTask>();
            foldersToWatch = new List<string>();
            fileExtensionsToWatch = new List<string>();
            exclusionList = new List<string>();
            tags = new Dictionary<string, string>();
        }

        public CoreData(SerializationInfo info, StreamingContext ctxt)
        {
            descriptions = (Dictionary<Guid, cDescription>)info.GetValue("descriptions", typeof(Dictionary<Guid, cDescription>));
            events = (Dictionary<Guid, cEvent>)info.GetValue("event", typeof(Dictionary<Guid, cEvent>));
            nodes = (Dictionary<Guid, cNode>)info.GetValue("node", typeof(Dictionary<Guid, cNode>));
            foldersToWatch = (List<string>)info.GetValue("folderstowatch", typeof(List<string>));
            fileExtensionsToWatch = (List<string>)info.GetValue("fileExtensionsToWatch", typeof(List<string>));
            exclusionList = (List<string>)info.GetValue("exclusionList", typeof(List<string>));
            tasks = (Dictionary<Guid, cTask>)info.GetValue("tasks", typeof(Dictionary<Guid, cTask>));
            tags = (Dictionary<string, string>)info.GetValue("tags", typeof(Dictionary<string, string>));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("descriptions", descriptions);
            info.AddValue("event", events);
            info.AddValue("node", nodes);
            info.AddValue("folderstowatch", foldersToWatch);
            info.AddValue("fileExtensionsToWatch", fileExtensionsToWatch);
            info.AddValue("exclusionList", exclusionList);
            info.AddValue("tasks", tasks);
            info.AddValue("tags", tags);
        }
    }
}
