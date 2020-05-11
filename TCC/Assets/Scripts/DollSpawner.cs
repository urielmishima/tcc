using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject objectInstantiated;
    private bool hasInstantiated = false;

    public void InstantiateObject()
    {
        if (!hasInstantiated)
        {
            objectInstantiated = Instantiate(prefab, transform);
            Destroy(objectInstantiated.GetComponent<ItemPickup>(), 2);
            hasInstantiated = true;
        }
    }

    public void DestroyObject()
    {
        Destroy(objectInstantiated);
    }
}
