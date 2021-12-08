using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private Enumerations.Elements element;

    public Enumerations.Elements TypeElement { get => element; private set => element = value;}

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
