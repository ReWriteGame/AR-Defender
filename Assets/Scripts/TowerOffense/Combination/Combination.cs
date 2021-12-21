using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combination : MonoBehaviour
{
    [SerializeField] private List<GameObject> _elements = new List<GameObject>();
    public UnityEvent<GameObject> AddElementEvent;
    public UnityEvent<GameObject> RemoveElementEvent;
    public UnityEvent ClearEvent;

    public GameObject[] Elements { get => _elements.ToArray(); }


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

    public void Clear()
    {
        _elements.Clear();
        ClearEvent?.Invoke();
        transform.position = Vector3.zero;
    }
}
