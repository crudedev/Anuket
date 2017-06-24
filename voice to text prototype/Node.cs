using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{
    [Serializable()]
   public class  Node : ISerializable
    {

        public List<Event> events;
        public List<Description> descriptions;
        public string name;
        public DateTime createdDate;

        public Node(SerializationInfo info, StreamingContext ctxt)
        {
            events = (List<Event>)info.GetValue("events", typeof(List<Event>));
            descriptions = (List<Description>)info.GetValue("descriptions", typeof(List<Description>));
            name = (string)info.GetValue("name", typeof(string));
            createdDate = (DateTime)info.GetValue("createdDate", typeof(DateTime));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("events", events);
            info.AddValue("descriptions", descriptions);
            info.AddValue("name", name);
            info.AddValue("createdDAte", createdDate);


        }

    }

}
