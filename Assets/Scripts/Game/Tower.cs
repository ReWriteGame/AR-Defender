using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    public UnityEvent getDamageEvent;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Combination>())
        {
            getDamageEvent?.Invoke();
        }
    }
}