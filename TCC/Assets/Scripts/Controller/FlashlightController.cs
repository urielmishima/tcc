using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour, IToggleable
{
    [SerializeField] private Light light;

    private void Start()
    {
        light.enabled = false;
    }

    public void Toggle()
    {
        light.enabled = !light.enabled;
    }
}
