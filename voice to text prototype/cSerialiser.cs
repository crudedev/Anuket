using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Anuket
{

    class Serialiser
    {
        public void SerializeData(string filename, CoreData s)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, s);
            stream.Close();
        }

        public CoreData DeSerializeData(string filename)
        {
            CoreData objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (CoreData)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }

        public Serialiser()
        {

        }

        public CoreData c;

        public void Serialised(SerializationInfo info, StreamingContext ctxt)
        {
            this.c = (CoreData)info.GetValue("c", typeof(CoreData));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("c", this.c);
        }


        public void Serialised(CoreData ser)
        {
            c = ser;
        }

    }

}

