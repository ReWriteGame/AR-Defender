using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private Elements typeElement;

    public Elements TypeElement { get => typeElement; }
}
