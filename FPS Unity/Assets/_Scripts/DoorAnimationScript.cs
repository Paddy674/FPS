using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationScript : MonoBehaviour
{
    public bool m_HoldingKeyCard;
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

        if (weaponSelector != null)
        if (other.gameObject.tag == "Player")
        if (m_HoldingKeyCard == true)
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
