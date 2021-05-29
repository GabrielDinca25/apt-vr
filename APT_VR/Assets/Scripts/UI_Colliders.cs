using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Colliders : MonoBehaviour
{
    MenuController menuController;

    private void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UI"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            string[] data = other.gameObject.name.Split('_');

            bool forChildren = data[0] == "Children" ? true : false;
            string scene = data[1];
            menuController.SetScene(scene, forChildren);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UI"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            menuController.SetScene("", false);
        }
    }
}
