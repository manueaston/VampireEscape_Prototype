using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateController : MonoBehaviour
{
   public bool SteppedOn;
   public UnityEvent LinkedObject;

   public void Stepped()
   {
       if(!SteppedOn)
       {

           SteppedOn = true;
           Debug.Log("PressurePlate stepped on trigger door/trap");
           LinkedObject.Invoke();
       }
   }
}
