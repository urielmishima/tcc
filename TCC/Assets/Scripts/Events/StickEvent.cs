using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickEvent : MonoBehaviour
{

    [SerializeField] private GameObject stickPrefab;

    private bool hasTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasTriggered)
        {
            GameObject stick = Instantiate(stickPrefab);
            Rigidbody rigidbody = stick.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.right * 10, ForceMode.Impulse);
            rigidbody.AddTorque(transform.up * 50, ForceMode.Impulse);
            rigidbody.AddTorque(transform.right * 50, ForceMode.Impulse);
            hasTriggered = true;
        }
    }

}
