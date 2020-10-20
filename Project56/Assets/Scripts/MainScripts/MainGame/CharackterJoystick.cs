
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharackterJoystick : MonoBehaviour
{
    [Header("Позиции и уровени слоев ")]
    public Transform stopPos,upOrDownCheck;
 public LayerMask WhatUpPlatform,stop,WhatDownPlatform;
 [Header("Параметры движения")]
    public float speed = 12;
    public float _curSpeed { set; get; }
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Right();
    }

   public void Right()
   {
       _curSpeed = speed;
       transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);
     
   }

 public   void Left()
 {
     
     _curSpeed = -speed;
     transform.eulerAngles = new Vector3(0,-180,transform.eulerAngles.z);
    
 }

 private void FixedUpdate()
 {
#if UNITY_EDITOR
     if (Input.GetKey(KeyCode.LeftArrow))
     {
         Left();
     }
     if(Input.GetKey(KeyCode.RightArrow))
     {
        Right(); 
     }
#endif
     _rb.velocity = new Vector2(_curSpeed, _rb.velocity.y);
     
 }

 private void Update()
 {
     RotateUpOrDown();
     StopRotate();
 }

 void RotateUpOrDown()
 {
    bool findWhenInUpNeedRotate  = Physics2D.OverlapCircle(upOrDownCheck.position, 1f, WhatDownPlatform);
     bool findWhenInDownNeedRotate = Physics2D.OverlapCircle(upOrDownCheck.position, 1f, WhatUpPlatform);

     if (findWhenInUpNeedRotate)
     {
         if (_curSpeed > 0)
             transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -46f);
         else
         {
             transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 72f);
         }
     }
     if (findWhenInDownNeedRotate)
     {
         if (_curSpeed > 0)
             transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 72f);
         else
         {
             transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -46f);
             
         }
     }

     if (findWhenInDownNeedRotate == false && findWhenInUpNeedRotate == false)
     {
                  transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
     }
     

         
     
    
 }

 private void StopRotate()
 {
      bool  isStop  = Physics2D.OverlapCircle(stopPos.position, 1.5f, stop);
        if (isStop)
        {
            Right();
        }
 }

 }
