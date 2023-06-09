using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicBeat : MonoBehaviour
{

    public int BPM = 128;

    public int GridPerBeat = 8;

    private float tickInterval = GameConst.SEC_PER_MIN / (GameConst.DEFAULT_BPM );

    public int tickCount = 0;
    public int gridCount = 0;

    private float tick = 0;
    private int gridTick = 0;

    public bool TickEnable = false;

    public UnityEvent tickEvent = new UnityEvent();
    public CheckLine checkLine;
    
    void Start()
    {
        Application.targetFrameRate = 60;
        Reset();
    }

    public void Reset(){
        tickInterval = GameConst.SEC_PER_MIN / (BPM);
        tickCount = 0;
        tick = 0;
        gridTick = 9;
        gridCount = 0;
    }

    void Tick()
    {
        if (!TickEnable)
        {
            return;
        }
        tick = tick + Time.deltaTime;

        checkLine.tick = tick;
        checkLine.tickInterval = tickInterval;

        if (tick >= tickInterval)
        {
            tick = 0;
            tickCount++;
            tickEvent?.Invoke();
            if(WwiseManager.IsReady()){
                WwiseManager.PostEvent(WWISE_EVENTS.tick);
            }

        }
    }

    public float GetTickTime(){
        return Mathf.Abs(tickInterval - tick);
    }

    public float GetAccurate(){
        var v1 = Mathf.Abs(tickInterval - tick);
        var v2 = Mathf.Abs(tick);
        return Mathf.Min(v1,v2);
    }

    
    

    public float ForceSync(){
        return tick = (tickInterval);
    }

    void Update()
    {
        Tick();
    }
}
