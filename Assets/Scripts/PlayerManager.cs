using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static bool IsGamePaused;
    public static bool Winning;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        IsGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
