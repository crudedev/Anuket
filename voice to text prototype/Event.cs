using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{

    [Serializable()]
    public class Event : ISerializable
    {
        public string fileName;
        public string locationPath;
        public Dictionary<string, string> filesEffected;

        public List<Description> descriptions;

        public DateTime datetimeOfEvent;

        public bool popupDisplayed = false;

        public Event(string FileName, string Location, Dictionary<string,String> FilesEffected)
        {
            fileName = FileName;
            locationPath = Location;
            filesEffected = FilesEffected;
            datetimeOfEvent = DateTime.Now;

            descriptions = new List<Description>();
                        
        }

        public Event()
        {

        }

        public void AddDescription(Description d)
        {
            descriptions.Add(d);
        }



        public Event(SerializationInfo info, StreamingContext ctxt)
        {
            fileName = (string)info.GetValue("fileName", typeof(string));
            locationPath = (string)info.GetValue("locationPath", typeof(string));
            filesEffected = (Dictionary<string,string>)info.GetValue("filesEffected", typeof(Dictionary<string, string>));


            descriptions = (List<Description>)info.GetValue("descriptions", typeof(List<Description>));
            datetimeOfEvent = (DateTime)info.GetValue("datetimeOfEvent", typeof(DateTime));
            popupDisplayed = (bool)info.GetValue("popupDisplayed", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("fileName", fileName);
            info.AddValue("locationPath", locationPath);
            info.AddValue("filesEffected", filesEffected);
            info.AddValue("descriptions", descriptions);
            info.AddValue("datetimeOfEvent", datetimeOfEvent);
            info.AddValue("popupDisplayed", popupDisplayed);

        }

    }
}
