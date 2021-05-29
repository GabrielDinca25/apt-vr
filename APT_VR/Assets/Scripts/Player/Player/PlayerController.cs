using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 ThumbstickAction = null;

    public float speed = 1;

    private CharacterController characterController;
    private bool goUp;
    private bool goDown;

    public float maxHeight = 105f;
    public float minHeight = 0.1f;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Thumbstick();

        AdminInput();
    }

    private void Thumbstick()
    {
        if (ThumbstickAction.axis.y > 0.1)
        {
            goUp = true;
            goDown = false;
        }
        else if (ThumbstickAction.axis.y < -0.1)
        {
            goDown = true;
            goUp = false;
        }
        else
        {
            goUp = false;
            goDown = false;
        }
    }

    private void AdminInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            goUp = true;
            goDown = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            goDown = true;
            goUp = false;
        }
    }

    private void FixedUpdate()
    {
        if (goUp)
        {
            int value = 1;
            UpdatePlayerPosition(value);
        }

        if (goDown)
        {
            int value = -1;
            UpdatePlayerPosition(value);
        }
    }

    private void UpdatePlayerPosition(int direction)
    {
        Vector3 nextPosition = Vector3.up * speed * Time.fixedDeltaTime;

        characterController.Move(nextPosition * direction);

        if (transform.position.y > 10 || transform.position.y < 0.1)
        {
            nextPosition.x = transform.position.x;
            nextPosition.y = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
            nextPosition.z = transform.position.z;

            transform.position = nextPosition;
        }

    }
}