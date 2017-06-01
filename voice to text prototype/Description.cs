using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{
    public class Description
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

        public Description()
        {
            notes = new List<string>();
            AudioPaths = new List<string>();
            transcriptions = new List<string>();
            attachments = new List<string>();

        }


    }
}
