using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{
    [Serializable()]
    public class cDescription : ISerializable
    {

        DateTime descriptionCreated;

        string label;

        int descriptionType;

        //0 text note
        //1 audio
        //2 attachmnet 

        public List<string> notes;
        public List<string> AudioPaths;
        public List<string> transcriptions;
        public List<string> attachments;

        public cDescription()
        {
            notes = new List<string>();
            AudioPaths = new List<string>();
            transcriptions = new List<string>();
            attachments = new List<string>();

        }

        public cDescription(SerializationInfo info, StreamingContext ctxt)
        {
            descriptionCreated = (DateTime)info.GetValue("descriptionCreated", typeof(DateTime));
            label = (string)info.GetValue("label", typeof(string));
            descriptionType = (int)info.GetValue("descriptionType", typeof(int));


            notes = (List<string>)info.GetValue("notes", typeof(List<string>));
            AudioPaths = (List<string>)info.GetValue("AudioPaths", typeof(List<string>));
            transcriptions = (List<string>)info.GetValue("transcriptions", typeof(List<string>));
            attachments = (List<string>)info.GetValue("attachments", typeof(List<string>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("descriptionCreated", descriptionCreated);
            info.AddValue("label", label);
            info.AddValue("descriptionType", descriptionType);
            info.AddValue("notes", notes);
            info.AddValue("AudioPaths", AudioPaths);
            info.AddValue("transcriptions", transcriptions);
            info.AddValue("attachments", attachments);

        }

    }
}

