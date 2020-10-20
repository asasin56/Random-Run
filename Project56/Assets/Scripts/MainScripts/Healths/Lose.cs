using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public GameObject dethPan;
    public Transform spawnPos;
    private MusicStart _start;
    private HelthEdit playerHelth;
    public bool isInfLevel = false;
    public float dethPos = 34;
  [SerializeField]  private GameObject[] UI;

private HelthDisplay Display;
// Start is called before the first frame update
    private void Start()
    {

        Display = gameObject.GetComponent<HelthDisplay>();
        playerHelth = gameObject.GetComponent<HelthEdit>();
        _start = gameObject.GetComponent<MusicStart>();
        Application.targetFrameRate = 60;

        Time.timeScale = 1;
    }

    public void LoseScreen()
    {
        Time.timeScale = 0;
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(!UI[i].activeSelf);
        }
dethPan.SetActive(!dethPan.activeSelf);
    }

   public void Restart()
    {
                if (isInfLevel)
                {
                SceneManager.LoadScene("NatureLevel");
                
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.sceneCount + 1);

                    /*
                                transform.position = spawnPos.position;
                                playerHelth.Heal(playerHelth.GetPlayerChooseInMenu());
                                Display.ActiveHeart();
                                _start.MainMusic.Stop();
                                _start.MainMusic.Play();
                                */
                }
    }
   /*public  void RestartLevel()
   {
       transform.position = spawnPos.position;
       
}

 */  
 


     private void Update()
     { 
         if (transform.position.y < dethPos)
         {
             LoseScreen();
         }
     }

     
    

}
