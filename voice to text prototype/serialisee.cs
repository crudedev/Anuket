using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{

    [Serializable()]
    public class Serialisee : ISerializable
    {
        public List<Description> descriptions;

        public Serialisee()
        {

        }

        public Serialisee(SerializationInfo info, StreamingContext ctxt)
        {
            descriptions = (List<Description>)info.GetValue("descriptions", typeof(List<Description>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("descriptions", descriptions);
        }
    }
}
