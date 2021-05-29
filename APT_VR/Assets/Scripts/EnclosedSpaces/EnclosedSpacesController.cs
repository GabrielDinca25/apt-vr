using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class EnclosedSpacesController : MonoBehaviour
{
    public SteamVR_Action_Vector2 ThumbstickAction = null;
    public GameObject room;

    private bool goUp;
    private bool goDown;

    public float resizeSpeed = 0.01f;
    public float minSize = 0.1f;
    public float maxSize = 1f;


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
            UpdateRoomSize(resizeSpeed);
        }

        if (goDown)
        {
            UpdateRoomSize(-resizeSpeed);
        }
    }

    private void UpdateRoomSize(float value)
    {
        room.transform.localScale += (Vector3.one * value);

        if (room.transform.localScale.x > maxSize || room.transform.localScale.x < minSize)
        {
            Vector3 scale = Vector3.zero;

            float scaleValue = Mathf.Clamp(room.transform.localScale.x, minSize, maxSize);
            scale.x = scaleValue;
            scale.y = scaleValue;
            scale.z = scaleValue;

            room.transform.localScale = scale;
        }
    }
}
