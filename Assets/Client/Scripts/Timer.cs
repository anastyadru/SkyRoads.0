// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private int minutes = 0;
    private float seconds = 0f;

    public void Start()
    {
        timerText = GetComponent<Text>();
    }

    public void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            minutes++;
            seconds = 0f;
        }

        timerText.text = $"{minutes} : {Mathf.FloorToInt(seconds)}";
    }
}