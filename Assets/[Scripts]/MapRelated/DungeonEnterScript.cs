using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DungeonEnterScript : MonoBehaviour
{
    public int DungeonNumber;
    public GameObject DungeonMenuGameObject;
    DungeonMenuScript DungeonMenu;

    // Start is called before the first frame update
    void Start()
    {
        DungeonMenu = DungeonMenuGameObject.GetComponent<DungeonMenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameSingleton.Instance.isOnMenu = true;
            DungeonMenu.UpdateTexts(DungeonNumber);
            DungeonMenuGameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
