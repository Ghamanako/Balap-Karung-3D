using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWin : MonoBehaviour
{
    public InGameEvent inGame;
    void Start()
    {
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "garis finish")
        {
            inGame.Kalah();
        }
    }
}
