using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor1 : MonoBehaviour
{
    [SerializeField] private Animator Door = null;

    [SerializeField] private AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor());
            Door.Play("LevelDoorClose1", 0, 0.0f);
        }

        audio.Play();
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0.1f);
    }    
}
