using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidersController : MonoBehaviour
{
    public GameObject adults;
    public GameObject childrens;

    void Start()
    {
        bool isChildren = GameManager.instance.forChildren;

        if (isChildren == true)
        {
            SetChildrenSettings();
        }
        else
        {
            SetAdultsSettings();
        }
    }

    private void SetChildrenSettings()
    {
        adults.SetActive(false);
    }

    private void SetAdultsSettings()
    {
        childrens.SetActive(false);
    }
}
