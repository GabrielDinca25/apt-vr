using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightController : MonoBehaviour
{
    public float speed = 5f;

    public Transform plank;
    private Vector3 plankInitialPosition;

    bool goUp;
    bool goDown;

    void Start()
    {
        plank = GameObject.FindGameObjectWithTag("Plank").transform;
        plankInitialPosition = plank.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            goUp = true;
        }
        else
        {
            goUp = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            goDown = true;
        }
        else
        {
            goDown = false;
        }

    }

    void FixedUpdate()
    {
        if (goUp)
        {
            plank.position += Vector3.up * speed * Time.fixedDeltaTime;
        }

        if (goDown)
        {
            plank.position -= Vector3.up * speed * Time.fixedDeltaTime;
        }

        float yPosition = Mathf.Clamp(plank.position.y, plankInitialPosition.y, 10);
        plank.position = new Vector3(plank.position.x, yPosition, plank.position.z);
    }
}
