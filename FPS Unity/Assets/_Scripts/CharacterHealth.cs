using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;
    public GameObject m_KeyPrefab;
    private float m_CurrentHealth;
    private bool m_Dead;
    public bool m_HoldingKey = false;  //dictate that the player is not holding the key, we can update this in the key pickup script


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
    }

    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;              //take damage float amount from current health

        if (m_CurrentHealth <= 0f && !m_Dead) //if characters health is less than 0 move to OnDeath function
        {
            OnDeath();
        }

    }

    private void OnDeath()  
    {
        m_Dead = true;
       Instantiate(m_KeyPrefab, transform.position, transform.rotation); // when the character is dead, instantiate the key prefab (which need not be a child of character)
       gameObject.SetActive(false); //turn off the player

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
