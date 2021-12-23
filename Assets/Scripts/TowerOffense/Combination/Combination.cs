using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combination : MonoBehaviour
{
    [SerializeField] private List<GameObject> _elements = new List<GameObject>();
    public UnityEvent<GameObject> AddElementEvent;
    public UnityEvent ClearEvent;

    public GameObject[] Elements { get => _elements.ToArray(); }


    public void Add(GameObject element)
    {
        var copy = Object.Instantiate(element);
        copy.transform.parent = transform.parent;
        copy.transform.localPosition = Vector3.zero;
        _elements.Add(copy);
        AddElementEvent?.Invoke(copy);
    }

    public void Clear()
    {
        foreach (var item in _elements)
        {
            Object.Destroy(item);
        }
        _elements.Clear();
        ClearEvent?.Invoke();
    }
}
