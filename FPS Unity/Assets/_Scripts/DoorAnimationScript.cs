using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationScript : MonoBehaviour
{
    public bool m_HoldingKeyCard; //declare another boolean which can be set to true based on another script when key is picked up
    Animator anim;
    public bool m_LockedDoor; //declare a boolean to define if the door is locked in inspector
    // setup display message
    public GUIStyle winMessageStyle;
    private bool hasWon = false;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) // function reliant on trigger
    {
        if (other.gameObject.tag == "Player") // is the trigger the player?
        {
            if (m_LockedDoor == true) //is the door locked?
            {
                if (other.gameObject.GetComponent<CharacterHealth>().m_HoldingKey == true) //is the player holding the key according to the character health script?
                {
                    anim.SetBool("IsOpen", true); //if so run the door animation
                    hasWon = true;
                }

            }
            else
            {
                anim.SetBool("IsOpen", true); //check to see what this else statenent relates to, in this instance if the door is not a locked door, open it anyway
            }

        }

    }

    private void OnTriggerExit(Collider other) //if you exit the trigger area - close the door
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsOpen", false);
        }

    }


    void OnGUI()
    {
        if (hasWon)
        {
            GUI.Label(Camera.main.pixelRect, "Unlocked... Enter the elevator to try again!", winMessageStyle);
        }

    }

}
