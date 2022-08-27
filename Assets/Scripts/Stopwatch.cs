using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Stopwatch : MonoBehaviour
{

    bool StopwatchActive = false;
    float CurrentTime;
    public int StartMinute;
    public Text CurrentTimeText, WaktuTerbaiks;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = 0;
        StopwatchActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (StopwatchActive == true)
        {
            CurrentTime = CurrentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        CurrentTimeText.text = time.ToString(@"mm\:ss");
        PlayerPrefs.SetString("BestTime", CurrentTimeText.text);
    }


    public void waktuTerbaik()
    {
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        WaktuTerbaiks.text = PlayerPrefs.GetString("BestTime").ToString();
    }

}
