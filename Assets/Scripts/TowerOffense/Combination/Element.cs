using UnityEngine;

public abstract class Element : MonoBehaviour
{
    private bool _isCombinated;
    private int _callCount;
    

    private void OnTriggerEnter(Collider other)
    {
        if (!_isCombinated)
        {
            var combination = other.GetComponent<Combination>();
            if (combination != null)
            {
             
                _isCombinated = true;
                return;
            }
            _isCombinated = true;
        }
    }
}
