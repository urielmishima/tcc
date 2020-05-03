using UnityEngine;

public abstract class IInteractable: MonoBehaviour
{
    public string GUIText { get; set; }
    
    public bool ShowText { get; set; }

    public virtual void OnStartLook() { }
    public virtual void OnInteract() { }
    public virtual void OnEndLook() { }

    private void OnGUI()
    {
        if (ShowText)
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

            GUI.Label(rect, "Press E to " + GUIText, centeredStyle);
        }
    }
}
