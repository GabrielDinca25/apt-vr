using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftHandController : MonoBehaviour
{
    public SteamVR_Action_Vector2 ThumbstickAction = null;
    public SteamVR_Action_Vector2 TrackpadAction = null;
    public SteamVR_Action_Single SqueezeAction = null;
    public SteamVR_Action_Boolean GripAction = null;
    public SteamVR_Action_Boolean PinchAction = null;
    public SteamVR_Action_Skeleton SkeletonAction = null;
    public bool _thumb;
    public bool _index;
    public bool _middle;
    public bool _ring;
    public bool _pinky;

    public bool canUse;

    public int handIndex;
    public int handIndexLength;
    public Vector3 lastHandPosition;
    public Vector3[] handLastPositions;
    public float fireShotRotationAngle;

    public Vector3 offset;
    public Transform follower;

    void Start()
    {
        canUse = true;
        handIndex = 0;
        handIndexLength = 60;
        handLastPositions = new Vector3[handIndexLength];
        handLastPositions[handIndexLength - 1] = transform.position;
        follower.position = transform.position + offset;
    }

    void Update()
    {
        //Thumbstick();
        //Squeeze();
        //Grip();
        //Pinch();
        //Skeleton();
        UpdatePosition();
        //TrackFinger();
    }

    private void TrackFinger()
    {
        _thumb = SkeletonAction.thumbCurl > 0.5f ? true : false;
        _index = SkeletonAction.indexCurl > 0.5f ? true : false;
        _middle = SkeletonAction.middleCurl > 0.5f ? true : false;
        _ring = SkeletonAction.ringCurl > 0.5f ? true : false;
        _pinky = SkeletonAction.pinkyCurl > 0.5f ? true : false;
    }

    public void UpdatePosition()
    {
        handLastPositions[handIndex] = transform.position;

        if (handIndex == 0)
        {
            lastHandPosition = handLastPositions[handLastPositions.Length - 1];
        }
        else
        {
            lastHandPosition = handLastPositions[handIndex - 1];
        }

        follower.position += (transform.position - lastHandPosition);

        handIndex++;
        if (handIndex == handIndexLength)
        {
            handIndex = 0;
        }
    }

    private void Thumbstick()
    {
        if (ThumbstickAction.axis == Vector2.zero)
            return;
        Debug.Log("Thumbstick care e  Touchpad: " + ThumbstickAction.axis);
    }
    private void Squeeze()
    {
        if (SqueezeAction.axis == 0.0f)
            return;
        Debug.Log("SqueezeAction: " + SqueezeAction.axis);
    }
    private void Grip()
    {
        if (GripAction.stateDown)
            Debug.Log("GripActionState : Down");
        if (GripAction.stateUp)
            Debug.Log("GripActionState : Down");
    }
    private void Pinch()
    {
        if (PinchAction.stateDown)
            Debug.Log("PinchAction : Down");
        if (PinchAction.stateUp)
            Debug.Log("PinchAction : Down");
    }
    private void Skeleton()
    {
        //float[] allCurls = SkeletonAction.fingerCurls;
        if (SkeletonAction.indexCurl > 0.2f)
        {
            print("Index: " + SkeletonAction.indexCurl);
        }
        if (SkeletonAction.middleCurl > 0.2f)
        {
            print("middleCurl: " + SkeletonAction.middleCurl);
        }
        if (SkeletonAction.ringCurl > 0.2f)
        {
            print("ringCurl: " + SkeletonAction.ringCurl);
        }
        if (SkeletonAction.pinkyCurl > 0.2f)
        {
            print("pinkyCurl: " + SkeletonAction.pinkyCurl);
        }
        if (SkeletonAction.thumbCurl > 0.2f)
        {
            print("thumbCurl: " + SkeletonAction.thumbCurl);
        }
    }
}
