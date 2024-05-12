using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInBus : MonoBehaviour
{
   public float money;
   public PickUp pickupSC;

    void Update()
    {
      print("Current Money: " + money);
    }

     public void OnTriggerEnter(Collider other)
     {
      if (other.gameObject.CompareTag("Pickable"))
      {
      ObjectVal script = other.gameObject.GetComponent<ObjectVal>();
       if (script != null && !pickupSC.dropped)
       {
                    money += script.MoneyWorth;
                    Debug.Log("Money added: " + script.MoneyWorth);
       }
      }
     }

     public void OnTriggerExit(Collider other)
     {
        if (other.gameObject.CompareTag("Pickable"))
        {
         ObjectVal script = other.gameObject.GetComponent<ObjectVal>();
          if (script != null)
          {
                    money -= script.MoneyWorth;
                    Debug.Log("Money subtracted: " + script.MoneyWorth);
                     // Reset the flag when the object exits the trigger
           }
        }
     }
}
