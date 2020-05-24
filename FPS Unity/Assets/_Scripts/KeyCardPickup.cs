using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardPickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) // function reliant on trigger
    {
        if (other.gameObject.tag == "Player") //is the trigger the player?
        {
            other.gameObject.GetComponent<CharacterHealth>().m_HoldingKey = true; //if so set the holding key boolean in the character health script to true and then destroy the object in the scene
            Destroy(gameObject);
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
}

