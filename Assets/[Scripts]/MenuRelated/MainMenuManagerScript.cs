using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManagerScript : MonoBehaviour
{
    public GameObject StartingPosition;
    public GameObject Player;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (GameSingleton.Instance.isPlayerCreated == false)
        {
            Instantiate(Player);
            GameSingleton.Instance.isPlayerCreated = true;
        }

        Player = GameObject.FindGameObjectWithTag("Player");


    }
    // Start is called before the first frame update
    void Start()
    {
        GameSingleton.Instance.currentHp = GameSingleton.Instance.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        GameSingleton.Instance.currentHp = GameSingleton.Instance.MaxHp;

        if (GameSingleton.Instance.isPlayerInDungeon == true)
        {
            GameSingleton.Instance.isOnMenu = false;
            Player.transform.position = StartingPosition.transform.position;
            if(Player.transform.position == StartingPosition.transform.position)
            {
                GameSingleton.Instance.isPlayerInDungeon = false;
            }

        }
    }
}
