using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSingleton : MonoBehaviour
{
    public static ScoreSingleton Instance { get; private set; }
    [Header("General")]
    public float DungeonScaling = -1;
    public int ActiveEnemies = -1;
    public StageEnum currentStage;

    public Dictionary<StageEnum, bool> Stage = new Dictionary<StageEnum, bool>();

    //[Header("DungeonLocks")]
    //public List<bool> ListDungeonLock;

    [Header("Dungeon 1")]
    public List<string> Dungeon1Data;
    /*
     * 0 = StatusEasy
     * 1 = BestScoreEasy
     * 2 = BestScoreTimeEasy
     * 3 = StatusMedium
     * 4 = BestScoreMedium
     * 5 = BestScoreTimeMedium
     * 6 = StatusHard
     * 7 = BestScoreHigh
     * 8 = BestScoreTimeHard
    */
    //public bool Dungeon1LockEasy = false;
    //public bool Dungeon1LockMedium = true;
    //public bool Dungeon1LockHard = true;
    public int Dungeon1ActiveEnemiesEasy = 12;
    public int Dungeon1ActiveEnemiesMedium = 12;
    public int Dungeon1ActiveEnemiesHard = 12;




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

    private void Start()
    {
        FillLists();
    }

    void FillLists()
    {
        //DungeonLocks
        //ListDungeonLock.Add(Dungeon1LockEasy);      //0
        //ListDungeonLock.Add(Dungeon1LockMedium);    //1
        //ListDungeonLock.Add(Dungeon1LockHard);      //2

        Stage.Add(StageEnum.D1Easy, false);
        Stage.Add(StageEnum.D1Medium, true);
        Stage.Add(StageEnum.D1Hard, true);

    }

    public void StageClear()
    {
        switch (currentStage)
        {
            case StageEnum.D1Easy:
                Stage[StageEnum.D1Medium] = false;
                break;
            case StageEnum.D1Medium:
                Stage[StageEnum.D1Hard] = false;
                break;
            case StageEnum.D1Hard:
                break;
            default:
                break;
        }
    }

}
