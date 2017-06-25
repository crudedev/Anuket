using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{
    [Serializable()]
   public class  cNode : ISerializable
    {

        public List<cEvent> events;
        public List<cDescription> descriptions;
        public string name;
        public DateTime createdDate;

        public cNode(SerializationInfo info, StreamingContext ctxt)
        {
            events = (List<cEvent>)info.GetValue("events", typeof(List<cEvent>));
            descriptions = (List<cDescription>)info.GetValue("descriptions", typeof(List<cDescription>));
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
