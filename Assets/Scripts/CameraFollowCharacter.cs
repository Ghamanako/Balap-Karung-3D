using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    [SerializeField]GameObject Player;
    private Vector3 offset;


    void Start()
    {
        if (Player == null)
        {
            Player=GameObject.FindWithTag("Player");
        }

        offset = transform.position - Player.transform.position;
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + Player.transform.position.z);
        transform.position = newPosition;
    }
}
