using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawingfish : MonoBehaviour
{
    public greenbar greenbar;
    public GameObject fishy;
    public Vector2 fishypos = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(fishy.transform.position.y);
        fishy.transform.position = fishypos;
    }

    // Update is called once per frame
    void Update()
    {
     if(greenbar.currentValue == fishy.transform.position.y)
     {
         Debug.Log("fishy say hi");
     }
    }
}