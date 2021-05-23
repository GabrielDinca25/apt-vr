using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class MenuController : MonoBehaviour
{
    public SteamVR_Action_Vector2 ThumbstickAction = null;
    public SteamVR_Action_Boolean InteractWithUI = null;
    public SteamVR_Action_Boolean ButtonA = null;
    public SteamVR_Action_Boolean ButtonB = null;

    public string sceneName;
    public bool forChildren;

    public bool hasPointer;
    public Transform pointer;
    public float pointerSpeed = 0.05f;

    private GameObject player;

    private void Start()
    {
        if (pointer != null)
        {
            hasPointer = true;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (hasPointer)
        {
            Thumbstick();
        }

        if (InteractWithUI.stateDown)
        {
            LoadScene();
        }
    }

    private void Thumbstick()
    {
        if (ThumbstickAction.axis == Vector2.zero)
        {
            return;
        }

        Vector3 offset = new Vector3(0, ThumbstickAction.axis.y, -ThumbstickAction.axis.x);

        Vector3 nextPosition = pointer.position + offset * pointerSpeed;

        nextPosition.x = 4.5f;
        nextPosition.y = Mathf.Clamp(nextPosition.y, 2.1f, 3.8f);
        nextPosition.z = Mathf.Clamp(nextPosition.z, -1.4f, 1.6f);

        pointer.position = nextPosition;
    }


    public void SetScene(string sceneName, bool forChildren)
    {
        this.sceneName = sceneName;
        GameManager.instance.forChildren = forChildren;
    }

    public void LoadScene()
    {
        if (sceneName == "")
        {
            return;
        }

        if (sceneName.Equals("Quit"))
        {
            Application.Quit();
            return;
        }

        switch (sceneName)
        {
            case "Height":
                player.transform.position = new Vector3(0f, 0f, -0.3f);
                player.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                break;
            default:
                break;
        }
        SceneManager.LoadScene(sceneName);
    }
}
