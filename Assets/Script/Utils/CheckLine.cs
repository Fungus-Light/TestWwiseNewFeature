using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLine : MonoBehaviour
{
    public GameObject Left, Right;
    public float tick = 0, tickInterval = 1;

    public float LeftMax = 0;
    public float RightMax = 0;
    public BasicBeat beat;
    Vector3 leftPos, rightPos;
    // Start is called before the first frame update
    void Start()
    {
        LeftMax = Left.transform.localPosition.x;
        RightMax = Right.transform.localPosition.x;
        Debug.Log(LeftMax + "   " + RightMax);
        tick = 0;
        tickInterval = 1;
        leftPos = Left.transform.localPosition;
        rightPos = Right.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (beat.TickEnable)
        {
            float rate = Mathf.Abs((tickInterval - tick) / tickInterval);
            
            leftPos.x = LeftMax * rate;
            Left.transform.localPosition = leftPos;

            rightPos.x = RightMax * rate;
            Right.transform.localPosition = rightPos;
        }

    }
}
