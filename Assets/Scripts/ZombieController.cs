using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{

    [SerializeField] public Transform[] points;
    [SerializeField] public Transform target;
    private int currentPoint = 0;
    NavMeshAgent agent;
    private enum State {Patrol, Follow, Attack}
    [SerializeField]
    private State currentState = State.Patrol;
    Vector3 directionToPlayer;
    private bool inSight;
    [SerializeField]
    private float maxFollowDist;
    [SerializeField]
    private float attackDistance;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(points[currentPoint].position);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("distance to point " + (points[currentPoint].transform.position - gameObject.transform.position).magnitude);
        CheckForPlayer();
        UpdateStates();
    }
    public void Patrol() 
    {
        if (agent.destination != points[currentPoint].position)
        {
            agent.destination = points[currentPoint].position;
        }
        if (HasReached())
        {
            currentPoint = (currentPoint + 1) % points.Length;
        }
        if (inSight && directionToPlayer.magnitude <= maxFollowDist)
        {
            currentState = State.Follow;
            Debug.Log("ToFollow");
            animator.SetBool("IsFollowing", true);
        }
    }
    public void Follow()
    {
        if (directionToPlayer.magnitude <= attackDistance && inSight)
        {
            agent.ResetPath();
            animator.SetBool("Attacks", true);
            currentState = State.Attack;
        }
        else
        {
            if (target != null && directionToPlayer.magnitude <= maxFollowDist)
            {
                agent.SetDestination(target.position);
            }
            else
            {
                currentState = State.Patrol;
                animator.SetBool("IsFollowing", false);
            }
        }
    }
    public void Attack()
    {
        if (!inSight || directionToPlayer.magnitude > attackDistance)
        {
            currentState = State.Follow;
            animator.SetBool("Attacks",false);
        }
        //LookAtTarget();
    }
    private void UpdateStates()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Follow:
                Follow();
                break;
        }
    }
    private void CheckForPlayer()
    {
        
        directionToPlayer = target.position - transform.position;
        //Debug.Log(directionToPlayer.magnitude);
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hitInfo))
        {
            inSight = hitInfo.transform.gameObject == target.gameObject;
            Debug.DrawRay(transform.position, directionToPlayer.normalized);
            if (inSight)
                Debug.Log("player sighted");
        }
    }
    public bool HasReached()
    {
        return (points[currentPoint].transform.position - gameObject.transform.position).magnitude <= 1f;
           
    }
    public void LookAtTarget()
    {
        Vector3 lookDirection = directionToPlayer;
        lookDirection.y = 0f;

        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
    }

}
