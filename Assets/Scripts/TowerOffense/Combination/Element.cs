using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private Enumerations.Elements typeElement;

    public Enumerations.Elements TypeElement { get => typeElement; }
}
