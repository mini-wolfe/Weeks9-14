using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class greenbar : MonoBehaviour
{
    public Slider slider;
    public float currentValue = 0f;
    public int dropSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        //creating movement for the slider, allowing the player to move the "green bar" up based on space bar clicks
        if(Input.GetKeyDown(KeyCode.Space))
        {
        currentValue += 1;
        Debug.Log(currentValue);
        }
       //making "green bar" go down when space bar isnt pressed 
         currentValue = currentValue - dropSpeed* Time.deltaTime;
         // make sure the bar moves with the space bar being pressed
         slider.value = currentValue%slider.maxValue;
         if(currentValue <= 0)
         {
             currentValue = 0;
         }

    }
}