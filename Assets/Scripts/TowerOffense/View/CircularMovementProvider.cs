using System.Collections.Generic;
using UnityEngine;

public class CircularMovementProvider : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects = new List<GameObject>();
    [SerializeField] private float _peroid;
    [SerializeField] private float _radiusX;
    [SerializeField] private float _radiusZ;
    [SerializeField] private bool _isActivated = true;
    private float _progress;
    private const float Pix2 = 6.28318f;


    private void Update()
    {
        if (_isActivated)
        {
            MoveCirculary();
        }
    }

    private void MoveCirculary()
    {
        _progress += Time.deltaTime * (Pix2 / _peroid);
        if (_progress > Pix2)
        {
            _progress = Pix2;
        }
        var phase = Pix2 / _objects.Count;
        for (int i = 0; i < _objects.Count; i++)
        {
            var radiusX = Mathf.Cos(_progress + phase * i) * _radiusX;
            var radiusZ = Mathf.Sin(_progress + phase * i) * _radiusZ;
            var position = _objects[i].transform.position;
            position.x = transform.position.x + radiusX;
            position.z = transform.position.z + radiusZ;
            position.y = transform.position.y;
            _objects[i].transform.position = position;
        }
        if (_progress == Pix2)
        {
            _progress = 0;
        }
    }

    public void AddObjects(params GameObject[] objects)
    {
        foreach (var item in objects)
        {
            AddObject(item);
        }
    }

    public void AddObject(GameObject obj)
    {
        if (!_objects.Contains(obj))
        {
            _objects.Add(obj);
        }
    }

    public void RemoveObject(GameObject obj)
    {
        _objects.Remove(obj);
    }

    public void Clear()
    {
        _objects.Clear();
    }

    public void Activate()
    {
        _isActivated = true;
    }

    public void Deactivate()
    {
        _isActivated = false;
    }
}
