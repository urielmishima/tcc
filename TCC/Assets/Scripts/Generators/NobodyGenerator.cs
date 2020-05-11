using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobodyGenerator : MonoBehaviour
{
    private static bool hasInvokedBehindBefore = false;
    [SerializeField] private GameObject nobodyPrefab;

    public void Invoke()
    {
        if (!hasInvokedBehindBefore)
        {
            Instantiate(nobodyPrefab, transform.position, transform.rotation);
            hasInvokedBehindBefore = true;
        }
    }
}
