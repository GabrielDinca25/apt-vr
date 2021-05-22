using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperPosition : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;

    void Update()
    {
        transform.position = target.position + offset;
    }
}

