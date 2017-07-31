using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Anuket
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
        public List<string> audioPaths;
        public List<string> transcriptions;
        public Dictionary<string,string> attachments;

        public cDescription()
        {
            notes = new List<string>();
            audioPaths = new List<string>();
            transcriptions = new List<string>();
            attachments = new Dictionary<string, string>();
            descriptionCreated = DateTime.Now;

        }

        public cDescription(SerializationInfo info, StreamingContext ctxt)
        {
            descriptionCreated = (DateTime)info.GetValue("descriptionCreatedB", typeof(DateTime));
            label = (string)info.GetValue("labelB", typeof(string));
            descriptionType = (int)info.GetValue("descriptionTypeB", typeof(int));
            notes = (List<string>)info.GetValue("notesB", typeof(List<string>));
            audioPaths = (List<string>)info.GetValue("AudioPathsB", typeof(List<string>));
            transcriptions = (List<string>)info.GetValue("transcriptionsB", typeof(List<string>));
            attachments = (Dictionary<string,string>)info.GetValue("attachmentsB", typeof(Dictionary<string, string>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("descriptionCreatedB", descriptionCreated);
            info.AddValue("labelB", label);
            info.AddValue("descriptionTypeB", descriptionType);
            info.AddValue("notesB", notes);
            info.AddValue("AudioPathsB", audioPaths);
            info.AddValue("transcriptionsB", transcriptions);
            info.AddValue("attachmentsB", attachments);
        }

        //public override string ToString()
        //{
        //    string name = "";

        //    name += descriptionCreated.ToString() + "  " + label;

        //    if (notes.Count > 0)
        //    {
        //        name += " Notes:" + notes.Count.ToString();
        //    }

        //    if(audioPaths.Count >0)
        //    {
        //        name += " Audio:" + audioPaths.Count.ToString();
        //    }

        //    if(attachments.Count >0)
        //    {
        //        name += " Attachd:" + attachments.Count.ToString();
        //    }

        //    return name;
        //}

    }
}

