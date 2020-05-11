using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : IInteractable
{
    [SerializeField] private ExplosaoSala animacao;
    private GameObject objectOnTheBoard;

    public override void OnStartLook()
    {
        if(VerifyPlayerHasDoll()) ShowText = true;
        GUIText = "interact";
    }

    public override void OnInteract()
    {        
        if (VerifyPlayerHasDoll())
        {
            ItemScriptableObject doll = ItemHandler.instance.useItem();
            objectOnTheBoard = Instantiate(doll.prefab, transform.position + new Vector3(0, .1f), transform.rotation * Quaternion.Euler(180, 0, 0));
            Destroy(objectOnTheBoard.GetComponent<ItemPickup>());
            animacao.Init();
        }
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

    private bool VerifyPlayerHasDoll()
    {
        if (ItemHandler.instance.CurrentItem)
        {
            string name = ItemHandler.instance.CurrentItem.transform.name;
            return name == "Doll(Clone)";
        }
        return false;
    }

    public void DestroyObjectOnTheBoard()
    {
        if(objectOnTheBoard)
        {
            Destroy(objectOnTheBoard);
            objectOnTheBoard = null;
        }
    }
}
