using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlatformMovement : MonoBehaviour
{
    private Transform player;
    public Vector3 offset = new Vector3(0, -1f, 0);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position = player.position + offset;
    }
}
