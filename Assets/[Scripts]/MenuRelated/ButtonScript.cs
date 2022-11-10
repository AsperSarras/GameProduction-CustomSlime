using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int bPos;
    public int bNum;

    public Button B;

    public Text actived;
    public Text disabled;

    bool isActive = false;

    public EquipMenu EquipMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            B.interactable = true;
        }
        else
        {
            B.interactable = false;
        }

        if(bNum == 0)
        {
            if(GameSingleton.Instance.SlimeUnlocked == true)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
                disabled.text = GameSingleton.Instance.monsExp0.ToString() + "/100";
            }
        }

        else if (bNum == 1)
        {
            if (GameSingleton.Instance.M0Unlocked == true)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
                disabled.text = GameSingleton.Instance.monsExp0.ToString() + "/100";
            }
        }
        
        else if (bNum == 2)
        {
            if (GameSingleton.Instance.M1Unlocked == true)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
                disabled.text = GameSingleton.Instance.monsExp1.ToString() + "/100";
            }
        }

        else if (bNum == 3)
        {
            if (GameSingleton.Instance.M2Unlocked == true)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
                disabled.text = GameSingleton.Instance.monsExp2.ToString() + "/100";
            }
        }




        //
        if (isActive)
        {
            actived.gameObject.SetActive(true);
            disabled.gameObject.SetActive(false);
        }
        else 
        {
            actived.gameObject.SetActive(false);
            disabled.gameObject.SetActive(true);
        }
    }

    public void BodyUpdate()
    {
        EquipMenu.bChanger = bPos;
        EquipMenu.bNumber = bNum;
        EquipMenu.BodyUpdate();
    }
}
