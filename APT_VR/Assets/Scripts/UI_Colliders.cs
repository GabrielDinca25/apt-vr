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
            string sceneName = data[1];
            menuController.SetScene(sceneName, forChildren);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UI"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);

            string[] data = other.gameObject.name.Split('_');
            string sceneName = data[1];

            if (menuController.sceneName == sceneName)
            {
                menuController.SetScene("", false);
            }
        }
    }
}
