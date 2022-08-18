using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Animator Door=null;

    [SerializeField] private AudioSource Audio, Audio2;

    private void OnTriggerEnter(Collider other)
    {
        Audio.Play();
        if (other.CompareTag("PuzzleObject"))
        {
            StartCoroutine(OpenDoor());
            Door.Play("DoorOpening", 0, 0.0f);
            Audio2.Play();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PuzzleObject"))
        {
            StartCoroutine(OpenDoor());
            Door.Play("DoorClosing", 0, 0.0f);
            Audio2.Play();
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
