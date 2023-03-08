using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;
    public int money;

    public void SpawnNewObject()
    {
        Instantiate(objects[Random.Range(0, objects.Count)], new Vector3(15, 0, 0), Quaternion.identity);
    }
}
