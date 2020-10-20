using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
   
    //public AudioSource WinMusic;
   // public AudioSource MusicGame;
 //   public GameObject WinPanel;
    public float WinPos;
 //   public GameObject Joystick;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
       // int i = DidicultMenu.sceneLoadnMain + 1;
        
      //  Master.audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("musControl"));
        /*
        if ()
      {
            MusicGame.volume = 1;
           WinMusic.volume = 1;
        }
      else
        {
            MusicGame.volume = 0;
            WinMusic.volume = 0;
        }
        */
        if (transform.position.x >= WinPos )
        {
            if (SceneManager.sceneCountInBuildSettings > 1)
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings);
            }
          //  SceneManager.LoadScene(DidicultMenu.sceneLoadnMain + 1);  
            
            // MusicGame.volume = 0;
            // WinMusic.PlayOneShot(WinMusic.clip);
            //   Time.timeScale = 0;
            // Destroy(Joystick);
            //    WinPanel.SetActive(true);
        }
    }
}
