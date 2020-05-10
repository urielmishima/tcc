using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NobodyBackwardsController : IInteractable
{
    [SerializeField] private AudioClip onStartLookSound;
    private bool fistLook = true;

    public override void OnStartLook()
    {
        if (fistLook)
        {
            GetComponent<AudioSource>().PlayOneShot(onStartLookSound);
            Destroy(gameObject, onStartLookSound.length);
            fistLook = false;
        }
    }
}
