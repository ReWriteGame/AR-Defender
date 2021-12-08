using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject elementPrefab;
    [SerializeField] private GameObject combinationPrefab;
    [SerializeField] private Spawner spawner;
    private bool inField = false;

    private void OnEnable()
    {
        SpawnElement();
        SpawnField();
    }

    public void SpawnElement()
    {
        spawner.SpawnPrefab(elementPrefab);
    }
    
    public void SpawnField()
    {
        if (!inField) spawner.SpawnPrefab(combinationPrefab);
    }

    private void OnTriggerStay(Collider other)
    {
        inField = other.gameObject.GetComponent<Combination>() ? true : false;
    }
}
