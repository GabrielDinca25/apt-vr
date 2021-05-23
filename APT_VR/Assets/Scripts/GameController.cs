using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GameController : MonoBehaviour
{
    [HideInInspector] public static GameController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public SteamVR_Action_Vector2 ThumbstickAction = null;
    public SteamVR_Action_Boolean ButtonA = null;
    public SteamVR_Action_Boolean ButtonB = null;

    public GameObject whiteScreen;
    public bool blankScreen;

    void Update()
    {
        if (ButtonA.stateDown)
        {
            blankScreen = !blankScreen;
            MakeScreenWhite(blankScreen);
        }
    }

    public void MakeScreenWhite(bool status)
    {
        whiteScreen.SetActive(status);
    }
}
