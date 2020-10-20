using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform Charackter;
    public Transform Barier;

    public bool isInfLevel;

// Update is called once per frame
    void Update()
    {
 float X = transform.position.x;
            
                 transform.position = new Vector3(0, 1.5f, -10) + Charackter.transform.position;
                 WithBarier(X);
       
    }

    void WithBarier(float X)
    {      
                 Barier.transform.position = new Vector3();
                        
                     //    transform.LookAt(Charackter.transform);
                         if (transform.position.x < Barier.position.x)
                         {
                             transform.position = new  Vector3(X,1.5f + Charackter.transform.position.y,-10 + Charackter.transform.position.z);
                         }
                                  if (transform.position.x < X && isInfLevel)
                                     {
                                         transform.position = new  Vector3(X,1.5f + Charackter.transform.position.y,-10 + Charackter.transform.position.z);
                                     }
    }
    
}
