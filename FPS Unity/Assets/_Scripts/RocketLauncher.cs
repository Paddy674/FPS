using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour
{

    public bool playerControlled = true;            //is thjis RocketLauncher controlled by the player?
    public float fireInterval = 3.0f;               //how many seconds between shots for this rocket launcher?
    public GameObject m_Rocket;
    public GameObject m_Spawnpoint;
    public float m_LaunchForce = 30f;

    private float fireTimer = 0;                    //keep track of when we can fire again

    public int ammo = 10;                           //number of rockets player has

    public Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireInterval;                   //when the game starts we are ready to shoot
        ammoText.text = "Ammo: " + ammo;
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

        Instantiate(m_Rocket, m_Spawnpoint.transform.position, m_Spawnpoint.transform.rotation);

        fireTimer = 0;                                                          //reset the fire timer
        ammo -= 1;                                                              //reduce ammo count
        ammoText.text = "Ammo: " + ammo;
    }

}
