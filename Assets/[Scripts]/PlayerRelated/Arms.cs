using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    // Start is called before the first frame update

    //public float atk;
    public GameObject projectile;
    public GameObject spawnPos;
    //public List<string> type;

    //
    //public KeyCode AttackKey;
    public float AttackCd;
    public float AttackCounter;
    bool canAttack = true;



    void Start()
    {
        //GameSingleton.Instance.atk = atk;
    }

    // Update is called once per frame
    void Update()
    {
        if(canAttack == false)
        {
            AttackCounter += Time.deltaTime;
            if(AttackCounter >= AttackCd)
            {
                canAttack = true;
                AttackCounter = 0;
            }
        }
    }

    public void Attack()
    {
        if (GameSingleton.Instance.isOnMenu == false)
        {
            if (canAttack)
            {
                Instantiate(projectile, spawnPos.transform.position, spawnPos.transform.rotation);
                canAttack = false;
            }
            else
            {
                Debug.Log("On CD");
            }
        }
    }    
}
