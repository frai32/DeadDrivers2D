using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPlayer : MonoBehaviour
{
    private AudioSource m_ExplosionAudio;
    private Tags t;
    private void Start()
    {
        t = new Tags();
        m_ExplosionAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(t.getTagList[(int)ETags.PLAYER_TAG]))
        {
            m_ExplosionAudio.Play();
            collision.GetComponent<health>().healDamage(50);
            Destroy(gameObject, 0.1f);
        }
    }
}
