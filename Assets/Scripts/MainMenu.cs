using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject AboutP, CharaP, UIBlur;

    // Start is called before the first frame update
    void Start()
    {
        
        AboutP.SetActive(false);
        CharaP.SetActive(false);
        UIBlur.SetActive(false);
       
    }

    
    public void StarButton()
    {
        CharaP.SetActive(true);
        UIBlur.SetActive(true);
        SFX.PlaySound("Click");
    }
  

    public void AboutB()
    {
        AboutP.SetActive(true);
        SFX.PlaySound("Click");
    } 

  

    public void CloseAbout()
    {
        AboutP.SetActive(false);
        SFX.PlaySound("Click");
    }

    public void ClosedCharaP()
    {
        CharaP.SetActive(false);
        UIBlur.SetActive(false);
        SFX.PlaySound("Click");
    }

    public void ClickS()
    {
        SFX.PlaySound("Click");
    }
   

}
