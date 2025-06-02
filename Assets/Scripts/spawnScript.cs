using UnityEngine;
using System.Collections;

public class spawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] balloons;

    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(4);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(balloons[i], spawnPoints[i].position, Quaternion.identity);
        }
        StartCoroutine(SpawnRoutine());
    }
}
