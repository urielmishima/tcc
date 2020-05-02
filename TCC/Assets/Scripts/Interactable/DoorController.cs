using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip openingSound;
    [SerializeField] private AudioClip closingSound;
    [SerializeField] private GameObject nobodyPrefab;
    [SerializeField] private bool locked = false;

    private Animator animator;
    private AudioSource audioSource;
    private bool interactedBefore = false;
    private bool firstOpenDoor = true;

    private bool showText = false;

    private bool open = false;

    public UnityEvent triedOpenDoor;
    public UnityEvent firstOpenDoorEvent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    public void OnStartLook()
    {
        Debug.Log("Olhando");
        showText = true;
    }

    public void OnInteract()
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

    public void OnEndLook()
    {
        showText = false;
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