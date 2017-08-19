using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Anuket
{

    [Serializable()]
    public class cFileEvent : ISerializable
    {
        public string fileName;
        public string locationPath;
        public Dictionary<string, string> filesEffected;

        public List<cDescription> descriptions;

        public DateTime datetimeOfEvent;

        public bool popupDisplayed = false;
        public bool described = false;
        public bool assaignedToTask = false;

        public Guid ID;

        public cFileEvent(string FileName, string Location, Dictionary<string,String> FilesEffected)
        {
            fileName = FileName;
            locationPath = Location;
            filesEffected = FilesEffected;
            datetimeOfEvent = DateTime.Now;

            descriptions = new List<cDescription>();

            ID = new Guid();  



        }

        public cFileEvent()
        {
            ID = new Guid();
        }

        public void AddDescription(cDescription d)
        {
            descriptions.Add(d);
        }

        public cFileEvent(SerializationInfo info, StreamingContext ctxt)
        {
            fileName = (string)info.GetValue("fileName", typeof(string));
            locationPath = (string)info.GetValue("locationPath", typeof(string));
            filesEffected = (Dictionary<string, string>)info.GetValue("filesEffected", typeof(Dictionary<string, string>));
            descriptions = (List<cDescription>)info.GetValue("descriptions", typeof(List<cDescription>));
            datetimeOfEvent = (DateTime)info.GetValue("datetimeOfEvent", typeof(DateTime));
            popupDisplayed = (bool)info.GetValue("popupDisplayed", typeof(bool));
            assaignedToTask = (bool)info.GetValue("assaignedToTask", typeof(bool));
            described = (bool)info.GetValue("described", typeof(bool));

            ID = (Guid)info.GetValue("guid", typeof(Guid));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("fileName", fileName);
            info.AddValue("locationPath", locationPath);
            info.AddValue("filesEffected", filesEffected);
            info.AddValue("descriptions", descriptions);
            info.AddValue("datetimeOfEvent", datetimeOfEvent);
            info.AddValue("popupDisplayed", popupDisplayed);
            info.AddValue("guid", ID);
            info.AddValue("assaignedToTask", assaignedToTask);
            info.AddValue("described", described);

        }

    }
}
