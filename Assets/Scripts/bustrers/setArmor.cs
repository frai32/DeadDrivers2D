using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setArmor : MonoBehaviour
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
            collision.GetComponent<health>().setArmor(true);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().armorText.gameObject.SetActive(true);

            Destroy(gameObject, 0.1f);
        }
    }
}
