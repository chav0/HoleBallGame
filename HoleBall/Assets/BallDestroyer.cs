using System;
using System.Collections;
using System.Collections.Generic;
using Client.Objects;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallObject>())
        {
            Destroy(other.gameObject);
        }
    }
}
