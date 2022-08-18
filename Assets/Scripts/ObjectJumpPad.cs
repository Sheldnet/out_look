using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectJumpPad : MonoBehaviour
{
    public float flyforce;
    public float shootforce;
    public Animator Pad;
    public Superliminal holding;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzleObject"))
        {
            if (holding.target != null)
            {
                if (holding.target.GetComponent<Rigidbody>().isKinematic == true)
                {
                    holding.target.GetComponent<Rigidbody>().isKinematic = false;
                    holding.target = null;
                }
            }
            other.attachedRigidbody.velocity = new Vector3(0, 0, 0);
            other.attachedRigidbody.AddRelativeForce(0, flyforce, shootforce, ForceMode.Impulse);
            Pad.Play("jump", 0, 0.0f);
        }
    }
}
