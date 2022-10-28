using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StvaranjeObjekata : MonoBehaviour
{
    public Transform[] objekti;
    public GameObject blockPrefab;
    public float vrimeIzmeduPadanja = 1f;
    public float vrime = 1f;

    void Update()
    {
        if (Time.time >= vrime)
        {
            Spawn();
            vrime = Time.time + vrimeIzmeduPadanja;
        }
    }
    public void Spawn()
    {
        int randomIndex = Random.Range(0, objekti.Length);
        Instantiate(blockPrefab, objekti[randomIndex].position, Quaternion.identity);
    }
}
