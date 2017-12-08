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
        //get a text/string writer
        TextWriter text = new StringWriter();
        //seralize Unlocked u into TextWiter text
        serialize.Serialize(text, u);
        //send it to log just to be sure
        Debug.Log(text);
        //save it into player prefs
        PlayerPrefs.SetString(ADDRESS, text.ToString());
        //save player prefs
        PlayerPrefs.Save();
    }
}
