using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
   public bool SteppedOn;

   public void Stepped()
   {
       if(!SteppedOn)
       {

           SteppedOn = true;
           Debug.Log("PressurePlate stepped on trigger door/trap");
       }
   }
}
