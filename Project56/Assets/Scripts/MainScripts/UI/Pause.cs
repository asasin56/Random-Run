using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panAct;
    public AudioSource winmus;
  public  void BackInmenu()
  {
    SceneManager.LoadScene("Menu");
  }

 public void Back()
  {
    panAct.SetActive(false);
    Time.timeScale = 1;
    winmus.UnPause();
  }

 public void StartPause()
 {
     panAct.SetActive(!panAct.activeSelf);
     if (panAct.activeSelf == true)
     {
         Time.timeScale = 0;
         winmus.Pause();
     }
     else
     {
         Time.timeScale = 1;
         winmus.UnPause();
     }
 }
}
