using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobodySlideAnimation : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSouce;
    private bool hasTriggered;
    private float timePassed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSouce = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSouce.Play();
        if(audioSouce.time < 7)
        {
            audioSouce.time = 7f;
        }
    }

    private void OnTriggerStay(Collider other)
    {        
        timePassed += Time.deltaTime;
        if (!hasTriggered && other.gameObject.CompareTag("Player") && timePassed >= 4)
        {
            animator.SetTrigger("slide-animation-trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        audioSouce.Pause();
    }
}
