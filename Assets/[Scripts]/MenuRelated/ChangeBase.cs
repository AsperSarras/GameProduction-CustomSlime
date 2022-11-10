using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBase : MonoBehaviour
{

    //temp
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameSingleton.Instance.isOnMenu = true;
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        menu.SetActive(false);
    //    }
    //}
}
