using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonMenuScript : MonoBehaviour
{
    [Header("EasyData")]
    public TMP_Text StatusE;
    public TMP_Text BestScoreE;
    public TMP_Text TimeE;

    [Header("MediumData")]
    public TMP_Text StatusM;
    public TMP_Text BestScoreM;
    public TMP_Text TimeM;

    [Header("HardData")]
    public TMP_Text StatusH;
    public TMP_Text BestScoreH;
    public TMP_Text TimeH;

    [Header("Buttons")]
    public Button ButtonEasy;
    public Button ButtonMedium;
    public Button ButtonHard;

    int activeDungeon = -1;
    bool lock1 = true;
    bool lock2 = true;
    bool lock3 = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lock1 == true) { ButtonEasy.interactable = false; }
        else { ButtonEasy.interactable = true; }

        if(lock2 == true) { ButtonMedium.interactable = false; }
        else { ButtonMedium.interactable = true; }

        if (lock3 == true) { ButtonHard.interactable = false; }
        else { ButtonHard.interactable = true; }
    }

    public void UpdateTexts(int Dungeon)
    {
        activeDungeon = Dungeon + 1;
        switch (Dungeon)
        {
            case 0:
                lock1 = ScoreSingleton.Instance.Dungeon1LockEasy;
                lock2 = ScoreSingleton.Instance.Dungeon1LockMedium;
                lock3 = ScoreSingleton.Instance.Dungeon1LockHard;
                StatusE.text = ScoreSingleton.Instance.Dungeon1Data[0];
                BestScoreE.text = ScoreSingleton.Instance.Dungeon1Data[1];
                TimeE.text = ScoreSingleton.Instance.Dungeon1Data[2];
                StatusM.text = ScoreSingleton.Instance.Dungeon1Data[3];
                BestScoreM.text = ScoreSingleton.Instance.Dungeon1Data[4];
                TimeM.text = ScoreSingleton.Instance.Dungeon1Data[5];
                StatusH.text = ScoreSingleton.Instance.Dungeon1Data[6];
                BestScoreH.text = ScoreSingleton.Instance.Dungeon1Data[7];
                TimeH.text = ScoreSingleton.Instance.Dungeon1Data[8];
                break;
        }
    }

    public void ChallangeStage(int Difficulty)
    {
        SceneManager.LoadScene(activeDungeon);
    }
}
