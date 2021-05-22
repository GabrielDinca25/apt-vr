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



    void Update()
    {
        //Squeeze();
        //Grip();
        //Pinch();
        //Skeleton();
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
