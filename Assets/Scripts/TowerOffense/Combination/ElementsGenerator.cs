using UnityEngine;
using System.Collections.Generic;

public class ElementsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] elementPrefabs;
    [SerializeField] private List<GameObject> currentCombination;
    [SerializeField] private Vector2Int range;

    public GameObject[] CurrentCombination { get => currentCombination.ToArray(); }


    public void SetRandomElements(int amount)
    {
        GenerateElements(amount);
    }

    public void SetRandomElements()
    {
        GenerateElements(Random.Range(range.x, range.y + 1));
    }

    private void GenerateElements(int size)
    {
        ClearCombination();
        for (int i = 0; i < size; i++)
        {
            var reference = elementPrefabs[Random.Range(0, elementPrefabs.Length)];
            var newElement = Object.Instantiate(reference,transform);
            currentCombination.Add(newElement);
        }
    }

    private void ClearCombination()
    {
        foreach (var item in currentCombination)
        {
            Destroy(item);
        }
        currentCombination.Clear();
    }
}
