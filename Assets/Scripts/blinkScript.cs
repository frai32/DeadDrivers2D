using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkScript : MonoBehaviour
{
    public int health = 4;
    private AudioSource m_ExplosionAudio;
    private Material matBlink;
    private Material matDefoult;
    private SpriteRenderer sprRend;

    // Start is called before the first frame update
    void Start()
    {
        m_ExplosionAudio = GetComponent<AudioSource>();
        sprRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material) ) as Material;
        matDefoult = sprRend.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bolt"))
        {
            
            Destroy(collision.gameObject);
            makeBlink();
        }
    }

    void makeBlink()
    {
        m_ExplosionAudio.Play();
        health--;
        sprRend.material = matBlink;
        if(health<=0)
        {
           KillEnemy();

        }
        else
        {
               
           Invoke("ResetMaterial", .1f);

        }

    }
    void ResetMaterial()
    {
        sprRend.material = matDefoult;
    }


    void KillEnemy()
    {
        Destroy(gameObject,0.3f);
    }
}
