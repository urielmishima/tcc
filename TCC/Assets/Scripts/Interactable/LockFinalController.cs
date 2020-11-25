using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockFinalController : IInteractable
{

    [SerializeField] private List<GameObject> points;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnStartLook()
    {
        ShowText = true;
        GUIText = "interact";
    }

    public override void OnInteract()
    {
        var allPointsFilled = true;
        foreach(var point in points)
        {
            if (VerifyPlayerHasArtifact(point.name))
            {
                ItemScriptableObject artifact = ItemHandler.instance.useItem();
                Instantiate(artifact.prefab, point.transform.position, point.transform.rotation, point.transform);
            }
            allPointsFilled = allPointsFilled && point.transform.childCount > 0;
        }
        if (allPointsFilled) SceneManager.LoadScene("Final");
    }

    private bool VerifyPlayerHasArtifact(string point)
    {
        if (ItemHandler.instance.CurrentItem)
        {
            string name = ItemHandler.instance.CurrentItem.name;
            return name == point;
        }
        return false;
    }

    public override void OnEndLook()
    {
        ShowText = false;
    }
}
