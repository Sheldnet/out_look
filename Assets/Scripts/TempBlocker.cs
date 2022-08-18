using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBlocker : MonoBehaviour
{
    public Rigidbody rb;
    private bool active = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!active)
            {
                active = true;
                rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
