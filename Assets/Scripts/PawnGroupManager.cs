using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnGroupManager : MonoBehaviour
{
    public List<PawnCharacter> pawnCharacters;
    public PawnCharacter leader;
    public Vector3 destination;
    public Camera cam;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                pawnCharacters[0].navMeshAgent.SetDestination(hit.point);
                Debug.Log(hit.point);
            }
        }
    }
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
