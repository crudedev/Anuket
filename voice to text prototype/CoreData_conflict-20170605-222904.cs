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

        public CoreData()
        {

        }

        public CoreData(SerializationInfo info, StreamingContext ctxt)
        {
            descriptions = (List<Description>)info.GetValue("descriptions", typeof(List<Description>));
            events = (List<Event>)info.GetValue("event", typeof(List<Event>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("descriptions", descriptions);
            info.AddValue("event", events);
        }
    }
}
