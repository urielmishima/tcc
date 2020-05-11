using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class DoorController : IInteractable
{
    [SerializeField] private AudioClip openingSound;
    [SerializeField] private AudioClip closingSound;
    [SerializeField] private bool locked = false;

    private Animator animator;
    private AudioSource audioSource;

    private bool isOpen = false;

    public UnityEvent triedOpenDoor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    public override void OnStartLook()
    {
        Debug.Log("Olhando");
        ShowText = true;
        GUIText = isOpen ? "close" : "open";
    }

    public override void OnInteract()
    {
        if (!audioSource.isPlaying)
        {
            if (!isOpen)
            {
                audioSource.PlayOneShot(openingSound);
            }
            else
            {
                StartCoroutine(Close());
            }
        }
        if (!locked)
        {
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
        }
        triedOpenDoor?.Invoke();
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

    public void UnLock()
    {
        locked = false;
    }

    private IEnumerator Close()
    {
        AnimatorClipInfo[] animatorClips = animator.GetCurrentAnimatorClipInfo(0);
        float animationTime = animatorClips[0].clip.length;

        yield return new WaitForSeconds(animationTime);
        audioSource.PlayOneShot(closingSound);
    }
}