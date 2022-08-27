using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameEvent : MonoBehaviour
{
    public GameObject PanelWin, PanelLose, setting, panelResume;
    private PlayerMovement player;
    public Animator animator;
    public Text besttimer;

    public Stopwatch stopwatch;
    // Start is called before the first frame update

    private void Awake()
    {
       
        player = GetComponent<PlayerMovement>();
    
        
        setting.SetActive(false);
        panelResume.SetActive(false);
    }

    void Start()
    {
        
        PanelWin.SetActive(false);
        PanelLose.SetActive(false);
     
    }

    // Update is called once per frame
    void Update()
    {

       
    }


   

    public void Pausee()
    {
        if (!PlayerManager.IsGamePaused)
        {
            PauseGame();
            panelResume.SetActive(true);
            animator.SetTrigger("OpenP");
           
        }
    }

  

    public void tombolResume()
    {
        ResumeGame();
        animator.SetTrigger("CloseP");
        panelResume.SetActive(false);
    }

    public void PauseGame()
    {
        if (!PlayerManager.IsGamePaused)
        {
           
            Time.timeScale = 0;
            PlayerManager.IsGamePaused = true;
        }
    }

    public void ResumeGame()
    {
        if (PlayerManager.IsGamePaused)
        {
           
            Time.timeScale = 1;
            PlayerManager.IsGamePaused = false;
        }
    }

    public void Menang()
    {
        if (!PlayerManager.Winning)
        {
            Time.timeScale = 0;
            stopwatch.waktuTerbaik();
            PanelWin.SetActive(true);
            SFX.PlaySound("Win");
            PlayerManager.Winning = true;
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        PlayerManager.Winning = false;
        Time.timeScale = 1;
        SFX.PlaySound("Click");
    }

    public void Kalah()
    {
        Time.timeScale = 0;
        PanelLose.SetActive(true);
        SFX.PlaySound("Lose");
    }
    
    public void Settinggg()
    {
        setting.SetActive(true);
    }
    public void exitse()
    {
        setting.SetActive(false);
        SFX.PlaySound("Click");
    }

    public void bactToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
