using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    private Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")     // ako je kocka pala na pod ili na novcic ili bilo sta, kocka nestaje
        {
            Destroy(this.gameObject);
        }
        else
        {
            RB.constraints = RigidbodyConstraints.FreezeAll; // ako je pala na igraca freeza mu se pozicija i rotacija
        }
    }
}