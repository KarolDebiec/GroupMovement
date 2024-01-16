using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PawnCharacter : MonoBehaviour
{
    public float speed;
    public float agility;
    public float maxStamina;
    public float stamina;
    public NavMeshAgent navMeshAgent;
    public bool isLeader;
    private void Start()
    {
        navMeshAgent.isStopped = true;
    }
    private void Update()
    {
        if(navMeshAgent.remainingDistance <= 0.1f)
        {
            navMeshAgent.isStopped = true;
        }
        if(!navMeshAgent.isStopped && stamina > 0)
        {
            stamina -= Time.deltaTime;
        }
        else if(navMeshAgent.isStopped && stamina <= maxStamina)
        {
            stamina += Time.deltaTime;
        }
        if(stamina <= 0)
        {
            navMeshAgent.speed = speed/2;
        }
        else
        {
            navMeshAgent.speed = speed;
        }
    }
    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(destination);
    }
    public void GenerateRandomAttributes()
    {
        speed = Random.Range(3.0f, 5.0f);
        navMeshAgent.speed = speed;
        agility = Random.Range(120.0f, 200.0f);
        navMeshAgent.angularSpeed = agility;
        maxStamina = Random.Range(3.0f, 5.0f);
        stamina = maxStamina;
    }

    public void Follow(PawnCharacter leader)
    {
        float distance = Vector3.Distance(transform.position, leader.transform.position); // calculate the distance to the group leader
        if(distance > 1.1f)
        {
            navMeshAgent.isStopped = false;
            MoveTo(leader.gameObject.transform.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
        }
        
    }
}
