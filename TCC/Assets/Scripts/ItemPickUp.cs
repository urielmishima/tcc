using UnityEngine;

public class ItemPickUp : FlatInteractable
{
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up item.");
    }
}
