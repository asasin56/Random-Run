using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
   
    public GameObject LevPan;
    public GameObject[] Buttons;

    private void Start()
    {
        Application.targetFrameRate = 20;
    }

    public  void StartFirstLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

   public void ActivePanelLevel()
    {
       
        
        for (int i = 0; i <Buttons.Length; i++)
        {
            Buttons[i].SetActive(!Buttons[i].activeSelf);
          //  LevPan.SetActive(true);
        }
        
    }



  

 
   
   
}
