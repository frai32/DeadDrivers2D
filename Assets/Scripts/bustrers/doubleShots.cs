using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleShots : MonoBehaviour
{
    private AudioSource m_ExplosionAudio;
    private void Start()
    {
        m_ExplosionAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_ExplosionAudio.Play();
            collision.GetComponent<PlayerShooter>().setHaveBuster(true);
            GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameController>().doubleText.gameObject.SetActive(true);
            Destroy(gameObject, 0.1f);
        }
    }
}
