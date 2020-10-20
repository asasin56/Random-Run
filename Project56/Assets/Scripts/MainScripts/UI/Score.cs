using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Score : MonoBehaviour
{
    [SerializeField]private Transform ScoreObj;
  [SerializeField]  private Transform player;
  [SerializeField] private Text txt;

    private void FixedUpdate()
    {
        if (ScoreObj.position.x > player.position.x)
        {
            ScoreObj.position = ScoreObj.position; 
        
        }
        else
        {
            ScoreObj.position = player.position;
        }
    txt.text = (int)ScoreObj.position.x + "m";
    if ((int)ScoreObj.position.x > /*Records.record*/ PlayerPrefs.GetFloat("Record"))
    {
       // Records.record = (int)ScoreObj.position.x;
       PlayerPrefs.SetFloat("Record",(int)ScoreObj.position.x);
    }  
    }
    
}
