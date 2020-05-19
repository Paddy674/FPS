using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{

    public float m_MaxLifeTime = 2f;
    public float m_MaxDamage = 34f;
    public float m_ExplosionRadius = 5;
    public float m_ExplosionForce = 100f;

    public ParticleSystem m_ExplosionParticles;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnCollisionEnter (Collision other)
    {
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();

        if(targetRigidbody != null)
        {
            targetRigidbody.AddExplosionForce(m_ExplosionForce,
                transform.position, m_ExplosionRadius);

            CharacterHealth targetHealth = targetRigidbody.GetComponent<CharacterHealth>();

            if(targetHealth != null)
            {
                float damage = CalculateDamage(targetRigidbody.position);
                targetHealth.TakeDamage(damage);
            }
        }

        float CalculateDamage(Vector3 targetPosition)
        {
            Vector3 explositionToTarget = targetPosition - transform.position;
            float explosionDistance = explositionToTarget.magnitude;

            float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

            float damage = relativeDistance * m_MaxDamage;

            damage = Mathf.Max(0f, damage);

            return damage;
        }

        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        Destroy(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
