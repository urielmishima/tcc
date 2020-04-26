using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspectroTrigger : MonoBehaviour
{

    public CameraAnimationController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            controller.espectroAnimation();
            Destroy(this);
        }
    }
 }
