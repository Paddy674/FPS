using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string weaponName = string.Empty;        //the name of the weapon. this should enable upon collection
    public float rotationSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
    }

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
}
