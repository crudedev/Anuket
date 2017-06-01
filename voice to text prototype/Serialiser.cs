using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{

        class Serialiser
        {
            public void SerializeUniverse(string filename, Serialised s)
            {
                Stream stream = File.Open(filename, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, s);
                stream.Close();
            }

            public Serialised DeSerializeUniverse(string filename)
            {
                Serialised objectToSerialize;
                Stream stream = File.Open(filename, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (Serialised)bFormatter.Deserialize(stream);
                stream.Close();
                return objectToSerialize;
            }

            public Serialiser()
            {

            }
        
    }
}
