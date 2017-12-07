using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;


public class XML_Save{
    private const string ADDRESS = "savedData";
    protected XmlSerializer serialize = new XmlSerializer(typeof(Unlocked));
    public XML_Save (Unlocked u)
    {
        TextWriter text = new StringWriter();
        serialize.Serialize(text, u);
        Debug.Log(text);
        PlayerPrefs.SetString(ADDRESS, text.ToString());
        PlayerPrefs.Save();
    }
}
