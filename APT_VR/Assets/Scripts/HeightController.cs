using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightController : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerController pc = player.GetComponent<PlayerController>();

        bool isChildren = GameManager.instance.forChildren;

        if (isChildren == true)
        {
            SetChildrenSettings(pc);
        }
        else
        {
            SetAdultsrenSettings(pc);
        }
    }

    private void SetChildrenSettings(PlayerController pc)
    {
        pc.maxHeight = 55f;
        pc.minHeight = 0.1f;
    }

    private void SetAdultsrenSettings(PlayerController pc)
    {
        pc.maxHeight = 105f;
        pc.minHeight = 0.1f;
    }
}
