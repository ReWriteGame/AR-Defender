using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageLogic : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private ElementsGenerator elementsGenerator;
    [SerializeField] private ScoreCounter health;
    [SerializeField] private bool[] matchingElements;


    public void TakeDamage(Combination combination)
    {
        var weakElements = elementsGenerator.Elements.Select(x => x.GetComponent<Element>())
                                                     .OrderBy(x => x.ElementType);
        var incomingElements = combination.Elements.Select(x => x.GetComponent<Element>())
                                                   .OrderBy(x => x.ElementType);
        float damage = CompareCombinations(weakElements, incomingElements) * this.damage;
        health.TakeAway(damage);
    }

    private float CompareCombinations(IEnumerable<Element> comb1, IEnumerable<Element> comb2)
    {
        float result = 0;
        IEnumerable<Element> greaterCollection;
        IEnumerable<Element> lesserCollection;
        if (comb1.Count() >= comb2.Count())
        {
            greaterCollection = comb1;
            lesserCollection = comb2;
        }
        else
        {
            greaterCollection = comb2;
            lesserCollection = comb1;
        }
        var enumerator = greaterCollection.GetEnumerator();
        foreach (var item in lesserCollection)
        {
            enumerator.MoveNext();
            if (enumerator.Current.ElementType == item.ElementType)
            {
                result += 1f / lesserCollection.Count();
            }
        }
        return result;
    }

    // private void Awake()
    // {
    //     elementsGenerator = GetComponentInChildren<ElementsGenerator>();
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.GetComponent<Combination>())
    //     {
    //         List<GameObject> list = other.gameObject.GetComponent<Combination>().Elements;

    //         matchingElements = new bool[list.Count];
    //         for (int i = 0; i < matchingElements.Length; i++)
    //             matchingElements[i] = false;


    //         for (int i = 0; i < elementsGenerator.CurrentCombination.Length; i++)
    //         {
    //             for (int ii = 0; ii < list.Count; ii++)
    //             {
    //                 if (!matchingElements[ii])
    //                 {
    //                     if (elementsGenerator.CurrentCombination[i].GetComponent<Element>().TypeElement == list[ii].GetComponent<Element>().TypeElement)
    //                     {
    //                         matchingElements[ii] = true;
    //                         break;
    //                     }
    //                 }
    //             }

    //         }
    //     }
    // }
}
