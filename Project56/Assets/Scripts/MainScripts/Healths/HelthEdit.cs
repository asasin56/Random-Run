using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HelthEdit : MonoBehaviour
{
   private float _health = 0;
   private float GetPlayerChoose = 0;
   
    public Lose _lose;
    public UnityEvent<float> OnHealthChange;


    private void Start()
    {
     
        GetPlayerChoose = PlayerPrefs.GetFloat("Health");
        _health = GetPlayerChoose;
        
        //    anim = GetComponent<Animator>();
    }

    public float GetPlayerChooseInMenu()
    {
        return GetPlayerChoose;
    }

    public float GetHelth()
    {
        return _health;
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
   //     anim.SetTrigger("GetDamage");
        OnHealthChange.Invoke(_health);
        if (_health <= 0)
        {
       _lose.LoseScreen();
        }
        
    }

    public void Heal(float health)
    {
        _health = health;
    }


}
