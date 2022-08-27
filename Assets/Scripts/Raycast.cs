using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private RaycastHit hit;
    private float range = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Ray CenterRay = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * range, Color.yellow);
    }
}
