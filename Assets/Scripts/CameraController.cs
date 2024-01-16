using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 offset;
    void Update()
    {
        transform.position = objectToFollow.transform.position + offset; // follows the target with given offset
    }

    public void SetTarget(GameObject target) // sets the cameras target to follow
    {
        objectToFollow = target;
    }
}
