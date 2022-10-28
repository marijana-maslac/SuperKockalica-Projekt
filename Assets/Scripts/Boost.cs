using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public Transform[] objekti;
    public GameObject blockPrefab;
    public float vrimeIzmeduStvaranja = 10f;
    public float vrime = 5f;

    private void Update()
    {
        if (Time.time >= vrime)
        {
            Spawn();
            vrime = Time.time + vrimeIzmeduStvaranja;
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, objekti.Length);
        Instantiate(blockPrefab, objekti[randomIndex].position, Quaternion.identity);
    }
}
