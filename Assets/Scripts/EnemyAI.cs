using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //transform allows you take coordinates of set object
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    //turn speed of the AI
    [SerializeField] float turnSpeed = 5f; 

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    bool isProvoked = false; 

    // Start is called before the first frame update
    void Start()
    {

        //Get the component (e.g. colliders, rigidbody, script)
        navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //target is the player, transform is current game object
        distanceToTarget = Vector3.Distance(target.position, transform.position); 
        if (isProvoked)
        {
            EngageTarget(); 
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true; 
        }
    }

    public void OnDamageTaken()
    {
        /*isProvoked = true;*/
        Debug.Log("Enemy AI: I know you attacked me"); 
    }
    private void EngageTarget()
    {
        FaceTarget(); 
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
             ChaseTarget(); 
           

        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget(); 
        }


        
    }
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move"); 
        navMeshAgent.SetDestination(target.position); 
    }

    private void AttackTarget()
    {
        
        GetComponent<Animator>().SetBool("Attack", true); 
        //Debug.Log(name + " has seeked and is destroying " + target.name); 
    }

    // This is to fix the the ai to turn towards the player when attacking 
    private void FaceTarget()
    { // when normalized, you only get the direction instead of the magnitude
        Vector3 direction = (target.position - transform.position).normalized;
        
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //Slerp lets you slowly turn to the desired  direction 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); 
    }

    //default method for drawing visible forcefield around an object
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange); 

    }
}
