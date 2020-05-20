using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{

    public bool playerControlled = true;            //is thjis RocketLauncher controlled by the player?
    public float fireInterval = 3.0f;               //how many seconds between shots for this rocket launcher?
    public Rigidbody m_Rocket;
    public Transform m_FireTransform;
    public float m_LaunchForce = 30f;

    private float fireTimer = 0;                    //keep track of when we can fire again

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

        Rigidbody rocketInstance = Instantiate(m_Rocket, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        rocketInstance.velocity = m_LaunchForce * m_FireTransform.forward;


        fireTimer = 0;                                                          //reset the fire timer
        ammo -= 1;                                                              //reduce ammo count
    }

}
