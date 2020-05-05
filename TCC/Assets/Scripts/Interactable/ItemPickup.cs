using System;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : IInteractable
{

    [SerializeField] private ItemScriptableObject item;

    public UnityEvent itemCaught;

    public override void OnStartLook()
    {
        ShowText = true;
        GUIText = "pickup the item";
    }

    public override void OnInteract()
    {
        Destroy(gameObject);
        ItemHandler.instance.PickUp(item);
        itemCaught?.Invoke();
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

}
