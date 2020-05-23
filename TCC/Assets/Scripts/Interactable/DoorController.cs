using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class DoorController : IInteractable
{
    [SerializeField] private AudioClip openingSound;
    [SerializeField] private AudioClip closingSound;
    [SerializeField] private AudioClip unlockSound;
    [SerializeField] private bool locked;
    [SerializeField] private bool requireKey;
    [SerializeField] private int openDirection;

    private Animator animator;
    private AudioSource audioSource;

    private bool isOpen = false;

    public UnityEvent triedOpenDoor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetInteger("OpenDirection", openDirection);
    }


    public override void OnStartLook()
    {

        if (locked && requireKey)
        {
            ShowText = VerifyPlayerHasKey();
            GUIText = "unlock";
        }
        else
        {
            ShowText = true;
            GUIText = isOpen ? "close" : "open";
        }
    }

    public override void OnInteract()
    {
        if (!audioSource.isPlaying)
        {

            if (requireKey && locked)
            {
                audioSource.PlayOneShot(unlockSound);
            } else
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
        }
        if (!locked)
        {
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
        }
        else if (requireKey && VerifyPlayerHasKey())
        {
            ItemHandler.instance.useItem();
            UnLock();
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

    private bool VerifyPlayerHasKey()
    {
        if (ItemHandler.instance.CurrentItem)
        {
            string name = ItemHandler.instance.CurrentItem.transform.name;
            return name == "Key(Clone)";
        }
        return false;
    }
}