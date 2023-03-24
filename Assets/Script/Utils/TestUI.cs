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

    uint id = 0;

    public TMP_Text info;
    public TMP_Text tickInfo;

    public TMP_Text pressCheck;

    // Start is called before the first frame update
    void Start()
    {
        bpm.text = "128";
        if(!(start is null)){
            start.onClick.RemoveAllListeners();
            start.onClick.AddListener(()=>{
                ticker.BPM = int.Parse(bpm.text);
                ticker.Reset();
                ticker.TickEnable = true;
                id = WwiseManager.PostEvent(WWISE_EVENTS.bpm128,()=>{
                    Debug.Log(">>>> Sync:"+ ticker.GetTickTime());
                    tickInfo.text = "Wwise/Unity 延迟(s) :"+ticker.GetTickTime();
                    if(ticker.GetTickTime() > 0.01){
                        ticker.ForceSync();
                    }

                });
                ticker.tickEvent.RemoveAllListeners();
                ticker.tickEvent.AddListener(()=>{
                    info.transform.parent.GetComponent<Animation>().Play("SimpleJump");
                });
            });
        }

        if(!(stop is null)){
            stop.onClick.RemoveAllListeners();
            stop.onClick.AddListener(()=>{
                ticker.TickEnable = false;
                //if(id != 0){
                    AkSoundEngine.StopAll();
                //}
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            pressCheck.text = "判定结果是：" + ticker.GetTickTime();
        }
    }
}
