using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageLogic : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private ElementsGenerator _elementsGenerator;
    [SerializeField] private ScoreCounter _health;
    //[SerializeField] private bool[] matchingElements;


    public void TakeDamage(Combination combination)
    {
        var weakElements = _elementsGenerator.Elements.Select(x => x.GetComponent<Element>().ElementType)
                                                     .OrderBy(x => x);
        var incomingElements = combination.Elements.Select(x => x.GetComponent<Element>().ElementType)
                                                   .OrderBy(x => x);
        float damage = CompareCombinations(weakElements, incomingElements) * _damage;
        _health.TakeAway(damage);
    }

    // Сравнивает коллекции и возвращает % схожести от 0 до 1
    private float CompareCombinations(IEnumerable<ElementType> comb1, IEnumerable<ElementType> comb2)
    {
        float result = 0;
        var greaterCollection = comb1.Count() >= comb2.Count() ? comb1 : comb2;
        var lesserCollection = comb1.Count() < comb2.Count() ? comb1 : comb2;
        lesserCollection = CompleteCollection(lesserCollection, greaterCollection.Count(), ElementType.None);
        var e1 = greaterCollection.GetEnumerator();
        var e2 = lesserCollection.GetEnumerator();
        for (; e1.MoveNext() && e2.MoveNext();)
        {
            if (e1.Current == e2.Current)
            {
                result += 1f / lesserCollection.Count();
            }
        }
        return result;
    }

    // Увеличивает source до targetSize и заполняет пустые места value
    private IEnumerable<T> CompleteCollection<T>(IEnumerable<T> source, int targetSize, T value)
    {
        var result = new T[targetSize];
        int i = 0;
        foreach (var item in source)
        {
            if (i < result.Length)
            {
                result[i++] = item;
            }
        }
        for (; i < result.Length; i++)
        {
            result[i] = value;
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
