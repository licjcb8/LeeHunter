using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {
    public ItemBox itembox;
    public GameObject IngredientPrefab;
    public bool isDie = false;
    public enum State { Idle, Chasing, Attacking };
    State currentState;

    public Transform DeathPos;
    public Transform RespawnPos;

    public float hp = 100;
    public float hpmax = 100;
    public float atk = 30;
    public int exp = 50;


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

    public float accumulator = 0.0f;
    
    public float Respawn = 3.0f;
    public int RespawnDone = 0;

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
        if (RespawnDone == 1)
        {
            accumulator += Time.deltaTime;
        }
        if (accumulator >= Respawn)
        {
            transform.position = RespawnPos.transform.position;
            RespawnDone = 0;
            accumulator = 0.0f;
            GetComponent<NavMeshAgent>().enabled = true;
            pathfinder.enabled = true;

        }
        if (hp <= 0)
        {
            isDie = true;
            itembox.GiveItem(GameManager.GetInstance().m_cPlayer);
            if (itembox.Drop)
            {
                Instantiate(IngredientPrefab);
            }
        }
        Dead();
    }

    void Dead()
    {
        if (isDie)
        {
            isDie = false;
            GetComponent<NavMeshAgent>().enabled = false;
            pathfinder.enabled = false;
            hp = hpmax;
            GameManager.GetInstance().m_cPlayer.exp = GameManager.GetInstance().m_cPlayer.exp + exp;
            RespawnMonster();
            
            //   Instantiate(Bone, gameObject.transform.position, gameObject.transform.rotation);
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
                if (hp >= 0&& isDie ==false)
                {
                    pathfinder.SetDestination(targetPosition);
                }
            }
            
            yield return new WaitForSeconds(refreshRate);
        }
    }

    void RespawnMonster()
    {
        transform.position = DeathPos.transform.position;

        RespawnDone = 1;

    }

}
