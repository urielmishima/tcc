using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackSceneController : IInteractable
{
    void Start()
    {
        GUIText = "interact";
    }

    public override void OnStartLook()
    {
        ShowText = true;
    }
    public override void OnInteract()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }
}
