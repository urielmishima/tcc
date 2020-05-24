using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class ChainController : IInteractable
{
    [SerializeField] private AudioClip breakSound;

    private AudioSource audioSource;
    
    public UnityEvent chainBreaked;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartLook()
    {
        ShowText = VerifyPlayerHasPiler();
        GUIText = "break";
    }

    public override void OnInteract()
    {
        if (VerifyPlayerHasPiler())
        {
            ItemHandler.instance.useItem();
            audioSource.PlayOneShot(breakSound);
            chainBreaked?.Invoke();
            Destroy(gameObject, 1f);
        }
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

    private bool VerifyPlayerHasPiler()
    {
        if (ItemHandler.instance.CurrentItem)
        {
            string name = ItemHandler.instance.CurrentItem.transform.name;
            return name == "Piler(Clone)";
        }
        return false;
    }
}
