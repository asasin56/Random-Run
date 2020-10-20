using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour
{
    public AudioSource MainMusic;

    public HelthEdit health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HelthEdit>();
        MainMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.GetHelth() == 0)
        {
            MainMusic.Stop();
           // MainMusic.Play();
        }
    }
}
