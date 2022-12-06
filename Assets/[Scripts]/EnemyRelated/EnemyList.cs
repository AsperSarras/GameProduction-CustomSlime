using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<GameObject> listEnemies;
    public List<GameObject> listEnemiesPos;
    // Start is called before the first frame update
    void Start()
    {
        AciveEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AciveEnemies()
    {
        for (int i = 0; i < ScoreSingleton.Instance.ActiveEnemies; i++)
        {
            listEnemies[i].SetActive(true);
            listEnemies[i].GetComponent<Enemy>().walkPoint = listEnemiesPos[i].transform.position;
        }
    }

}
