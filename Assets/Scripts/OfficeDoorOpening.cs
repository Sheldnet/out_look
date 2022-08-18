using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDoorOpening : MonoBehaviour
{
    [SerializeField] private Animator Door = null;

    [SerializeField] private AudioSource Audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Door.Play("OfficeDoorOpen", 0, 0.0f);
        Audio.Play();
    }

}
