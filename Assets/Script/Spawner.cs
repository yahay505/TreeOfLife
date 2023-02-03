using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject spawnObject;
    public GameObject first;
    public GameObject second;
    public Vector3 firstTransform, secondTransform;


    public void spawn()
    {
        firstTransform = first.transform.position;
        secondTransform = second.transform.position;
        Vector2 randomSpawnPosition = new Vector2(Random.Range(firstTransform.x, secondTransform.x), Random.Range(firstTransform.y, secondTransform.y));
        Instantiate(spawnObject, randomSpawnPosition, Quaternion.identity);
    }


}
