using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] private Transform target;
    private Vector3 lastKnownPosition;
    [SerializeField] private Transform eye;
    private bool patrolling;
    [SerializeField] private Transform[] patrolTargets;
    private int destPoint;
    private bool arrived;
    [SerializeField] private float seeDistance;
    [SerializeField] private float fieldOfViewAngle;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        lastKnownPosition = transform.position;
    }

    private bool CanSeeTarget()
    {
        bool canSee = false;
        Vector3 rayDirection = target.transform.position - eye.position;
        Ray ray = new Ray(eye.position, rayDirection);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, seeDistance))
        {
            if(hit.transform == target && Vector3.Angle(rayDirection, transform.forward) < fieldOfViewAngle)
            {
                canSee = true;
                lastKnownPosition = target.transform.position;
            }
        }
        return canSee;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathPending) return;

        if (patrolling)
        {
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                if (!arrived)
                {
                    arrived = true;
                    StartCoroutine(GoToNextPoint());
                }
            }
            else
            {
                arrived = false;
            }
        }

        if (CanSeeTarget())
        {
            agent.SetDestination(target.transform.position);
            patrolling = false;
            anim.SetBool("Attack", agent.remainingDistance <= agent.stoppingDistance);
        }
        else
        {
            anim.SetBool("Attack", false);
            if (!patrolling)
            {
                agent.SetDestination(lastKnownPosition);
                if(agent.remainingDistance < agent.stoppingDistance)
                {
                    patrolling = true;
                    StartCoroutine(GoToNextPoint());
                }
            }
        }
        anim.SetFloat("Forward", agent.velocity.sqrMagnitude);
    }

    private IEnumerator GoToNextPoint()
    {
        if(patrolTargets.Length == 0) yield break;

        patrolling = true;
        yield return new WaitForSeconds(2f);
        arrived = false;
        agent.destination = patrolTargets[destPoint].position;
        destPoint = (destPoint + 1) % patrolTargets.Length;
    }
}
