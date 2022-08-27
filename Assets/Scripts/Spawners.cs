using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public Transform[] SpawnLocations;
    public GameObject[] WhatToSpawnPrefab;
    public GameObject[] WhatToSpawnClones;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLah();
    }

    public void SpawnLah()
    {
        WhatToSpawnClones[0] = Instantiate(WhatToSpawnPrefab[0], SpawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        WhatToSpawnClones[1] = Instantiate(WhatToSpawnPrefab[1], SpawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        WhatToSpawnClones[2] = Instantiate(WhatToSpawnPrefab[0], SpawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
