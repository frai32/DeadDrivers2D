using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setArmor : MonoBehaviour
{
    private AudioSource m_ExplosionAudio;
    private Tags t;
    private void Start()
    {
        m_ExplosionAudio = GetComponent<AudioSource>();
        t = new Tags();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_ExplosionAudio.Play();
            collision.GetComponent<health>().setArmor(true);
            GameObject.FindGameObjectWithTag(t.getTagList[(int)ETags.GAME_CONTROLLER_TAG]).GetComponent<GameController>().armorText.gameObject.SetActive(true);

            Destroy(gameObject, 0.1f);
        }
    }
}
