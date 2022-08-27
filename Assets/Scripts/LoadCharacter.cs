using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] CharacterPrefabs;
    public Transform SpawnPoint;

    void Start()
    {
        int SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject prefab = CharacterPrefabs[SelectedCharacter];
        GameObject clone = Instantiate(prefab, SpawnPoint.position, Quaternion.identity);
    }
}
