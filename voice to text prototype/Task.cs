using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{

    [Serializable()]
    public class Task : ISerializable
    {
        public string taskName;
        public string description;
        public DateTime created;
        public DateTime finsihed;
        public DateTime target;



        public Task(SerializationInfo info, StreamingContext ctxt)
        {
            taskName = (string)info.GetValue("taskName", typeof(string));
            description = (string)info.GetValue("description", typeof(string));
            created = (DateTime)info.GetValue("filesEffected", typeof(DateTime));
            finsihed = (DateTime)info.GetValue("finsihed", typeof(DateTime));
            target = (DateTime)info.GetValue("target", typeof(DateTime));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("taskName", taskName);
            info.AddValue("description", description);
            info.AddValue("created", created);
            info.AddValue("finsihed", finsihed);
            info.AddValue("target", target);

        }

    }
}
