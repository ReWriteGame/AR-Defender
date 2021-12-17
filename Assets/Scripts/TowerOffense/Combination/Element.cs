using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private ElementType _typeElement;

    public ElementType ElementType { get => _typeElement; }
}
