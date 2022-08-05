using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
    
public class Timer : MonoBehaviour
{
    private Text timer;
    private float time;
  
    
    

    private void Start()
    {
        timer = GetComponent<Text>();    

    }
    private void Update()
    {
        TimeFormat();
    }

    private void TimeFormat()
    {
        time += Time.deltaTime;
        TimeSpan ts = TimeSpan.FromSeconds(time);

        timer.text = $"{ts.Minutes}:{ts.Seconds}";
    }
}
