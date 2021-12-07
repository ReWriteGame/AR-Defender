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

    public List<GameObject> Elements
    {
        get => _elements;
    }

    
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
        GameObject obj = other.gameObject;
        _elements.Remove(other.gameObject);
        //other.transform.position = 
        //other.transform.parent = null;
        obj.transform.parent = null;
        //obj.transform.position = transform.TransformPoint( Vector3.zero );;
        removeElementEvent?.Invoke();
    }
}