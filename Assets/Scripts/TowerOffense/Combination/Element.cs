using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private Elements _typeElement;

    public Elements ElementType { get => _typeElement; }
}
