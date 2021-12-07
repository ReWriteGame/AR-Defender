using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class Combination : MonoBehaviour
{
    public UnityEvent addElementEvent;
    public UnityEvent removeElementEvent;
    [SerializeField] private List<GameObject> _elements = new List<GameObject>();

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ElementA>() || other.gameObject.GetComponent<ElementB>())
        {
            _elements.Add(other.gameObject);
            other.transform.parent = transform;
            addElementEvent?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _elements.Remove(other.gameObject);
        removeElementEvent?.Invoke();
    }
}