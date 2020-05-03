using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : IInteractable
{
    [SerializeField] private ExplosaoSala animacao;

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
            Instantiate(doll.prefab, transform.position + new Vector3(0, .1f), transform.rotation);
            animacao.Init();
        }
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

    private bool VerifyPlayerHasDoll()
    {
        string name = ItemHandler.instance.CurrentItem.transform.name;
        return name == "Doll(Clone)";
    }
}
