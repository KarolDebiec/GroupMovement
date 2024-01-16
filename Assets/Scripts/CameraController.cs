using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 offset;
    void Update()
    {
        transform.position = objectToFollow.transform.position + offset;
    }

    public void SetTarget(GameObject target)
    {
        objectToFollow = target;
    }
}
