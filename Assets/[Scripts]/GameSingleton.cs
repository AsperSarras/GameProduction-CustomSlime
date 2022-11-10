using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton Instance { get; private set; }

    public float MaxHp;
    public float currentHp;
    public float atk;
    public float def;
    public float str;
    public float agi;
    public float inte;

    public TypeEnmu Type = TypeEnmu.WATER;

    public bool isPlayerCreated = false;
    public bool isPlayerInDungeon = false;
    public bool isOnMenu = false;


    public bool SlimeUnlocked = true;
    public bool M0Unlocked = false; //GreenEye
    public int monsExp0 = 0;
    public bool M1Unlocked = false; //Blue
    public int monsExp1 = 0;
    public bool M2Unlocked = false; //Boxymon
    public int monsExp2 = 0;

    public void ExpGain(MonsterEnmu monsterType, int expGain)
    {
        switch (monsterType)
        {
            case MonsterEnmu.GREENEYE:
                if(!M0Unlocked)
                {
                    monsExp0 += expGain;
                    if (monsExp0 >= 100)
                    {
                        M0Unlocked = true;
                    }
                }
                break;
            case MonsterEnmu.BLUEBOSS:
                if (!M1Unlocked)
                {
                    monsExp1 += expGain;
                    if (monsExp1 >= 100)
                    {
                        M1Unlocked = true;
                    }
                }
                break;
            case MonsterEnmu.BOXYMON:
                if (!M2Unlocked)
                {
                    monsExp2 += expGain;
                    if (monsExp2 >= 100)
                    {
                        M2Unlocked = true;
                    }
                }
                break;
        }

        //if (mons == 0 && mons0 == false)
        //{
        //    monsExp0 += expGain;
        //    if (monsExp0 >= 100)
        //    {
        //        mons0 = true;
        //    }
        //}

        //else if (mons == 1 && mons1 == false)
        //{
        //    monsExp1 += expGain;
        //    if (monsExp1 >= 100)
        //    {
        //        mons1 = true;
        //    }
        //}

        //else if (mons == 2 && mons2 == false)
        //{
        //    monsExp2 += expGain;
        //    if (monsExp2 >= 100)
        //    {
        //        mons2 = true;
        //    }
        //}
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}