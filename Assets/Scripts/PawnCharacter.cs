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
    private void Start()
    {
        navMeshAgent.isStopped = true;
    }
    private void Update()
    {
        if(navMeshAgent.remainingDistance <= 0.1f) // when close to the destination pawn stops
        {
            navMeshAgent.isStopped = true;
        }
        if(!navMeshAgent.isStopped && stamina > 0) // if pawn is moving and has positive stamina the he loses stamina in time
        {
            stamina -= Time.deltaTime;
        }
        else if(navMeshAgent.isStopped && stamina <= maxStamina) // if pawn is stopped and has less than maximum stamina then he regenerates the stamina in time
        {
            stamina += Time.deltaTime;
        }
        if(stamina <= 0) // if pawn has no stamina then his max speed is halfed
        {
            navMeshAgent.speed = speed/2;
        }
        else // if pawn has remaining stamina then his max speed has its original value
        {
            navMeshAgent.speed = speed;
        }
    }
    public void MoveTo(Vector3 destination) //commands the pawn to move to the destination
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(destination);
    }
    public void GenerateRandomAttributes() //generates random values to the pawns attributes 
    {
        speed = Random.Range(3.0f, 5.0f);
        navMeshAgent.speed = speed;
        agility = Random.Range(120.0f, 200.0f);
        navMeshAgent.angularSpeed = agility;
        maxStamina = Random.Range(3.0f, 5.0f);
        stamina = maxStamina;
    }

    public void Follow(PawnCharacter leader) //commands the pawn to follow the leader of the group
    {
        float distance = Vector3.Distance(transform.position, leader.transform.position); // calculate the distance to the group leader
        if(distance > 1.1f) // if the pawn is too far from the leader then he follows the leader
        {
            navMeshAgent.isStopped = false;
            MoveTo(leader.gameObject.transform.position);
        }
        else // if withing the set range then the movement stops
        {
            navMeshAgent.isStopped = true;
        }
        
    }
}
