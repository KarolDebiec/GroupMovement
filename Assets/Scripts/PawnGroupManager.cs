using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnGroupManager : MonoBehaviour
{
    public List<PawnCharacter> pawnCharacters;
    public PawnCharacter leader;
    public Camera cam;
    private void Start() 
    {
        InitializeCharacters();
        SelectLeader(0);
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
        foreach (PawnCharacter pawn in pawnCharacters) // if the pawn is not a leader then follow a leader
        {
            if(pawn != leader)
            {
                pawn.Follow(leader);
            }
        }
    }
    private void InitializeCharacters() // initialize all pawns in the pawnCharacters list
    {
        foreach (PawnCharacter pawn in pawnCharacters)
        {
            pawn.GenerateRandomAttributes();
        }
    }

    public void SelectLeader(int characterIndex) // selects leader from the pawnCharacters list using their position in the list
    {
        leader = pawnCharacters[characterIndex];
        cam.GetComponent<CameraController>().SetTarget(leader.gameObject);
    }

    private void SetDestination(Vector3 destination) // sets destination for the pawn group
    {
        leader.MoveTo(destination);
    }
}
