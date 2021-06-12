using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlatformMovement : MonoBehaviour
{
    private Transform player;
    public float offset = -3f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);
    }
}
