using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerPosition : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Update()
    {
        Vector3 nextPosition = target.position + Vector3.one * speed;

        nextPosition.x = 4.5f;
        nextPosition.y = Mathf.Clamp(nextPosition.y, 2.1f, 3.8f);
        nextPosition.z = Mathf.Clamp(nextPosition.z, -1.4f, 1.6f);

        transform.position = nextPosition;
    }
}
