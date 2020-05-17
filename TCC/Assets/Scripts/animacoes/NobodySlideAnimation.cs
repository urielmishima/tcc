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
        if (!hasTriggered && other.gameObject.CompareTag("Player"))
        {
            audioSouce.Play();
            if (audioSouce.time < 7)
            {
                audioSouce.time = 7f;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timePassed += Time.deltaTime;
            if (!hasTriggered && timePassed >= 4)
            {
                animator.SetTrigger("slide-animation-trigger");
                hasTriggered = true;
                Destroy(audioSouce, 1.8f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!hasTriggered && other.gameObject.CompareTag("Player"))
        {
            audioSouce.Pause();
        }
    }
}
