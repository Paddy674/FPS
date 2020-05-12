using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{

    public bool playerControlled = true;            //is thjis RocketLauncher controlled by the player?
    public float fireInterval = 3.0f;               //how many seconds between shots for this rocket launcher?

    private float fireTimer = 0;                    //keep track of when we can fire again

    public GameObject rocketPrefab;                 //reference to Rocket prefab so we can spawn it
    public Vector3 spawnOffset;                     //a position offset for where the rocket is spawned so that we don't spawn inside the gun

    public int ammo = 10;                           //number of rockets player has

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireInterval;                   //when the game starts we are ready to shoot
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;                //advance the timer

        if (fireTimer >= fireInterval)              //have we waited long enough to shoot?
        {
            if (playerControlled && Input.GetButtonDown("Fire1"))       //is rocket player controlled and fire button pressed?
            {
                Fire();                   //fire a rocket
            }
        }
    }

    public void Fire()
    {
        if (ammo <= 0)                              //only shoot if there is ammo
        {
            return;
        }

        GameObject rocketInstance = Instantiate(rocketPrefab);      //spawn and store a new rocket prefab


        rocketInstance.transform.position = transform.position + spawnOffset;   //apply the spawn offset relative to the gun position
        rocketInstance.transform.rotation = transform.rotation;                 //rotate the rocket to match the guns rotation

        fireTimer = 0;                                                          //reset the fire timer
        ammo -= 1;                                                              //reduce ammo count
    }

}
