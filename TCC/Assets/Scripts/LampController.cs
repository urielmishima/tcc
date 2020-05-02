using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    public void Toggle()
    {
        light.enabled = !light.enabled;
    }

    public void DramaticallyTurnOff()
    {
        StartCoroutine(dramaticallyTurnOff());
    }

    private IEnumerator dramaticallyTurnOff()
    {
        Toggle();
        yield return new WaitForSeconds(2f);
        Toggle();
    }
}
