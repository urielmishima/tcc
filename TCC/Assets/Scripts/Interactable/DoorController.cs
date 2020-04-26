using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip openingSound;
    [SerializeField] private AudioClip closingSound;
    private AudioSource audioSource;
    private bool showText = false;
    private bool open = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnStartLook()
    {
        showText = true;
    }

    public void OnInteract()
    {
        animator.SetTrigger("abrir_porta");
        open = !open;
        audioSource.PlayOneShot(openingSound);
    }

    public void OnEndLook()
    {
        showText = false;
    }

    private void OnGUI()
    {
        if (showText)
        {
            var w = .3f;
            var h = .2f;

            var rect = new Rect();
            rect.x = (Screen.width * (1 - w)) / 2;
            rect.y = (Screen.height * (1 - h)) / 2;
            rect.width = Screen.width * w;
            rect.height = Screen.height * h;

            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.LowerCenter;

            var text = (open) ? "Press E to close" : "Press E to open";

            GUI.Label(rect, text, centeredStyle);
        }
    }
}
