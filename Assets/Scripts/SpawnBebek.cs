using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBebek : MonoBehaviour
{
    public GameObject BebeksPrefab;
    public float RespawnTime;
    public Transform  spawnPoint2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBebekWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObjectBebek()
    {
        GameObject D = Instantiate(BebeksPrefab) as GameObject;
        D.transform.position = new Vector3(13.34f, 0.2f, 245.8f);
    }


    IEnumerator SpawnBebekWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnObjectBebek();
        }
    }
}
