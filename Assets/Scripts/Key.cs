using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (!other.CompareTag("Player")) return;
      
      GameManager.Instance.OnKeyCollection();
      Destroy(gameObject);
   }
}
