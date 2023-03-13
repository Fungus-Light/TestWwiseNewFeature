using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestUI : MonoBehaviour
{

    public Button start,stop;
    public BasicBeat ticker;
    public TMP_InputField bpm;

    public TMP_Text info;
    // Start is called before the first frame update
    void Start()
    {
        if(!(start is null)){
            start.onClick.RemoveAllListeners();
            start.onClick.AddListener(()=>{
                ticker.BPM = int.Parse(bpm.text);
                ticker.Reset();
                ticker.TickEnable = true;
            });
        }

        if(!(stop is null)){
            stop.onClick.RemoveAllListeners();
            stop.onClick.AddListener(()=>{
                ticker.TickEnable = false;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
