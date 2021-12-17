using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    public UnityEvent<Combination> TakeDamageEvent;
    

    private void Start()
    {
        SetTargetInvent.AddListener(x => x.Target = transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Combination>())
        {
            TakeDamageEvent?.Invoke(other.GetComponent<Combination>());
        }
    }
}