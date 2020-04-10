using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Camera cam;
    public FlatInteractable focus;
    
    [SerializeField]
    private float interactRange = 1f;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            FlatInteractable interactable = hit.collider.GetComponent<FlatInteractable>();
            if (interactable != null)
            {

                SetFocus(interactable);
                
                if (Input.GetKeyDown(KeyCode.F))
                {
                    interactable.Interact();
                }

            }
            Debug.Log("We hit " + hit.collider.name + " " + hit.point);
        }
        
    }

    void SetFocus(FlatInteractable newFocus)
    {

        if (newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
    }

}
