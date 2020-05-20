using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardPickup : MonoBehaviour
{
    public string weaponName = string.Empty;

    private void OnTriggerEnter(Collider other)
    {
        //does this object that collided with us have a weaponselector
        WeaponSelector weaponSelector = other.gameObject.GetComponentInChildren<WeaponSelector>();

        //if there is a weaponselector, tell it to mark this weapon as collected
        if (weaponSelector != null)
        {
            weaponSelector.CollectWeapon(weaponName);
            gameObject.SetActive(false);
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
