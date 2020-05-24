using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class OnTriggerSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasTriggered;

    public UnityEvent triggered;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasTriggered)
        {
            triggered?.Invoke();
            audioSource.Play();
            hasTriggered = true;
            Destroy(gameObject, 5f);
        }
    }
}
