using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    public GameObject body;

    //Arms and Head List
    public List<GameObject> Arms;
    public List<GameObject> Heads;
    //Left

    public GameObject armL;
    public GameObject ArmLP;
    public GameObject ArmLSP;
    public Arms armLS;
    //Right
    public GameObject armR;
    public GameObject ArmRP;
    public GameObject ArmRSP;
    public Arms armRS;

    //Head
    public GameObject Head;
    public GameObject HeadP;
    public Heads HeadS;

    public TypeEnmu type;
    public TypeEnmu weak;
    public TypeEnmu res;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        armL = Instantiate(Arms[0], ArmLP.transform.position, ArmLP.transform.rotation);
        armL.transform.parent = body.transform;
        armLS = armL.GetComponent<Arms>();
        armLS.spawnPos = ArmLSP;

        armR = Instantiate(Arms[0], ArmRP.transform.position, ArmRP.transform.rotation);
        armR.transform.parent = body.transform;
        armRS = armR.GetComponent<Arms>();
        armRS.spawnPos = ArmRSP;

        Head = Instantiate(Heads[0], HeadP.transform.position, HeadP.transform.rotation);
        Head.transform.parent = body.transform;
        HeadS = Head.GetComponent<Heads>();

        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateType();

        if (Input.GetMouseButtonDown(0))
        {
            armLS.Attack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            armRS.Attack();
        }
    }

    public void HandChangeL(int aCode)
    {
        Vector3 tempPosL = armL.transform.position;
        Quaternion tempRotL = armL.transform.rotation;

        Destroy(armL);
        armL = null;

        armL = Instantiate(Arms[aCode], tempPosL, tempRotL);
        armL.transform.parent = body.transform;
        armLS = armL.GetComponent<Arms>();
        armLS.spawnPos = ArmLSP;
    }

    public void HandChangeR(int aCode)
    {
        Vector3 tempPosR = armR.transform.position;
        Quaternion tempRotR = armR.transform.rotation;

        Destroy(armR);
        armR = null;

        armR = Instantiate(Arms[aCode], tempPosR, tempRotR);
        armR.transform.parent = body.transform;
        armRS = armR.GetComponent<Arms>();
        armRS.spawnPos = ArmRSP;
    }

    public void HeadChange(int aCode)
    {
        Vector3 tempPosH = Head.transform.position;
        Quaternion tempRotH = Head.transform.rotation;

        Destroy(Head);
        Head = null;

        Head = Instantiate(Heads[aCode], tempPosH, tempRotH);
        Head.transform.parent = body.transform;
        HeadS = Head.GetComponent<Heads>();
    }

    public void UpdateType()
    {
        type = GameSingleton.Instance.Type;

        if (type == TypeEnmu.WATER)
        {
            weak = TypeEnmu.EARTH;
            res = TypeEnmu.FIRE;
        }
        else if (type == TypeEnmu.FIRE)
        {
            weak = TypeEnmu.WATER;
            res = TypeEnmu.EARTH;
        }
        else if (type == TypeEnmu.EARTH)
        {
            weak = TypeEnmu.FIRE;
            res = TypeEnmu.WATER;
        }
        else
        {
            weak = TypeEnmu.NONE;
            res = TypeEnmu.NONE;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            EnemyBulletScript ps = collision.gameObject.GetComponent<EnemyBulletScript>();

            float dmgTaken = ps.dmg - GameSingleton.Instance.def;
            if(dmgTaken <= 0) { dmgTaken = 1; }

            if (ps.Type == weak)
            {
                dmgTaken *= 2;
            }
            else if (ps.Type == res)
            {
                dmgTaken /= 2;
            }

            GameSingleton.Instance.currentHp -= dmgTaken;

            if (GameSingleton.Instance.currentHp <= 0)
            {
                SceneManager.LoadScene(0);
            }

            Destroy(collision.gameObject);

            Debug.Log("Damage = " + dmgTaken);
        }
    }
}
