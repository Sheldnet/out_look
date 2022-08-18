using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableButton : MonoBehaviour
{
    public Animator bridge;
    public Animator button;
    public float Time=15;
    private bool playerInZone;

    private void Start()
    {
        playerInZone = false;
    }

    private void Update()
    {
        
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            button.Play("Push");
            bridge.Play("BridgeOpening");
            ButtonDelay();
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
    void TimeOut()
    {
        bridge.Play("BridgeClosing");
    }

    void ButtonDelay()
    {
        Invoke("TimeOut", Time);
    }
}
