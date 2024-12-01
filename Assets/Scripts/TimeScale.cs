using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
   private void Awake()
   {
      Time.timeScale = 1;
   }

   public void TimeScaleUp()
   {
      Time.timeScale = 0;
   }
}
