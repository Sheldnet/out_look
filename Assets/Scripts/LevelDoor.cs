using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] private Animator Door = null;

    [SerializeField] private AudioSource Audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor());
            Door.Play("LebelDoorOpen2", 0, 0.0f);
            Audio.Play();
        }

    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
