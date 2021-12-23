using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject elementPrefab;
    public UnityEvent<GameObject> OnFound;
    

    public void SpawnElement()
    {
        OnFound?.Invoke(elementPrefab);
    }
}
