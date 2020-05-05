using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class DoorController : IInteractable
{
    [SerializeField] private AudioClip openingSound;
    [SerializeField] private AudioClip closingSound;
    [SerializeField] private GameObject nobodyPrefab;
    [SerializeField] private bool locked = false;

    private Animator animator;
    private AudioSource audioSource;
    private bool interactedBefore = false;
    private bool firstOpenDoor = true;

    private bool open = false;

    public UnityEvent triedOpenDoor;
    public UnityEvent firstOpenDoorEvent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    public override void OnStartLook()
    {
        Debug.Log("Olhando");
        ShowText = true;
        GUIText = open ? "close" : "open";
    }

    public override void OnInteract()
    {
        if (locked)
        {
            Debug.Log("entrou no if");
            audioSource.PlayOneShot(openingSound);
            StartCoroutine(InvokeNobody());
        }
        else
        {
            if (interactedBefore)
            {
                if (firstOpenDoor)
                {
                    firstOpenDoor = false;
                    firstOpenDoorEvent?.Invoke();
                    OnEndLook();
                }

                animator.SetTrigger("abrir_porta");
                open = !open;
                if (!audioSource.isPlaying)
                {
                    if (open)
                    {
                        audioSource.PlayOneShot(openingSound);
                    }
                    else
                    {
                        StartCoroutine(Close());
                    }
                }
            }
            else
            {
                triedOpenDoor?.Invoke();
                interactedBefore = true;
            }
        }
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(1.4f);
        audioSource.PlayOneShot(closingSound);
    }

    private IEnumerator InvokeNobody()
    {
        GameObject nobody = Instantiate(nobodyPrefab, transform.forward, transform.rotation);
        yield return new WaitForSeconds(2f);
        //Destroy(nobody);
    }
}