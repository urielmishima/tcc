using UnityEngine;
using UnityEngine.Events;

public class NoteController : IInteractable
{
    public UnityEvent NoteReaded;

    public override void OnStartLook()
    {
        ShowText = true;
        GUIText = "interact";
    }

    public override void OnInteract()
    {
        ReadNote();
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }

    public void ReadNote()
    {
        NoteReaded?.Invoke();
    }
}
