using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour, IToggleable
{
    [SerializeField] private Light light;
    [SerializeField] private AudioClip toggleSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        light.enabled = false;
    }

    public void Toggle()
    {
        light.enabled = !light.enabled;
        audioSource.PlayOneShot(toggleSound);
    }
}
