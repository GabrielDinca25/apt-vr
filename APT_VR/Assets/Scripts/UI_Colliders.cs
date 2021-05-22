using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Colliders : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UI"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<MenuController>().SetScene(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UI"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<MenuController>().SetScene("");
        }
    }
}
