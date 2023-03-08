using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;

    public void SpawnNewObject()
    {
        Debug.Log(objects[Random.Range(0,objects.Count)].name);
        Debug.Log(objects.Capacity);
        //Instantiate(objects[Random.Range(0, objects.Capacity)], new Vector3(15, 0, 0), Quaternion.identity);
    }
}
