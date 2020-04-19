using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{

    [SerializeField] private ItemScriptableObject item;

    public void OnStartLook()
    {
        Debug.Log($"Stared looking at flashlight");
    }

    public void OnInteract()
    {
        Destroy(gameObject);
        ItemHandler.instance.PickUp(item);
    }

    public void OnEndLook()
    {
        
    }
}
