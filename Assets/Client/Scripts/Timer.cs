using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text Timer_Text;
    private int minutes = 0;
    private float seconds = 0f;
    void Start()
    {
        Timer_Text = GetComponent<Text>();
    }

    void Update()
    {
        if (seconds > 59)
        {
            minutes++;
            seconds = 0f;
        }

        else
        {
            seconds += Time.deltaTime;
        }

        int sec = (int)seconds;
        Timer_Text.text = minutes.ToString() + " : " + sec.ToString();
    }
}