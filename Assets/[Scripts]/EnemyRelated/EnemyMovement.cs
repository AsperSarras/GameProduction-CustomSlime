using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    [Header("Patrol")]
    public GameObject walkPointPosition;
    public Vector3 walkPoint;

    [Header("Attack")]
    public float attackCd;
    bool onCd;

    [Header("States")]
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    public GameObject projectile;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        walkPoint = walkPointPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void Attack()
    {
        //Stop From Moving
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!onCd)
        {

            Debug.Log("Attack");

            Rigidbody _rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            _rb.AddForce(transform.forward * 32f,ForceMode.Impulse);
            _rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            onCd = true;
            Invoke(nameof(ResetAttack), attackCd);
        }
    }

    private void ResetAttack()
    {
        onCd = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
