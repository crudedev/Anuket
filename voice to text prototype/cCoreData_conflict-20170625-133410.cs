using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{

    [Serializable()]
    public class cCoreData : ISerializable
    {
        public List<cDescription> descriptions;
        public List<cEvent> events;
        public List<cNode> nodes;
        public List<cTask> tasks;

        public List<string> foldersToWatch;
        public List<string> fileExtensionsToWatch;
        public List<string> exclusionList;

        public Dictionary<string, string> tags;

        public cCoreData()
        {

        }

        public cCoreData(SerializationInfo info, StreamingContext ctxt)
        {
            descriptions = (List<cDescription>)info.GetValue("descriptions", typeof(List<cDescription>));
            events = (List<cEvent>)info.GetValue("event", typeof(List<cEvent>));
            nodes = (List<cNode>)info.GetValue("node", typeof(List<cNode>));
            foldersToWatch = (List<string>)info.GetValue("folderstowatch", typeof(List<string>));
            fileExtensionsToWatch = (List<string>)info.GetValue("fileExtensionsToWatch", typeof(List<string>));
            exclusionList = (List<string>)info.GetValue("exclusionList", typeof(List<string>));
            tasks = (List<cTask>)info.GetValue("tasks", typeof(List<cTask>));
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
