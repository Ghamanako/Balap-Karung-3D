using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKayu : MonoBehaviour
{
    public GameObject KayuPrefabs;
    public float RespawnTime;
    public Transform  spawnPoint1;
     void Start()
    {
        StartCoroutine(SpawnKayuwave());
        
    }

    private void SpawnObject()
    {
        GameObject C = Instantiate(KayuPrefabs) as GameObject;
        C.transform.position = new Vector3(13.34f, 0.516f, 261f);

    }

   

    IEnumerator SpawnKayuwave()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnObject();
        }
    }

}
