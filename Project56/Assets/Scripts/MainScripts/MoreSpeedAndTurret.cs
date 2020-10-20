using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreSpeedAndTurret : MonoBehaviour
{
        static  float needPos = 100;
  public  float GetMore(float currentCount,float plus)
  {

        if (transform.position.x > needPos)
        {
        
                if (currentCount < 20)
                                           {
                                               currentCount += plus;
                                                           needPos += 100f;
                                           }
Debug.Log(currentCount + "N" + needPos );
        }
        return currentCount;
    }

   

}
