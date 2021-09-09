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
    private SpawnShooters parent;
    private Animator anim;
    private Tags t;

    public void setParent(SpawnShooters Parent)
    {
        parent = Parent;
    }

    // Start is called before the first frame update
    void Start()
    {
        t = new Tags();
        anim = GetComponent<Animator>();
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
        //if(collision.CompareTag("Bolt"))
        if (collision.CompareTag(t.getTagList[(int)ETags.BOLT_TAG]))
        {
            Destroy(collision.gameObject);
            makeBlink();
        }

        if (collision.CompareTag(t.getTagList[(int)ETags.PLAYER_TAG]) && !gameObject.CompareTag(t.getTagList[(int)ETags.BOSS_TAG]))
        {
            collision.GetComponent<health>().TakeDamage(50);
            KillEnemy();
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

    void Repeat()
    {
        parent.Repeat();
    }


    void KillEnemy()
    {
        GameObject.FindGameObjectWithTag(t.getTagList[(int)ETags.GAME_CONTROLLER_TAG]).GetComponent<GameController>().AddScore(50);
        anim.SetBool("isDead", true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Repeat();

        
        Destroy(gameObject, .5f);   
    }
}
