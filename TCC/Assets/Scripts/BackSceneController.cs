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
        if (VerifyPlayerHasArtifact()) ShowText = true;
    }
    public override void OnInteract()
    {
        if (VerifyPlayerHasArtifact())
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Capela"));
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Sala"));
        }
        
    }

    private bool VerifyPlayerHasArtifact()
    {
        foreach (var item in ItemHandler.instance.items)
        {
            print(item.name);
            if (item.name.Contains("ArtefatoAmarelo")) return true;
        }
        return false;
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }
}
