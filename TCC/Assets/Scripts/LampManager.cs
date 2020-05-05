using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampManager : MonoBehaviour
{
    private Light[] lights;

    void Start()
    {
        lights = GetComponentsInChildren<Light>();
    }

    public void ToggleAllLights()
    {
        foreach(Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
