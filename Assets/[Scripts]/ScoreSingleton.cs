using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSingleton : MonoBehaviour
{
    public static ScoreSingleton Instance { get; private set; }

    [Header("Dungeon 1")]
    public List<string> Dungeon1Data;
    public bool Dungeon1LockEasy = false;
    public bool Dungeon1LockMedium = true;
    public bool Dungeon1LockHard = true;
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
