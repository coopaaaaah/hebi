using System;
using UnityEngine;

public class Border : MonoBehaviour
{
   public LogicManager logicManager;

   void Start()
   {
      logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      logicManager.ReverseDirection(other.gameObject.GetComponent<Hebi>());
   }
}
