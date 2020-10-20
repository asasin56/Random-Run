using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthDisplay : MonoBehaviour
{
    public GameObject[] heart;
    public HelthEdit _helthEdit;



    private void Start()
    {

   DisableHeart(_helthEdit.GetHelth());


            _helthEdit.OnHealthChange.AddListener((helth) =>
            {

                float heltha = _helthEdit.GetHelth();
                /*
                if (heart[3].activeSelf == true && heltha == 3)
                {
                        heart[3].SetActive(false);
                }
                
                    heart[4].SetActive(false);
                    */


                for (int b = 0; b < heart.Length; b++)
                {
                    if (b > helth - 1)
                    {
                        heart[b].SetActive(false);
                    }
                }
            });
        }

   private void DisableHeart(float healthing)
    {

                if (heart.Length > healthing)
                {
                    for (int i = 0; i < heart.Length; i++)
                    {
                        if (i > PlayerPrefs.GetFloat("Health") - 1 ) 
                        {
                            heart[i].SetActive(false);
                        }
                  
                    }
                }

                

    }

   public void ActiveHeart()
   {

       for (int i = 0; i < heart.Length; i++)
       {
           heart[i].SetActive(true);
       DisableHeart(_helthEdit.GetHelth());
      /* if (_helthEdit.GetHelth() >= 1)
           {
                  heart[0].SetActive(true);
           }

       if (_helthEdit.GetHelth() >= 2)
       {
           heart[1].SetActive(true);
       }

       if (_helthEdit.GetHelth() >= 3)
       {
           heart[2].SetActive(true);
       }

       if (_helthEdit.GetHelth() >= 4)
       {
              heart[3].SetActive(true);
       }

       if (_helthEdit.GetHelth() >= 5)
       {
                    heart[4].SetActive(true);
       }
       
       {
  */
        
       }
      //    DisableHeart(_helthEdit.GetHelth());
       
   }

    }


