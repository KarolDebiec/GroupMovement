using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public RaycastHit hitInfo;

    public bool DetectClick()
    {
        return true;
    }

    public Vector3 GetPointOfClick()
    {
        return Vector3.zero;
    }
}
