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
           
            collision.GetComponent<health>().TakeDamage();
            OnDeath();
            StartCoroutine(playDeathByPlayer());
            if (localControl.armorText.gameObject.activeSelf)
            {
                localControl.armorText.gameObject.SetActive(false);
            }

            if (collision.GetComponent<health>().getCurrentHealth()<=0)
            {
                localControl.GameOver();
            }
        }

        if (collision.CompareTag("Bolt"))
        {
            Destroy(collision.gameObject);
            OnDeath();
           
            StartCoroutine(playDeathBolt());

        }    
    }

    private void OnDeath()
    {
        GetComponent<mover>().setSpeed(0);
        GetComponent<CapsuleCollider2D>().enabled = false;
        // Set the flag so that this function is only called once.
        localControl.AddScore(10);
        anim.SetBool("isDead", true);
       
        // Play the tank explosion sound effect.
        // m_ExplosionAudio.Play();
    }

    IEnumerator playDeathBolt()
    {
        yield return new WaitForSeconds(0.3f);
        
        Destroy(gameObject);
        

    }

    IEnumerator playDeathByPlayer()
    {
        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);
    }
}
