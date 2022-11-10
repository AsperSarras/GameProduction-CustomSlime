using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;

    public float atk;
    public float dmg;
    public TypeEnmu Type = TypeEnmu.WATER;

    public float pSpeed;

    public StatsEnum scalingStats;
    public float scaling1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * pSpeed, ForceMode.Impulse);

        switch (scalingStats)
        {
            case StatsEnum.STR:
                dmg = atk + GameSingleton.Instance.str * scaling1;
                break;
            case StatsEnum.AGI:
                dmg = atk + GameSingleton.Instance.agi * scaling1;
                break;
            case StatsEnum.INT:
                dmg = atk + GameSingleton.Instance.inte * scaling1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }

        
    }
}
