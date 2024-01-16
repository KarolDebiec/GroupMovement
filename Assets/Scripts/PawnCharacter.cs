using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PawnCharacter : MonoBehaviour
{
    public float speed;
    public float agility;
    public float stamina;
    public NavMeshAgent navMeshAgent;
    public bool isLeader;


    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }
    public void GenerateRandomAttributes()
    {


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
