using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    //private bool finished = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        // if (finished)
        //     return;

        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    // public void Finish()
    // {
    //     finished = true;
    //     timerText.color = color.yellow;
    // }
}
