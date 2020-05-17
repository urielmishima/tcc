using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarEvent : MonoBehaviour
{
    private bool hasHappened = false;

    public UnityEvent StartAlarm;
    public UnityEvent StopAlarm;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasHappened && other.gameObject.CompareTag("Player"))
        {
            hasHappened = true;
            StartCoroutine(CarAlarmEvent());
        }
       
    }

    private IEnumerator CarAlarmEvent()
    {
        StartAlarm?.Invoke();
        yield return new WaitForSeconds(60f);
        StopAlarm?.Invoke();
        Destroy(gameObject, 1f);
    }
}
