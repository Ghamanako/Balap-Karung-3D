using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Ai : MonoBehaviour
{
    private AI aI;
    //efek genangan Air
    [SerializeField] private float SlowTime = 1.5f;
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float diam;
    public float speedBiasa ;
    GameObject pisang;

    void Start()
    {
        aI = GetComponent<AI>();
        speedBiasa = aI.speed;
       
    }

     void Update()
    {
        pisang = GameObject.FindWithTag("Pisang");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Air")
        {
            print("genangan air");
            aI.speed = SlowSpeed;
            StartCoroutine(GenanganAir());
        }

        if (other.tag == "Lubang")
        {
            print("Lubang");
            StartCoroutine(Jatuh());
            aI.jatuh();
        }

        if (other.tag == "Pisang")
        {
            Destroy(pisang);
            print("Pisang");
            StartCoroutine(Jatuh());
            SFX.PlaySound("Jatuh");
            aI.jatuh();
        }

        if (other.tag == "Danau")
        {
            aI.speed =1f ;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Danau")
        {
            aI.speed = speedBiasa;
        }
    }

    IEnumerator GenanganAir()
    {
        yield return new WaitForSeconds(SlowTime);
        aI.speed = speedBiasa;
    }

    IEnumerator Jatuh()
    {

        aI.speed = diam;
        yield return new WaitForSeconds(SlowTime);
        aI.speed = 5;
    }
}
