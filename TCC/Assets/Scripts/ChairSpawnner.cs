﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChairSpawnner : MonoBehaviour
{
    [SerializeField] private GameObject chairPrefab;
    [SerializeField] private GameObject ChangeScenePorta;

    private bool hasTriggered;

    public UnityEvent chairInvoked;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.gameObject.CompareTag("Player"))
        {
            chairInvoked?.Invoke();
            StartCoroutine(invokeChair());
        }
    }

    private IEnumerator invokeChair()
    {
        yield return new WaitForSeconds(1f);
        GameObject chair = Instantiate(chairPrefab, transform.position, new Quaternion(0f, 0f, 0f, 0f));
        Rigidbody chairRigidbody = chair.GetComponent<Rigidbody>();
        chairRigidbody.AddForce(transform.forward * 40, ForceMode.Impulse);
        chairRigidbody.AddTorque(transform.up * 50, ForceMode.Impulse);
        chairRigidbody.AddTorque(transform.right * 50, ForceMode.Impulse);
        hasTriggered = true;
        ChangeScenePorta.GetComponent<ChangeSceneController>().enabled = true;
        Destroy(gameObject, 5f);
    }
}
