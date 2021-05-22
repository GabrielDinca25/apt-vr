using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public string sceneName;

    public void SetScene(string sceneName)
    {
        this.sceneName = sceneName;
    }
}
