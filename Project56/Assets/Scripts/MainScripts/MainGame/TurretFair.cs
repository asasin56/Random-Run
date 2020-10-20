
using System;
using System.Collections;
using TigerForge;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurretFair : MonoBehaviour
{
    public float beforeShoot;
    public EPObjectPoolerScriptableObject laser;

    [SerializeField] private bool isInfLevel;
    
        public float afterShoot;
  //public GameObject laser;
 private GameObject player;
  [SerializeField] private Transform pointShoot;
    private void Start()
    {
player = GameObject.FindGameObjectWithTag("Player");

StartingLaserShooting();
    }

    IEnumerator LaserShoot(float waitSecond)
    {
        
        yield return new WaitForSeconds(waitSecond);
        
        if (transform.position.x + afterShoot > player.transform.position.x && transform.position.x - beforeShoot < player.transform.position.x)
        {
         //   Instantiate(laser, pointShoot.transform.position, Quaternion.identity);
        GameObject newLaser = laser.GetObject();
        newLaser.transform.position = pointShoot.position;

        }

        StartingLaserShooting();
    }

    void StartingLaserShooting()
    {
        float GetRandomSec = Random.Range(0.4f, 0.9f);
        StartCoroutine(LaserShoot(GetRandomSec));
    }

    private void Update()
    {
        if (isInfLevel)
        {
                  DeleteIfNoUse();
        }
  
        
    }

    void DeleteIfNoUse()
    {
        if (player.transform.position.x- 40f > gameObject.transform.position.x)
        {
     Destroy(gameObject);
        //  ManagerPool.Instance.Despawn(PoolType.Entities,gameObject);
        }
       
    }
}
