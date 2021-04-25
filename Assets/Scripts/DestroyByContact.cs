using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    GameController localControl;
    Animator anim;
    public int scoreValue;

  
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
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
           
            collision.GetComponent<health>().TakeDamage(10);
            OnDeath();
            StartCoroutine(playDeathByPlayer());
            
            if(collision.GetComponent<health>().getCurrentHealth()<=0)
            {
                localControl.GameOver();
            }
        }

        if (collision.CompareTag("Bolt"))
        {
            OnDeath();
            StartCoroutine(playDeathBolt(collision));
        }    
    }

    private void OnDeath()
    {
        GetComponent<mover>().setSpeed(0);

        // Set the flag so that this function is only called once.
        localControl.AddScore(10);
        anim.SetBool("isDead", true);

        Debug.Log(anim.GetBool("isDead"));
        // Play the tank explosion sound effect.
        // m_ExplosionAudio.Play();
    }

    IEnumerator playDeathBolt(Collider2D other)
    {
        yield return new WaitForSeconds(0.3f);
        
        Destroy(gameObject);
        Destroy(other.gameObject);

    }

    IEnumerator playDeathByPlayer()
    {
        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);
    }
}
