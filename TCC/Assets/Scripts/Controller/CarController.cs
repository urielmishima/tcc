using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class CarController : MonoBehaviour
{
    private Light[] ligths;
    private AudioSource audioSource;
    [SerializeField] private AudioClip hornClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ligths = GetComponentsInChildren<Light>();
    }

    public void TurnOnAlarm()
    {
        audioSource.clip = hornClip;
        audioSource.loop = true;
        audioSource.Play();
        StartCoroutine("Alarm");
    }

    public void TurnOffAlarm()
    {
        audioSource.Stop();
        audioSource.loop = false;
        StopCoroutine("Alarm");
        foreach (Light ligth in ligths)
        {
            ligth.enabled = false;
        }
        
    }

    private IEnumerator Alarm()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            foreach(Light ligth in ligths)
            {
                ligth.enabled = !ligth.enabled;
            }
        }
    }
}
