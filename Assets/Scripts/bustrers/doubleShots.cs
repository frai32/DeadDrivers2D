using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleShots : MonoBehaviour
{
    private AudioSource m_ExplosionAudio;
    private Tags t;
    private void Start()
    {
        t = new Tags();
        m_ExplosionAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_ExplosionAudio.Play();
            collision.GetComponent<PlayerShooter>().setHaveBuster(true);
            GameObject.FindGameObjectWithTag(t.getTagList[(int)ETags.GAME_CONTROLLER_TAG]).gameObject.GetComponent<GameController>().doubleText.gameObject.SetActive(true);
            Destroy(gameObject, 0.1f);
        }
    }
}
