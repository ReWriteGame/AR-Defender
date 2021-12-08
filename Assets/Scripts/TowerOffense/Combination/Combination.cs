using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combination : MonoBehaviour
{
    [SerializeField] private List<GameObject> _elements = new List<GameObject>();
    public UnityEvent<GameObject> AddElementEvent;
    public UnityEvent<GameObject> RemoveElementEvent;

    public List<GameObject> Elements { get => _elements; }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Element>())
        {
            _elements.Add(other.gameObject);
            other.transform.parent = transform;
            AddElementEvent?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _elements.Remove(other.gameObject);
        RemoveElementEvent?.Invoke(other.gameObject);
    }
}
