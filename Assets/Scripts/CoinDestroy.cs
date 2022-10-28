using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    public float time;

    private void Start()
    {
        Destroy(gameObject, time);  //ako Coinsi stoje na podu bez interakcije sa igracem, nestat ce nakon onoliko sekundi koliko je zadano u Inspectoru (trenutno je zadano 4sec)
    }
    private void Update()
    {
        transform.Rotate(4, 2, 0, Space.World);
    }
}
