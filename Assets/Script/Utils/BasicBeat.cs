using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicBeat : MonoBehaviour
{

    public int BPM = 128;

    public int GridPerBeat = 8;

    private float tickInterval = GameConst.SEC_PER_MIN / (GameConst.DEFAULT_BPM * GameConst.DEFAULT_GRID_PER_BEAT);

    public int tickCount = 0;
    public int gridCount = 0;

    private float tick = 0;
    private int gridTick = 0;

    public bool TickEnable = false;

    public UnityEvent tickEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset(){
        tickInterval = GameConst.SEC_PER_MIN / (BPM * GridPerBeat);
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
        tick = tick + Time.fixedDeltaTime;
        if (tick >= tickInterval)
        {
            tick = 0;
            tickCount++;

            gridTick++;
            if (gridTick >= GridPerBeat)
            {
                gridTick = 0;
                gridCount++;

                Debug.Log("Beat!");

                if (WwiseManager.IsReady())
                {
                    WwiseManager.PostEvent(WWISE_EVENTS.tick);
                }
                tickEvent?.Invoke();
            }

        }
    }
    void FixedUpdate()
    {
        Tick();
    }
}
