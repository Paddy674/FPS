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
    public GameObject m_EthanBody;
    public GameObject m_EthanGlasses;
    public GameObject m_EthanSkeleton;

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

       m_EthanBody.SetActive(false);
       m_EthanGlasses.SetActive(false);
       m_EthanSkeleton.SetActive(false);

        if (m_KeyPrefab.gameObject != null)
            {
            m_KeyPrefab.gameObject.SetActive(true); // if enemy destroyed enemy drops key
        }

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
