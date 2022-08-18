using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    public float flyforce;
    public float shootforce;
    public Animator Pad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.velocity = new Vector3(0, 0, 0);
            other.attachedRigidbody.AddRelativeForce(0, flyforce, shootforce, ForceMode.Impulse);
            Pad.Play("jump", 0, 0.0f);
        }
    }

}
