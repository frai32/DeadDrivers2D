using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int scoreValue;

    private GameController localControl;
    private AudioSource m_ExplosionAudio;

    private Animator anim;

    private Tags t;
  
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        t = new Tags();
        m_ExplosionAudio = GetComponent<AudioSource>();
    }


    private void Start()
    {
        //GameObject gameControll = GameObject.FindGameObjectWithTag("GameController");
        GameObject gameControll = GameObject.FindGameObjectWithTag(t.getTagList[(int)ETags.GAME_CONTROLLER_TAG]);
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
        //if (collision.CompareTag("Baundary"))
        if (collision.CompareTag(t.getTagList[(int)ETags.BAUNDARY_TAG]))
            return;

        //if(collision.CompareTag("Player"))
        if (collision.CompareTag(t.getTagList[(int)ETags.PLAYER_TAG]))
        {
            collision.GetComponent<health>().TakeDamage();
            OnDeath();
            StartCoroutine(playDeath());
          
        }

       // if (collision.CompareTag("Bolt"))
        if (collision.CompareTag(t.getTagList[(int)ETags.BOLT_TAG]))
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
