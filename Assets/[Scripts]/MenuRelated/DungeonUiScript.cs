using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonUiScript : MonoBehaviour
{
    public GameObject StartingPosition;
    public GameObject Player;

    public TMP_Text Min;
    public TMP_Text Sec;

    public TMP_Text EnemyKilled;
    public TMP_Text Score;

    [Header("HpRelated")]
    public TMP_Text MaxHp;
    public TMP_Text CurrentHp;
    public Slider HpSlider;


    float t;
    int min;
    int sec;  

    public int enemyKilled = 0;
    public int scoreValue = 0;

    public bool bossKilled = false;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Start is called before the first frame update
    void Start()
    {

        Player.transform.position = StartingPosition.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameSingleton.Instance.currentHp = GameSingleton.Instance.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSingleton.Instance.isPlayerInDungeon == false)
        {
            GameSingleton.Instance.isOnMenu = false;
            Player.transform.position = StartingPosition.transform.position;
            if (Player.transform.position == StartingPosition.transform.position)
            {
                GameSingleton.Instance.isPlayerInDungeon = true;
            }
        }

        t += Time.deltaTime;
        sec = (int)t;

        if(sec >= 60)
        {
            t = 0;
            sec = 0;
            min++;
        }
        Sec.text = sec.ToString();
        Min.text = min.ToString();
        EnemyKilled.text = enemyKilled.ToString();
        Score.text = scoreValue.ToString();

        if(bossKilled == true)
        {

            if(scoreValue> int.Parse(ScoreSingleton.Instance.Dungeon1Data[1]))
            {
                ScoreSingleton.Instance.Dungeon1Data[1] = scoreValue.ToString();
                ScoreSingleton.Instance.Dungeon1Data[2] = min.ToString()+":"+sec.ToString();
                ScoreSingleton.Instance.Dungeon1Data[0] = "Completed";
            }

            SceneManager.LoadScene(0);
        }

        MaxHp.text = GameSingleton.Instance.MaxHp.ToString();
        CurrentHp.text = GameSingleton.Instance.currentHp.ToString();

        HpSlider.maxValue = GameSingleton.Instance.MaxHp;
        HpSlider.value = GameSingleton.Instance.currentHp;

    }

    public void Return()
    {
        SceneManager.LoadScene(0);
        GameSingleton.Instance.isOnMenu = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
