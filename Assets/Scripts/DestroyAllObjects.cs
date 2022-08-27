using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllObjects : MonoBehaviour
{
    [SerializeField] private GameObject gameObjects;
    void Start()
    {
        Destroy(gameObjects, 5);   
    }
}
