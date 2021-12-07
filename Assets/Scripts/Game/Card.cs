using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Card : MonoBehaviour
{
   
   [SerializeField] private GameObject elementPrefab;
   [SerializeField] private Spawner fieldSpawner;
   [SerializeField] private Spawner elementSpawner;

   private bool inField = false;
   private void OnEnable()
   {
      SpawnElement();
      SpawnField();
   }

   public void SpawnElement()
   {
      //elementSpawner.SpawnPrefab(elementPrefab);
      elementSpawner.SpawnRandomPrefab();
   }
   public void SpawnField()
   {
      if(!inField)fieldSpawner.SpawnRandomPrefab();
   }

   private void OnTriggerStay(Collider other)
   {
      inField = other.gameObject.GetComponent<Combination>() ? true : false;
   }
}
