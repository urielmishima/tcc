using System;
using UnityEngine;

public class ItemPickup : IInteractable
{

    [SerializeField] private ItemScriptableObject item;

    public override void OnStartLook()
    {
        ShowText = true;
        GUIText = "pickup the item";
    }

    public override void OnInteract()
    {
        Destroy(gameObject);
        ItemHandler.instance.PickUp(item);
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

}
