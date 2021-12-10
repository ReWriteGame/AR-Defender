using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    public UnityEvent<Combination> getDamageEvent;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Combination>())
        {
            getDamageEvent?.Invoke(other.GetComponent<Combination>());
        }
    }
}