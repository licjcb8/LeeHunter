using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {
    public enum State { Idle, Chasing, Attacking };
    State currentState;


    public float hp = 100;
    public float atk = 30;
    public GameObject Bone;
    NavMeshAgent pathfinder;
    Transform target;

    Material skinMaterial;

    Color originalColour;

    float attackDistanceThreshold = 1.5f;
    float timeBetweenAttacks = 1;

    float nextAttackTime;
    float myCollisionRadius=0;
    float targetCollisionRadius=0;

    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        skinMaterial = GetComponent<Renderer>().material;
        originalColour = skinMaterial.color;
        currentState = State.Chasing;
        target = GameObject.FindGameObjectWithTag("Player").transform;
     
      //  myCollisionRadius = GetComponent<CapsuleCollider>().radius;
        //targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;

        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        if (Time.time > nextAttackTime)
        {
            float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
            if (sqrDstToTarget < Mathf.Pow(attackDistanceThreshold + myCollisionRadius + targetCollisionRadius, 2))
            {
                nextAttackTime = Time.time + timeBetweenAttacks;
                StartCoroutine(Attack());
            }

        }
        Dead();
    }

    void Dead()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(Bone, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    IEnumerator Attack()
    {


        currentState = State.Attacking;
        pathfinder.enabled = false;

        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        Vector3 attackPosition = target.position - dirToTarget * (myCollisionRadius);

        float attackSpeed = 3;
        float percent = 0;

        skinMaterial.color = Color.red;

        while (percent <= 1)
        {

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);

            yield return null;
        }

        skinMaterial.color = originalColour;
        currentState = State.Chasing;
        pathfinder.enabled = true;
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (target != null)
        {
            if (currentState == State.Chasing)
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2);
                if (hp >= 0)
                {
                    pathfinder.SetDestination(targetPosition);
                }
            }
            
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
