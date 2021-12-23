using UnityEngine;

public class DirectMovementProvider : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _velocity;
    [SerializeField] private bool _isActivated;

    public Transform Target { get => _target; set => _target = value; }

    
    private void Update()
    {
        if (_isActivated)
        {
            Move();
        }
    }

    private void Move()
    {
        var destination = _target.transform.position;
        var distance = (destination - transform.position).magnitude;
        var direction = (destination - transform.position).normalized;
        var delta = (Time.deltaTime * _velocity * direction).magnitude;
        if (delta >= distance)
        {
            transform.position = destination;
            return;
        }
        transform.Translate(Time.deltaTime * _velocity * direction);
    }

    public void Activate()
    {
        _isActivated = true;
    }

    public void Deactivate()
    {
        _isActivated = false;
    }

    public void Reset()
    {
        _isActivated = false;
        transform.localPosition = Vector3.zero;
    }
}
