using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject PanelTutor;
    void Start()
    {
        PanelTutor.SetActive(true);
        Time.timeScale = 0;   
    }

    void Update()
    {
        tutorial();   
    }

    public void tutorial()
    {
        if (Input.touchCount > 0)
        {
            Time.timeScale = 1;
            PanelTutor.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            PanelTutor.SetActive(false);
        }
    }
}
