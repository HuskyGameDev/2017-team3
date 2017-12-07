using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class XML_Load{
    private const string ADDRESS = "savedData";
    protected XmlSerializer serialize = new XmlSerializer(typeof(Unlocked));

    public XML_Load(ref Unlocked u)
    {
        string s = PlayerPrefs.GetString(ADDRESS, "FIRST!");
        if (!s.Equals("FIRST!")) { 

            StringReader status = new StringReader(s);
            u = (Unlocked)serialize.Deserialize(status);
        }
        else
        {
            u = new Unlocked();
        }
    }
}
