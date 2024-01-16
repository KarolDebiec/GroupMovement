using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnGroupManager : MonoBehaviour
{
    public List<PawnCharacter> pawnCharacters;
    public PawnCharacter leader;
    public Vector3 destination;

    public void InitializeCharacters()
    {

    }

    public void SelectLeader(int characterIndex)
    {
        leader = pawnCharacters[characterIndex];
    }

    public void SetDestination(Vector3 destination)
    {

    }

    public void MoveCharacters()
    {

    }
}
