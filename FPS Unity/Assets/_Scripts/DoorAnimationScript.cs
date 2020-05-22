using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationScript : MonoBehaviour
{

    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        WeaponSelector weaponSelector = other.gameObject.GetComponentInChildren<WeaponSelector>();

        //add that weapon selector must have key

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsOpen", true);
        }
  
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsOpen", false);
        }
       
    }
}
