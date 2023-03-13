using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class WwiseManager : MonoBehaviour
{
    private static WwiseManager _instance;
    public static WwiseManager Instance{
        get{
            return _instance;
        }
    }
    public string BankName = "bpm128";
    private bool _Ready = false;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Awake(){
        _instance = this;
    }

    public void Init(){
        uint initBankId;
        uint bankId;
        AkSoundEngine.LoadBank("Init",out initBankId);
        AkSoundEngine.LoadBank(BankName,out bankId);

        AkSoundEngine.RegisterSpatialAudioListener(this.gameObject);
        Debug.Log("Bank Id is "+bankId);
        _Ready = true;
    }

    public static bool IsReady(){
        if(_instance is null){
            return false;
        }
        return _instance._Ready;
    }

    public static void PostEvent(uint eventId){
        //uint eventId = AkSoundEngine.get
        AkSoundEngine.PostEvent(eventId, WwiseManager.Instance.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
