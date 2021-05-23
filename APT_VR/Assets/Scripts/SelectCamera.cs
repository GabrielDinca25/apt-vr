using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCamera : MonoBehaviour
{
    void Start()
    {
        GameObject vrCamera = GameObject.FindGameObjectWithTag("MainCamera");

        GetComponent<Canvas>().worldCamera = vrCamera.GetComponent<Camera>();

        transform.SetParent(vrCamera.transform);

        RectTransform rectTransform = GetComponent<RectTransform>();

        rectTransform.localScale = new Vector3(1, 1, 1);
        rectTransform.localPosition = new Vector3(0, 0, 1);
        rectTransform.localRotation = Quaternion.identity;
    }
}
