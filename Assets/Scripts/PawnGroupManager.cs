using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnGroupManager : MonoBehaviour
{
    public List<PawnCharacter> pawnCharacters;
    public PawnCharacter leader;
    public Vector3 destination;
    public Camera cam;
    private void Start()
    {
        InitializeCharacters();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                SetDestination(hit.point);
            }
        }
        foreach (PawnCharacter pawn in pawnCharacters)
        {
            if(pawn != leader)
            {
                pawn.Follow(leader);
            }
        }
    }
    public void InitializeCharacters()
    {
        foreach (PawnCharacter pawn in pawnCharacters)
        {
            pawn.GenerateRandomAttributes();
        }
    }

    public void SelectLeader(int characterIndex)
    {
        leader = pawnCharacters[characterIndex];
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        leader.MoveTo(destination);
    }

    public void MoveCharacters()
    {

    }
}
