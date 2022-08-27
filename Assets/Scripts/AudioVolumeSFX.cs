using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeSFX : MonoBehaviour
{
    public AudioSource audio;
    public Button button1, button2, button3, button4, button5;
    public Sprite color, normal;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void Changevolume1()
    {
        audio.volume = 0.25f;
        button1.image.sprite = color;
        button2.image.sprite = color;
        button3.image.sprite = normal;
        button4.image.sprite = normal;
        button5.image.sprite = normal;
        SFX.PlaySound("Click");
        save();
    }

    public void ChangeVolume0()
    {
        audio.volume = 0;
        button1.image.sprite = normal;
        button2.image.sprite = normal;
        button3.image.sprite = normal;
        button4.image.sprite = normal;
        button5.image.sprite = normal;
        SFX.PlaySound("Click");
        save();
    }

    public void ChangeVolume2()
    {
        audio.volume = 0.50f;
        button1.image.sprite = color;
        button2.image.sprite = color;
        button3.image.sprite = color;
        button4.image.sprite = normal;
        button5.image.sprite = normal;
        SFX.PlaySound("Click");
        save();
    }

    public void ChangeVolume4()
    {
        audio.volume = 0.75f;
        button1.image.sprite = color;
        button2.image.sprite = color;
        button3.image.sprite = color;
        button4.image.sprite = color;
        button5.image.sprite = normal;
        SFX.PlaySound("Click");
        save();
    }

    public void ChangeVolume5()
    {
        audio.volume = 1f;
        button1.image.sprite = color;
        button2.image.sprite = color;
        button3.image.sprite = color;
        button4.image.sprite = color;
        button5.image.sprite = color;
        SFX.PlaySound("Click");
        save();
    }

    public void Load()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("SFXVolume");
        if (PlayerPrefs.GetFloat("SFXVolume") == 0)
        {
            button1.image.sprite = normal;
            button2.image.sprite = normal;
            button3.image.sprite = normal;
            button4.image.sprite = normal;
            button5.image.sprite = normal;
        }

        else if (PlayerPrefs.GetFloat("SFXVolume") == 0.25f)
        {
            button1.image.sprite = color;
            button2.image.sprite = color;
            button3.image.sprite = normal;
            button4.image.sprite = normal;
            button5.image.sprite = normal;
        }

        else if (PlayerPrefs.GetFloat("SFXVolume") == 0.50f)
        {
            button1.image.sprite = color;
            button2.image.sprite = color;
            button3.image.sprite = color;
            button4.image.sprite = normal;
            button5.image.sprite = normal;
        }

        else if (PlayerPrefs.GetFloat("SFXVolume") == 0.75f)
        {
            button1.image.sprite = color;
            button2.image.sprite = color;
            button3.image.sprite = color;
            button4.image.sprite = color;
            button5.image.sprite = normal;
        }

        else
        {
            button1.image.sprite = color;
            button2.image.sprite = color;
            button3.image.sprite = color;
            button4.image.sprite = color;
            button5.image.sprite = color;
        }
    }

    public void save()
    {
        PlayerPrefs.SetFloat("SFXVolume", audio.volume);

    }
}
