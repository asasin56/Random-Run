using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OptimizateRandom : MonoBehaviour
{
    private UnityEvent oneThousendUnit; 
    public GameObject player;

    private void Start()
    {
        oneThousendUnit.AddListener(teleport);
    }

    private void teleport()
    {
        player.transform.position = new Vector3(transform.position.x - 1000,transform.position.y);
        GameObject[] chunks = GameObject.FindGameObjectsWithTag("Chunk");
        foreach (var VARIABLE in chunks)
        {
            VARIABLE.transform.position = new Vector3(VARIABLE.transform.position.x - 1000, transform.position.y);
        }
    }

    private void Update()
    {
        if (player.transform.position.x > 1000)
        {
            
        }

        if (player.transform.position.y > 1000)
        {
            
        }

        if (transform.position.y < -1000)
        {
            
        }
    }

  
}
