using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RadioController : IInteractable
{
    [SerializeField] AudioClip audioToggle;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartLook()
    {
        ShowText = true;
        GUIText = "turn " + (audioSource.isPlaying ?  "off" : "on");
    }

    public override void OnInteract()
    {
        if (!audioSource.isPlaying) Ligar(); else Desligar();
        //StartCoroutine(resetGUIText());
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

    //private IEnumerator resetGUIText()
    //{
    //    OnEndLook();
    //    yield return new WaitForSeconds(audioToggle.length + 0.1f);
    //    OnStartLook();
    //}

    public void Ligar()
    {
        audioSource.PlayOneShot(audioToggle);
        audioSource.Play();
    }

    public void Desligar()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioToggle);
    }
}
