using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerMovement playerMovement;
    //efek genangan Air
    [SerializeField] private float SlowTime = 1.5f;
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float diam;
    private float speedBiasa =5;
    GameObject pisang;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        speedBiasa = playerMovement.forwardSpeed;
    }

    // Update is called once per frame
    void Update()
    {
      
        pisang = GameObject.FindWithTag("Pisang");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Air")
        {
            print("genangan air");
            playerMovement.forwardSpeed = SlowSpeed;
            StartCoroutine(GenanganAir());
        }

        if (other.tag == "Lubang")
        {
            print("Lubang");
            StartCoroutine(Jatuh());
            SFX.PlaySound("Jatuh");
            playerMovement.AnimatorJatuh();
        }

        if(other.tag== "Pisang")
        {
            Destroy(pisang);
            playerMovement.AnimatorJatuh();
            print("Pisang");
            StartCoroutine(Jatuh());
            SFX.PlaySound("Jatuh");
          
        }
       
        if(other.tag == "Danau")
        {
            playerMovement.forwardSpeed = 2.5f;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Danau")
        {
            playerMovement.forwardSpeed = 5;
        }
    }

    IEnumerator GenanganAir()
    {
        yield return new WaitForSeconds(SlowTime);
        playerMovement.forwardSpeed = speedBiasa;
    }

    IEnumerator Jatuh()
    {
        
        playerMovement.forwardSpeed = diam;
        yield return new WaitForSeconds(SlowTime);
        playerMovement.forwardSpeed = 5;
    }

}
