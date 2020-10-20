using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Records : MonoBehaviour
{
    public static int record = 0;
    public Text recordDisplay;

    private void Start()
    {
      
        //if (PlayerPrefs.GetFloat("Record") < record)
       //{
         //        PlayerPrefs.SetFloat("Record",record); 
       // }   
   recordDisplay.text = "Your best distance " + PlayerPrefs.GetFloat("Record") + "m";
       
    }
}
