using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{

    [SerializeField] private ItemScriptableObject item;
    private bool showText = false;

    public void OnStartLook()
    {
        showText = true;
    }

    public void OnInteract()
    {
        Destroy(gameObject);
        ItemHandler.instance.PickUp(item);
    }

    public void OnEndLook()
    {
        showText = false;
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

            GUI.Label(rect, "Press E to pick the item", centeredStyle);
        }
    }
}
