using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static AudioClip LompatFX, JatuhFX, HitFX, WinFX, LoseFX, ClickFX;
    static AudioSource audioSource;

    void Start()
    {
        LompatFX = Resources.Load<AudioClip>("Lompat");
        JatuhFX = Resources.Load<AudioClip>("Jatuh");
        HitFX = Resources.Load<AudioClip>("Hit");
        WinFX = Resources.Load<AudioClip>("Win");
        LoseFX = Resources.Load<AudioClip>("Lose");
        ClickFX = Resources.Load<AudioClip>("Click");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Lompat":
                audioSource.PlayOneShot(LompatFX);
                break;
            case "Jatuh":
                audioSource.PlayOneShot(JatuhFX);
                break;
            case "Hit":
                audioSource.PlayOneShot(HitFX);
                break;
            case "Win":
                audioSource.PlayOneShot(WinFX);
                break;
            case "Lose":
                audioSource.PlayOneShot(LoseFX);
                break;
            case "Click":
                audioSource.PlayOneShot(ClickFX);
                break;
        }
    }
}
