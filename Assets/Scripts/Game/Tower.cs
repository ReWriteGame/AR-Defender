using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
   [SerializeField]private ElementsGenerator elementsGenerator;

   public UnityEvent getDamageEvent;
   
   private void Awake()
   {
      elementsGenerator = GetComponentInChildren<ElementsGenerator>();
   }

   private void OnCollisionEnter(Collision other)
   {
     // if(other.gameObject.GetComponent<Combination>())
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.GetComponent<Combination>())
      {
         getDamageEvent?.Invoke();
        // if(other.gameObject.GetComponent<Combination>().Elements)
      }
   }
}
