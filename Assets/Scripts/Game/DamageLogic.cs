using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLogic : MonoBehaviour
{
    [SerializeField]private ElementsGenerator elementsGenerator;
    [SerializeField]private ScoreCounter health;

    [SerializeField] private bool[] matchingElements;
   
   
    private void Awake()
    {
        elementsGenerator = GetComponentInChildren<ElementsGenerator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Combination>())
        {
            List < GameObject > list = other.gameObject.GetComponent<Combination>().Elements;
         
            matchingElements = new bool[list.Count];
            for (int i = 0; i < matchingElements.Length; i++)
                matchingElements[i] = false;
         

            for (int i = 0; i < elementsGenerator.CurrentCombination.Length; i++)
            {
                for (int ii = 0; ii < list.Count; ii++)
                {
                    if (!matchingElements[ii])
                    {
                        if (elementsGenerator.CurrentCombination[i].GetComponent<Element>().TypeElement == list[ii].GetComponent<Element>().TypeElement)
                        {
                            matchingElements[ii] = true;
                            break;
                        }
                    }
                }
           
            }
        }
    }
}
