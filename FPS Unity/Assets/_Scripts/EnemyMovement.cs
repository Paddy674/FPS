using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public List<Transform> _waypoints = new List<Transform>();
    private int currentWaypoint;

    //enemy will stop moving towards player once it reaches this distance
    public float m_CloseDistance = 8f;

    //player reference
    private GameObject m_CharacterController;

    //nav mesh agent
    private NavMeshAgent m_NavAgent;

    //rigidbody reference
    private Rigidbody m_Rigidbody;

    //will use this to follow player
    private bool m_Follow;


    private void Awake()
    {
        m_CharacterController = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }

    private void OnEnable()
    {
        //enemy is not kinematic when turned on
        m_Rigidbody.isKinematic = false;

        transform.position = new Vector3(272, 0, 241);
    }

    private void OnDisable()
    {
        //enemy is kinematic when turned off
        m_Rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = false;
        }
         
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Follow == false)
        {
            if (_waypoints.Count <= 0)
            {
                return;
            }

            if (currentWaypoint < _waypoints.Count)
            {
                if (Vector3.Distance(transform.position, _waypoints[currentWaypoint].position) > 2)
                {
                    m_NavAgent.SetDestination(_waypoints[currentWaypoint].position);
                }
                else
                {
                    currentWaypoint++;
                }
            }
            else
            {
                currentWaypoint = 0;
            }
        }
        else
        {

            if (m_Follow == false)
                return;
            //get distance to player
            float distance = (m_CharacterController.transform.position - transform.position).magnitude;
            //if diance is less than stop distance, stop
            if (distance > m_CloseDistance)
            {
                m_NavAgent.SetDestination(m_CharacterController.transform.position);
                m_NavAgent.isStopped = false;
            }
            else
            {
                m_NavAgent.isStopped = true;
            }

        }

    }
}
