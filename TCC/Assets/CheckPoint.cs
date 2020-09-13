using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject checkpoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            teleportToCheckPoint();
        }
    }

    private void teleportToCheckPoint()
    {
        this.transform.position = this.checkpoint.transform.position;
        this.transform.rotation = this.checkpoint.transform.rotation;
    }
}
