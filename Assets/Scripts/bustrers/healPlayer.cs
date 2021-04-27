using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPlayer : MonoBehaviour
{
    private AudioSource m_ExplosionAudio;
    private void Start()
    {
        m_ExplosionAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_ExplosionAudio.Play();
            collision.GetComponent<health>().healDamage(50);
            Destroy(gameObject, 0.1f);
        }
    }
}
