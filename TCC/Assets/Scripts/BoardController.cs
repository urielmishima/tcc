using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour, IInteractable
{
    [SerializeField] private ExplosaoSala animacao;

    public void OnEndLook()
    {
        Debug.Log("Stop Looking for the board");
    }

    public void OnInteract()
    {

        Debug.Log("Interacting with board");
        string name = ItemHandler.instance.CurrentItem.transform.name;
        if (name == "Doll(Clone)")
        {
            Debug.Log("Entrou no if");
            ItemScriptableObject doll = ItemHandler.instance.useItem();
            Instantiate(doll.prefab, transform.position + new Vector3(0, .1f), transform.rotation);
            animacao.Init();
        }
    }

    public void OnStartLook()
    {
        Debug.Log("Looking for the board");
    }
}
