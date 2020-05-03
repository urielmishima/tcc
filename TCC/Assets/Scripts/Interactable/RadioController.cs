using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RadioController : IInteractable
{
    private AudioSource audioSource;
    private bool on = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartLook()
    {
        ShowText = true;
        GUIText = "turn " + (on ?  "off" : "on");
    }

    public override void OnInteract()
    {
        on = !on;
        audioSource.mute = !on;
        OnEndLook();
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }
}
