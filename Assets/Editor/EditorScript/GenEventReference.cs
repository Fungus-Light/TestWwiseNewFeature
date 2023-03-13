using UnityEditor;
using UnityEngine;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Text;

public class GenEventReference{
    
    [MenuItem("MyTools/GenEventIds")]
    public static void GenEventParser(){

        var refs = new WwiseEventRefs();

        refs.eventIds = new System.Collections.Generic.Dictionary<string, uint>();
        string target = "Assets/Script/Gened/EventsAll.cs";
        string template = File.ReadAllText("Assets/Editor/EditorScript/Templates/WwiseEventIdRef.template",encoding:Encoding.UTF8);
        string infoPath = Path.Combine(Application.dataPath,"../TestWwiseNewFeature_WwiseProject/GeneratedSoundBanks/Windows/SoundbanksInfo.xml");
        XElement info = XElement.Load(infoPath);
        if(!(info is null)){
            var events = info.Descendants("Event");
            foreach(XElement el in events){
                string name = (string)el.Attribute("Name");
                uint id = (uint)el.Attribute("Id");
                Debug.Log(name+"   "+id);
                if(!refs.eventIds.ContainsKey(name)){
                    refs.eventIds.Add(name,id);
                    Debug.Log(name+"   "+id);
                }
            }

            var content = "";
            foreach(var el in refs.eventIds){
                content += $"\tpublic const uint {el.Key} = {el.Value};\n";
            }

            template = template.Replace("${content}",content);

            File.WriteAllText(target,template,encoding:Encoding.UTF8);

            Debug.Log("Gened To "+target);
        }
    }

}

