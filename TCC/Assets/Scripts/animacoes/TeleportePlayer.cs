using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] player;
    void Start()
    {
        this.player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
