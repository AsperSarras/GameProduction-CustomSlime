using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EquipMenu : MonoBehaviour
{
    //public GameObject Player;
    public GameObject PlayerGameObject;
    MainCharacter Player;

    public int bChanger;
    public int bNumber;
    // Start is called before the first frame update
    void Start()
    {
        PlayerGameObject = GameObject.FindWithTag("Player");
        Player = PlayerGameObject.GetComponent<MainCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BodyUpdate()
    {
        if (bChanger == 0)
        {
            Player.HandChangeL(bNumber);

        }
        else if(bChanger == 1)
        {
            Player.HandChangeR(bNumber);
        }
        else if (bChanger == 2)
        {
            Player.HeadChange(bNumber);
        }
    }   
}
