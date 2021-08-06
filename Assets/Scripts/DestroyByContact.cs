﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    GameController localControl;
    private AudioSource m_ExplosionAudio;

    Animator anim;
    public int scoreValue;

  
    
    private void Awake()
    {
        anim = GetComponent<Animator>();

        m_ExplosionAudio = GetComponent<AudioSource>();
    }


    private void Start()
    {
        GameObject gameControll = GameObject.FindGameObjectWithTag("GameController");
        if(gameControll != null)
        {
            localControl = gameControll.GetComponent<GameController>();
        }

        if(gameControll == null)
        {
            Debug.LogError("GameController is missed");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Baundary"))
            return;

        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<health>().TakeDamage();
            OnDeath();
            StartCoroutine(playDeath());
          
        }

        if (collision.CompareTag("Bolt"))
        {
            Destroy(collision.gameObject);
            OnDeath();
           
            StartCoroutine(playDeath());
        }    
    }


    private void OnDeath()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        
        localControl.AddScore(10);
        
        anim.SetBool("isDead", true);
        
        m_ExplosionAudio.Play();
    }

    IEnumerator playDeath()
    {
        yield return new WaitForSeconds(0.3f);
    
        Destroy(gameObject);       
    }

}
