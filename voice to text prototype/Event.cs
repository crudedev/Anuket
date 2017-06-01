using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{
    public class Event
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

    }
}
