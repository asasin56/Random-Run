using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DidicultMenu : MonoBehaviour
{
    public GameObject NonUseButton;
    public GameObject UseButton;
   public GameObject LoadScreen;
    public GameObject DifPan;
    private static int sceneLoadNeed = 0;
    public int sceneNowLoad;
        private float TransHealth;
  public void OpenDificultMenu(int scene)
   {
       DifPan.SetActive(!DifPan.activeSelf);
       NonUseButton.SetActive(!NonUseButton.activeSelf);
       UseButton.SetActive(!UseButton.activeSelf);
       sceneLoadNeed = scene;
      


   }

 public void StartWithDificult(float dif)
  {
      TransHealth = dif; 
      PlayerPrefs.SetFloat("Health",TransHealth);


     LoadScreen.SetActive(true);
     if (sceneLoadNeed  == 0)
     {
         SceneManager.LoadScene(sceneLoadNeed + 1);
     }

     else
     {
         SceneManager.LoadScene(sceneLoadNeed); 
     }
     
         
     
     
     sceneLoadNeed = 0;


  }





 


  
}
