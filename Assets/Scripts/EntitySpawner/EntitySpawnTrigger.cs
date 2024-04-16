using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntitySpawnTrigger : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnTriggerEvent;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTriggerEvent.Invoke();
        }
    }
}
