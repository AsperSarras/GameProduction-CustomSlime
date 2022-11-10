using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBulletScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public GameObject enemy;

    public float atk;
    public float dmg;
    public TypeEnmu Type = TypeEnmu.WATER;

    public float pSpeed;

    public Vector3 destination;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, pSpeed * Time.deltaTime);
        if(transform.position == destination)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != enemy)
        {
            Destroy(gameObject);
            //if(collision.gameObject.tag == "Player")
            //{

            //    GameSingleton.Instance.currentHp = -dmg;
            //}
        }

        //if (collision.gameObject.layer == 10)
        //{
        //    Destroy(gameObject);
        //}
        
    }
}
