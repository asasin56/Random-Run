using System;
using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
  //publics
  public EPObjectPoolerScriptableObject tur;
 public bool isNotTurretChunk = false;
    public Transform Begin;
    public Transform End;
private GameObject player;
    public GameObject turret;

    public Transform turretSpawnPos;
    //privates

  private float newTurretPos = 0;

  private void Start()
  {
      player = GameObject.Find("idle_000");
     // ManagerPool.Instance.AddPool(PoolType.Entities);
  }

  public void TurretSpawn()
    {
      Instantiate(turret,new Vector3(Random.Range(Begin.position.x + 1 ,End.position.x),turretSpawnPos.position.y),Quaternion.identity);
 
     
        newTurretPos = turret.transform.position.x;
       

    }

    private void Update()
    {
        if (player.transform.position.x - 30  > End.position.x ) 
       {
            Destroy(gameObject);
       }
    }
}
