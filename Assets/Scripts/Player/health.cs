using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public float m_StartingHealth = 100f;               // The amount of health each tank starts with.
    public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
    public Image m_FillImage;                           // The image component of the slider.
    public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.

    private AudioSource m_ExplosionAudio;               // The audio source to play when the tank explodes.
  
    private float m_CurrentHealth;                      // How much health the tank currently has.
    private bool m_Dead;                                // Has the tank been reduced beyond zero health yet?
    private Animator D_anim;
    private bool armored;

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
        D_anim = GetComponentInChildren<Animator>();
        print(D_anim.name); 

        // Get a reference to the audio source on the instantiated prefab.
        //m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        // Disable the prefab so it can be activated when it's required.
        //m_ExplosionParticles.gameObject.SetActive(false);
    }

    private void Start()
    {
        
    }


    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        // Update the health slider's value and color.
        SetHealthUI();
    }


    public void TakeDamage(float amount = 10)
    {
        if (!armored)
        {
            // Reduce current health by the amount of damage done.
            m_CurrentHealth -= amount;

            // Change the UI elements appropriately.
            SetHealthUI();

            // If the current health is at or below zero and it has not yet been registered, call OnDeath.
            if (m_CurrentHealth <= 0f && !m_Dead)
            {
                OnDeath();
            }
        }
        else
            armored = false;
    }

    public void healDamage(float amount = 10)
    {
        m_CurrentHealth += amount;

        SetHealthUI();
    }


    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        m_Slider.value = m_CurrentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        // Set the flag so that this function is only called once.
        GetComponent<PlayerController>().speed = 0;
        m_Dead = true;
        Debug.Log(m_Dead);
        m_Slider.gameObject.SetActive(false);
        D_anim.SetBool("isDead", m_Dead);

        Debug.Log(D_anim.GetBool("isDead"));
    

        // Play the tank explosion sound effect.
        // m_ExplosionAudio.Play();

        // Turn the tank off.
        StartCoroutine(playDeathAnimation());
    }

    IEnumerator playDeathAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
