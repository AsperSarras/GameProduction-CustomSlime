using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackButton : MonoBehaviour
{
    public GameObject menu;

    public void GoBack()
    {
        menu.SetActive(false);
        GameSingleton.Instance.isOnMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
