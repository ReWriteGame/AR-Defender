using UnityEngine;

public class DirectMovementProvider : MonoBehaviour
{
    [SerializeField] private Vector3 _destionation;
    [SerializeField] private float _velocity;
    [SerializeField] private bool _isActivated;


    private void Update()
    {
        if (_isActivated)
        {
            Move();
        }
    }

    private void Move()
    {
        var distance = (_destionation - transform.position).magnitude;
        var direction = (_destionation - transform.position).normalized;
        var delta = (Time.deltaTime * _velocity * direction).magnitude;
        if (delta >= distance)
        {
            transform.position = _destionation;
            return;
        }
        transform.Translate(Time.deltaTime * _velocity * direction);
    }
}
