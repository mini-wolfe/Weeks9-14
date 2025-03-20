using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourHand;
    public Transform MinuteHand;
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    Coroutine clockisrunning;
   IEnumerator doOneHOur;

    void Start()
    {
        clockisrunning = StartCoroutine(MoveTheClock());
    }
    IEnumerator MoveTheClock() 
    {
        while (true) 
        {
            doOneHOur = MoveTheClockHandOneHOur();
            yield return StartCoroutine(doOneHOur);
        }
       
        
    }
    IEnumerator MoveTheClockHandOneHOur()
    {
        t = 0;
        while (t< timeAnHourTakes) {
            t += Time.deltaTime;
            MinuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;
        if(hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }
    public void StopTHeClock()
    {
        if (clockisrunning != null)
        {
            StopCoroutine(clockisrunning);
        }
        if(doOneHOur != null)
        {
            StopCoroutine(doOneHOur); 
         }
     
    }
}
