using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRaycasting : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 3f;
    private IInteractable currentTarget;

    private void Update()
    {
        HandleRaycast();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentTarget != null)
            {
                currentTarget.OnInteract();
            }
        }
    }

    private void HandleRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            IInteractable lootable = hit.collider.GetComponent<IInteractable>();

            if(lootable != null)
            {
                if(lootable == currentTarget)
                {
                    return;
                }
                else if (currentTarget != null)
                {
                    currentTarget.OnEndLook();
                    currentTarget = lootable;
                    currentTarget.OnStartLook();
                }
                else
                {
                    currentTarget = lootable;
                    currentTarget.OnStartLook();
                }
            }
            else
            {
                if(currentTarget != null)
                {
                    currentTarget.OnEndLook();
                    currentTarget = null;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnEndLook();
                currentTarget = null;
            }
        }
    }
}
