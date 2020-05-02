using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour, IInteractable
{
    [SerializeField] private ExplosaoSala animacao;
    private bool showText = false;

    public void OnStartLook()
    {
        if(VerifyPlayerHasDoll()) showText = true;
    }

    public void OnInteract()
    {        
        if (VerifyPlayerHasDoll())
        {
            ItemScriptableObject doll = ItemHandler.instance.useItem();
            Instantiate(doll.prefab, transform.position + new Vector3(0, .1f), transform.rotation);
            animacao.Init();
        }
    }

    public void OnEndLook()
    {
        showText = false;
    }

    private bool VerifyPlayerHasDoll()
    {
        string name = ItemHandler.instance.CurrentItem.transform.name;
        return name == "Doll(Clone)";
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

            GUI.Label(rect, "Press E to interact", centeredStyle);
        }
    }
}
