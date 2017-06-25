﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{

    [Serializable()]
    public class cTask : ISerializable
    {
        public string taskName;
        public string description;
        public DateTime created;
        public DateTime finsihed;
        public DateTime target;

        public int priority;
        public List<string> tags;
        public int percentComplete;

        public int typeOfTask;

        public enum tasktype
        {
            Goal=0,
            Action=1,
            Project=2
        };


        public cTask(SerializationInfo info, StreamingContext ctxt)
        {
            taskName = (string)info.GetValue("taskName", typeof(string));
            description = (string)info.GetValue("description", typeof(string));
            created = (DateTime)info.GetValue("filesEffected", typeof(DateTime));
            finsihed = (DateTime)info.GetValue("finsihed", typeof(DateTime));
            target = (DateTime)info.GetValue("target", typeof(DateTime));
            priority = (int)info.GetValue("priority", typeof(int));
            tags = (List<string>)info.GetValue("tags", typeof(List<string>));
            percentComplete = (int)info.GetValue("percentcomplete", typeof(int));
            typeOfTask = (int)info.GetValue("typeOfTask", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("taskName", taskName);
            info.AddValue("description", description);
            info.AddValue("created", created);
            info.AddValue("finsihed", finsihed);
            info.AddValue("target", target);
            info.AddValue("priority", priority);
            info.AddValue("tagas", tags);
            info.AddValue("percantagecomplete",percentComplete);
            info.AddValue("typeOfTask", typeOfTask);
        }

    }
}