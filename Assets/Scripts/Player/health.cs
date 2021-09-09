using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public float m_StartingHealth = 100f;               // 
    public Slider m_Slider;                             // 
    public Image m_FillImage;                           // 
    public Color m_FullHealthColor = Color.green;       // 
    public Color m_ZeroHealthColor = Color.red;         // 

    private AudioSource m_ExplosionAudio;               // 
  
    private float m_CurrentHealth;                      // 
    private bool m_Dead;                                // 
    private Animator D_anim;
    private bool armored;
    private Tags t;

    public void setArmor(bool armor)
    {
        armored = armor;
    }
   

    public float getCurrentHealth()
    {
        return m_CurrentHealth;
    }

    private void Awake()
    {
        D_anim = GetComponent<Animator>();
        // 
        m_ExplosionAudio = GetComponent<AudioSource>();

    }

    private void Start()
    {
        t = new Tags();
    }


    private void OnEnable()
    {
        // 
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
        // 
        SetHealthUI();
    }


    public void TakeDamage(float amount = 10)
    {
        if (armored)
        {
            armored = false;
            GameObject.FindGameObjectWithTag(t.getTagList[(int)ETags.GAME_CONTROLLER_TAG]).GetComponent<GameController>().armorText.gameObject.SetActive(armored);
        }
        else
        {
            // 
            m_CurrentHealth -= amount;

            // 
            SetHealthUI();

            //
            if (m_CurrentHealth <= 0f && !m_Dead)
            {
                OnDeath();
            }
        }
    }

    public void healDamage(float amount = 10)
    {
        m_CurrentHealth += amount;
        if (m_CurrentHealth > 100)
            m_CurrentHealth = 100;
        SetHealthUI();
    }


    private void SetHealthUI()
    {
        //
        m_Slider.value = m_CurrentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        // 
        GetComponent<PlayerController>().speed = 0;

        m_Dead = true;
        Debug.Log("Player"+m_Dead);
        
        D_anim.SetBool("isDead", m_Dead);

        Debug.Log(D_anim.GetBool("isDead"));
        GameObject.FindGameObjectWithTag(t.getTagList[(int)ETags.GAME_CONTROLLER_TAG]).GetComponent<GameController>().GameOver();
       
        m_ExplosionAudio.Play();
        Destroy(gameObject, 0.5f);
       
    }

  
}
