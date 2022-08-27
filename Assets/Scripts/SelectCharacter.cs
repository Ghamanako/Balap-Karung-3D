using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public GameObject[] Characters;
    public GameObject SelectLevel;
    public int SelectedCharacter = 0;

    void Start()
    {
        SelectLevel.SetActive(false);   
    }

    public void NextCharacter()
    {
        Characters[SelectedCharacter].SetActive(false);
        SelectedCharacter = (SelectedCharacter + 1) % Characters.Length;
        Characters[SelectedCharacter].SetActive(true);
        SFX.PlaySound("Click");
    }

    public void PreviousCharacter()
    {
        Characters[SelectedCharacter].SetActive(false);
        SelectedCharacter--;
        if (SelectedCharacter < 0)
        {
            SelectedCharacter += Characters.Length;
        }
        Characters[SelectedCharacter].SetActive(true);
        SFX.PlaySound("Click");
    }


    public void ToLevelSelect()
    {
        SelectLevel.SetActive(true);
        SFX.PlaySound("Click");
    }

    public void BackSelectLevel()
    {
        SelectLevel.SetActive(false);
        SFX.PlaySound("Click");
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
        SceneManager.LoadScene( 1, LoadSceneMode.Single);
        SFX.PlaySound("Click");
    }

    public void StartLevel2()
    {
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        SFX.PlaySound("Click");
    }

    public void StartLevel3()
    {
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
        SFX.PlaySound("Click");
    }
}
