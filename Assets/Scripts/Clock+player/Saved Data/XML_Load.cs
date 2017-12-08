using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class XML_Load{
    private const string ADDRESS = "savedData";
    protected XmlSerializer serialize = new XmlSerializer(typeof(Unlocked));
    //ref passes a parameter by reference instead of by value
    public XML_Load(ref Unlocked u)
    {
        //see if the value exists, if not, "FIRST!" is returend
        string s = PlayerPrefs.GetString(ADDRESS, "FIRST!");
        if (!s.Equals("FIRST!")) { 
            //convert s into a String Reader, which is in an XML format
            StringReader status = new StringReader(s);
            //convert the serialized data into the unlocked class
            u = (Unlocked)serialize.Deserialize(status);
        }
        else
        {
            //there is no unlocked Player pref, instantiate a new one
            u = new Unlocked();
        }
    }
}
