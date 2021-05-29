using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DarknessController : MonoBehaviour
{
    public SteamVR_Action_Vector2 ThumbstickAction = null;
    public Light environmentLight;

    public float minIntensity = 0.001f;
    public float maxIntensity = 0.01f;

    private bool valueUpdated;

    void Start()
    {
        valueUpdated = true;
    }


    void Update()
    {
        Thumbstick();

        AdminInput();
    }

    private void Thumbstick()
    {
        if (ThumbstickAction.axis.y > 0.1 && valueUpdated == true)
        {
            valueUpdated = false;
            float value = 0.001f;
            updateIntensity(value);
        }
        else if (ThumbstickAction.axis.y < -0.1 && valueUpdated == true)
        {
            valueUpdated = false;
            float value = -0.001f;
            updateIntensity(value);
        }
        else if (ThumbstickAction.axis.y > -0.1 && ThumbstickAction.axis.y < 0.1)
        {
            valueUpdated = true;
        }
    }

    private void AdminInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            float value = 0.001f;
            updateIntensity(value);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            float value = -0.001f;
            updateIntensity(value);
        }
    }

    private void updateIntensity(float value)
    {
        environmentLight.intensity += value;

        float intensity = environmentLight.intensity + value;
        environmentLight.intensity = Mathf.Clamp(intensity, minIntensity, maxIntensity);
    }
}
