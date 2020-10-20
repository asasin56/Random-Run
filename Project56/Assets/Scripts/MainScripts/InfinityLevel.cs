using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InfinityLevel : MonoBehaviour
{
    

    public GameObject Player;
    private CharackterJoystick _charackter;
    public Transform Lags;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;
    public GameObject Camera;
    private Lose lose;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    
    
    private MoreSpeedAndTurret plus;


    private void Start()
    {
        plus = FindObjectOfType<MoreSpeedAndTurret>();
        spawnedChunks.Add(FirstChunk);
        lose = Player.GetComponent<Lose>();
        _charackter = Player.GetComponent<CharackterJoystick>();

    }

    private void Update()
    {
        if (Player.transform.position.x > spawnedChunks[spawnedChunks.Count - 1].End.position.x - 50)
        {
            SpawnChunk();
        }




    }

        private void SpawnChunk()
        {
            //    Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);

            Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);

            newChunk.transform.position =
                spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            if (newChunk.isNotTurretChunk == false)
            {
                float ranCount = Random.Range(0, 5);
                _charackter.speed = plus.GetMore(_charackter.speed, 0.5f);
                _charackter._curSpeed = _charackter.speed;
                if (ranCount > 1)
                {
                    newChunk.TurretSpawn();
                }
            }

            lose.dethPos = newChunk.transform.position.y - 60;
            spawnedChunks.Add(newChunk);


        }

   

    }

