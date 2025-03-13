using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class evant : MonoBehaviour
{
    public RectTransform bannana;

    public UnityEvent OnTimerhasFinished;
    public float timerLength = 3;
    public float t;

    private void Update()
    {
        t += Time.deltaTime;
        if(t >timerLength)
        {
            t = 0;
            OnTimerhasFinished.Invoke();
        }
    }
    public void MousJustenteredImsge() 
    { 
        Debug.Log("Mouse Just Entered me!");
        bannana.localScale = Vector3.one * 1.2f;
    }

    public void MoMouseJustLeftImage()
    {
        Debug.Log("Mouse Just left me!");
    }
}
