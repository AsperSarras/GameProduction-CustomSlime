using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    [Header("Patrol")]
    public GameObject walkPointPosition;
    public Vector3 walkPoint;

    [Header("Attack")]
    public GameObject projectile;
    public float attackCd;
    bool onCd;

    [Header("States")]
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    [Header("Data")]
    public MonsterEnmu monsExpRelated;
    public int expWorth;
    public int scoreWorth;
    public int CurrentHp;
    public int TotalHp;
    public float Def;
    public TypeEnmu type;
    public TypeEnmu weak;
    public TypeEnmu res;

    [Header("BossRelated")]
    public bool isBoss = false;
    public float attackCd2;
    public bool onCd2 = true;
    public GameObject projectile2;
    public float attackCd3;
    public bool onCd3 = true;
    public GameObject projectile3;
    public bool firstEncounter = false;


    [Header("Others")]
    private ProjectileScript ps;
    public DungeonUiScript DungeonData;
    public GameObject projectileSpawnPoint;
    public Slider HpBar;
    public TMP_Text totalHp;
    public TMP_Text currentHp;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        walkPoint = walkPointPosition.transform.position;

        CurrentHp = TotalHp;

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

    // Update is called once per frame
    void Update()
    {
        HpBar.value = CurrentHp;
        currentHp.text = CurrentHp.ToString();
        HpBar.maxValue = TotalHp;
        totalHp.text = TotalHp.ToString();

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) { Patroll(); }
        if (playerInSightRange && !playerInAttackRange) { Chase(); }
        if (playerInSightRange && playerInAttackRange) { Attack(); }
    }

    private void Patroll()
    {
        agent.SetDestination(walkPoint);
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
        if(isBoss == true)
        {
            if(firstEncounter == false)
            {
                Invoke(nameof(ResetAttack2), attackCd2);
                Invoke(nameof(ResetAttack3), attackCd3);
                firstEncounter = true;
            }
        }
    }

    private void Attack()
    {
        //Stop From Moving
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!onCd)
        {
            Debug.Log("Attack");

            if (isBoss == true)
            {
                if (!onCd3)
                {
                    Shoot(projectile3);
                    Invoke(nameof(ResetAttack3), attackCd3);
                    onCd3 = true;
                }
                else if (!onCd2)
                {
                    Shoot(projectile2);
                    Invoke(nameof(ResetAttack2), attackCd2);
                    onCd2 = true;
                }
                else
                {
                    Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation).GetComponent<EnemyBulletScript>().destination = player.transform.position;
                }
            }
            else
            {
                Shoot(projectile);
                //Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);

            }

            

            //EnemyBulletScript bulletData = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<EnemyBulletScript>();
            //bulletData.enemy = this.gameObject;
            //_rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //_rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            onCd = true;

            Invoke(nameof(ResetAttack), attackCd);
        }
    }

    void Shoot(GameObject proj)
    {
        GameObject projec = Instantiate(proj, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
        projec.GetComponent<EnemyBulletScript>().destination = player.transform.position;
        projec.GetComponent<EnemyBulletScript>().enemy = this.gameObject;
    }

    private void ResetAttack()
    {
        onCd = false;
    }

    private void ResetAttack2()
    {
        onCd2 = false;
    }

    private void ResetAttack3()
    {
        onCd3 = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            ps = collision.gameObject.GetComponent<ProjectileScript>();

            int dmgTaken = (int)ps.dmg - (int)Def;
            if(ps.Type == weak)
            {
                dmgTaken *= 2;
            }
            else if(ps.Type == res)
            {
                dmgTaken /= 2;
            }

            CurrentHp -= dmgTaken;
            if (CurrentHp <= 0)
            {
                DungeonData.enemyKilled++;
                DungeonData.scoreValue += scoreWorth;
                GameSingleton.Instance.ExpGain(monsExpRelated, expWorth);
                if(isBoss==true)
                {
                    DungeonData.bossKilled = true;
                }
                Destroy(gameObject);
            }

            //if(dumy == false)
            //{
            //    CurrentHp -= dmgTaken;
            //    if(CurrentHp <= 0)
            //    {
            //        DungeonData.enemyKilled++;
            //        GameSingleton.Instance.ExpGain(monsExpRelated, expWorth);
            //        Destroy(gameObject);
            //    }
            //}

            Destroy(collision.gameObject);

            Debug.Log("Damage = " + dmgTaken);
        }
    }
}
