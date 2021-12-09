using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private Elements _typeElement;

    public Elements TypeElement { get => _typeElement; }
}
