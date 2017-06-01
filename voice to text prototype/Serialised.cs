using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{
    [Serializable()]
    class Serialised : ISerializable
    {

        public Serialisee s;

        public Serialised(SerializationInfo info, StreamingContext ctxt)
        {
            this.s = (Serialisee)info.GetValue("c", typeof(Serialisee));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("s", this.s);
        }

        public Serialised()
        {

        }

        public Serialised(Serialisee ser)
        {
            s = ser;
        }

    }

}
