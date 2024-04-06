using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Dummy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
