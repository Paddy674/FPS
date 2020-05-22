using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{

    public float m_MaxLifeTime = 2f;
    public float damageAmount = 33f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);     //if rocket doesn't hit anything destory it
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>(); //find a rigidbody to collide with (only characters)

        if (targetRigidbody != null)
        {

            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(damageAmount); // if the collision object has a rigidbody and enemy tag turn it off
                gameObject.SetActive(false);
            }
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(damageAmount); // if the collision object has a rigidbody and player tag turn it off
                gameObject.SetActive(false);
            }

         else if(targetRigidbody == null)
            {
                gameObject.SetActive(false); // if the collision object doesn't have a rigidbody also turn it off
            }

        }

    }
}
