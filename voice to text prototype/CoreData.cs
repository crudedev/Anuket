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
        public List<Description> descriptions;
        public List<Event> events;
        public List<Node> nodes;
        public List<Task> tasks;

        public List<string> foldersToWatch;
        public List<string> fileExtensionsToWatch;
        public List<string> exclusionList;

        public Dictionary<string, string> tags;

        public CoreData()
        {

        }

        public CoreData(SerializationInfo info, StreamingContext ctxt)
        {
            descriptions = (List<Description>)info.GetValue("descriptions", typeof(List<Description>));
            events = (List<Event>)info.GetValue("event", typeof(List<Event>));
            nodes = (List<Node>)info.GetValue("node", typeof(List<Node>));
            foldersToWatch = (List<string>)info.GetValue("folderstowatch", typeof(List<string>));
            fileExtensionsToWatch = (List<string>)info.GetValue("fileExtensionsToWatch", typeof(List<string>));
            exclusionList = (List<string>)info.GetValue("exclusionList", typeof(List<string>));
            tasks = (List<Task>)info.GetValue("tasks", typeof(List<Task>));
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
