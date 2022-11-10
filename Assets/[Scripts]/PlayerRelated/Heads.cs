using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heads : MonoBehaviour
{
    // Start is called before the first frame update

    public float hp;

    public float def;

    public float str;
    public float agi;
    public float inte;

    public TypeEnmu Type;

    void Start()
    {
        GameSingleton.Instance.MaxHp = hp;
        GameSingleton.Instance.def = def;
        GameSingleton.Instance.str = str;
        GameSingleton.Instance.agi = agi;
        GameSingleton.Instance.inte = inte;

        GameSingleton.Instance.Type = Type;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
