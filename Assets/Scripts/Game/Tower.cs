using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    public UnityEvent<Combination> GetDamageEvent;
    

    private void Start()
    {
        SetTargetInvent.AddListener(SetTarget);
    }

    private void SetTarget(DirectMovementProvider provider)
    {
        provider.Target = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Combination>())
        {
            GetDamageEvent?.Invoke(other.GetComponent<Combination>());
        }
    }
}