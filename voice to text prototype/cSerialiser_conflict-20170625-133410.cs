using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{

    class cSerialiser
    {
        public void SerializeData(string filename, cCoreData s)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, s);
            stream.Close();
        }

        public cCoreData DeSerializeData(string filename)
        {
            cCoreData objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (cCoreData)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }

        public cSerialiser()
        {

        }

        public cCoreData c;

        public void Serialised(SerializationInfo info, StreamingContext ctxt)
        {
            this.c = (cCoreData)info.GetValue("c", typeof(cCoreData));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("c", this.c);
        }


        public void Serialised(cCoreData ser)
        {
            c = ser;
        }

    }

}

