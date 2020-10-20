using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserVerticalFly : MonoBehaviour
{
 
 public Rigidbody2D rb;
 private HelthEdit HelthEdit;
 private GameObject player;
 public float speedX;
 public float speedY;

 
  //public AudioSource laserDestoing;


 private void Start()
 {
  
  //_laserDestoing = gameObject.GetComponent<AudioSource>();
  player = GameObject.FindGameObjectWithTag("Player");
    HelthEdit = player.GetComponent<HelthEdit>();

 }

 private void FixedUpdate()
 {

  if (speedX < -1)
  {
   transform.eulerAngles = new Vector3(0,0,90);
  }

  rb.velocity = new Vector2(speedX,speedY );


 }

 private void OnTriggerEnter2D(Collider2D other)
 {  
  if (other.tag == "Player")
  {

   HelthEdit.TakeDamage(1f);
  }

 if (other.isTrigger != true || other.tag == "EditorOnly")
  { 
 
gameObject.SetActive(false);
  }

 }



}
