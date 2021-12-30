using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class ElementsGenerator : MonoBehaviour
{
    public UnityEvent<GameObject[]> OnCombinationChange;
    public UnityEvent OnCombinationClear;
    [SerializeField] private GameObject[] _elementPrefabs;
    [SerializeField] private List<GameObject> _currentCombination;
    [SerializeField] private Vector2Int _range;
    [SerializeField] private float _interval;
    private float _passedTime;
    
    public GameObject[] Elements { get => _currentCombination.ToArray(); }


    private void Update()
    {
        _passedTime += Time.deltaTime;
        if (_passedTime >= _interval)
        {
            SetRandomElements();
        }
    }

    public void SetRandomElements(int amount)
    {
        GenerateElements(amount);
    }

    public void SetRandomElements()
    {
        GenerateElements(Random.Range(_range.x, _range.y + 1));
    }

    private void GenerateElements(int size)
    {
        ClearCombination();
        for (int i = 0; i < size; i++)
        {
            var reference = _elementPrefabs[Random.Range(0, _elementPrefabs.Length)];
            var newElement = Object.Instantiate(reference, transform.parent);
            newElement.transform.localPosition = Vector3.zero;
            // Костыли!!!
            var collider = newElement.GetComponent<Collider>();
            Object.Destroy(collider);

            _currentCombination.Add(newElement);
        }
        OnCombinationChange?.Invoke(Elements);

        _passedTime = 0;
    }

    private void ClearCombination()
    {
        OnCombinationClear?.Invoke();
        foreach (var item in _currentCombination)
        {
            Destroy(item);
        }
        _currentCombination.Clear();
    }
}
