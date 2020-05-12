using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAmmoPickup : MonoBehaviour
{

    public int amount = 5;                  //how many rockets this pickup is worth
    public float rotationSpeed = 20f;       //how fast the ammo box rotates


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);   //rotate the ammo box
    }

    private void OnTriggerEnter(Collider other)
    {
        RocketLauncher rocketLauncher = other.gameObject.GetComponentInChildren<RocketLauncher>();              // check to see if we have a rocketlauncher attached to the object

        if (rocketLauncher != null)                                     //if we found a rocketlauncher
        {
            rocketLauncher.ammo += amount;                              //add some ammot to that rocketlauncher
            gameObject.SetActive(false);                                //and deactivate ourselves
        }

    }

}
