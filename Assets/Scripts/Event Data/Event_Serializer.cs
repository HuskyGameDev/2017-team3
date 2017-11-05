using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class Event_Serializer : MonoBehaviour {
    public void Main(string[] args)
    {
           
        Event e = new Event(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, "", 0, null, "", false, false);
        XmlSerializer x = new XmlSerializer(e.GetType());
        x.Serialize(stream, e);
    }
}
