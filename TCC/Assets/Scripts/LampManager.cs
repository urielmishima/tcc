using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampManager : MonoBehaviour
{
    private Light[] lights;
    [SerializeField] private AudioClip desligar;
    private AudioSource audioSource;

    void Start()
    {
        lights = GetComponentsInChildren<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleAllLights()
    {
        audioSource.PlayOneShot(desligar);
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
