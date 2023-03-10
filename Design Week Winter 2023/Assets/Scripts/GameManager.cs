using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;
    public int money;
    public GameObject luigiPrefab;

    public void SpawnNewObject()
    {
        Instantiate(objects[Random.Range(0, objects.Count)], new Vector3(15, 0, 0), Quaternion.identity);
        if(objects.Count == 8)
        {
            objects.Add(luigiPrefab);
        }
        Debug.Log(objects.Count);
    }
}
