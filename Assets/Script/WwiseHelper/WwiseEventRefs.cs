using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WwiseEventRefs{
    public Dictionary<string,uint> eventIds;

    public static string StringFy_WwiseEventRefs(WwiseEventRefs data){
        return JsonUtility.ToJson(data);
    }

    public static WwiseEventRefs Parse_WwiseEventRefs(string data){
        return JsonUtility.FromJson<WwiseEventRefs>(data);
    }
}