using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulse : MonoBehaviour
{
    public float repulsestr;
    
   private void OnTriggerStay(Collider other)
    {
        //other.attachedRigidbody.AddForce(new Vector3(0, other.attachedRigidbody.velocity.y, 0) *  repulsestr, ForceMode.Impulse);
        Vector3 velosiped = other.attachedRigidbody.velocity;
        velosiped.y += repulsestr;
        other.attachedRigidbody.velocity = velosiped;
    }
}
