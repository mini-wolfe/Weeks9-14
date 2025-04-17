using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class spawingfish : MonoBehaviour
{
    // call to the bar slider
    public Slider slider;
    //call to the fish 
    public Slider fish;
    //when this time is met the fish is caught
    float catchingTimer;
    //trigger box padding 
    public float padding = 2f;

    float target;
    //random start potition 
    float startPos;
    //when the fish is moving 
    bool isMoving;
    float t = 0f;
    //players caught fish
    int score = 0;
    public TextMeshProUGUI scoreText;



    float currenltyCatching;
   
    // Start is called before the first frame update
    void Start()
    {
        //coroutine to initiate the game spawning the fish as well as initiate the lerping 
      StartCoroutine(fishyMove());
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = ("Fishys caught:" + score);
        if(isMoving)
        {
            t+= Time.deltaTime;
            fish.value = Mathf.Lerp(startPos,target,t);
            if(t >= 2f)
            {
                isMoving = false;
                StartCoroutine(fishyMove());
            }

        }
        //creating a trigger boxfo the slider so that the fish knows whe its beuing hit 
     if(Mathf.Abs(fish.value - slider.value) <= padding)
     {
         catchingTimer+= Time.deltaTime;
         //debug.log(catchingTimer)

     }
     //if the time requirements to catch fishy are met add one to the score and start the coroutine to initiate the repetition of the game. the fish is caught prepare anothere to be caught 
     if(catchingTimer >= 3f)
     {
         Debug.Log("catch fishy");
         StartCoroutine(fishyCatch());
         score++;
     }

    }

    // when fishymove is called lerp the fish between the min and max of the bar waiting seconds between lerping.
IEnumerator fishyMove()
{
    yield return new WaitForSeconds(Random.Range(3,5));

    startPos = fish.value;
    target = Random.Range(fish.minValue,fish.maxValue);
    t=0f;
    isMoving = true;
}
// when fish is caught wait a couple seconds spawn a new fish and start the fish movment again to reinitiate the game. 
IEnumerator fishyCatch()
{
    catchingTimer = 0f;
    fish.gameObject.SetActive(false);
    yield return new WaitForSeconds(1.5f);
    fish.value = Random.Range(fish.minValue,fish.maxValue);
    fish.gameObject.SetActive(true);

    StartCoroutine(fishyMove());
}
}