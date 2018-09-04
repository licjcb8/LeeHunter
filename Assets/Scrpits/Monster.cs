using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {
    public ItemBox itembox;
    public GameObject IngredientPrefab;
    public GameObject DeathEffect;
    public bool isDie = false;
    public enum State { Idle, Chasing, Attacking };
    State currentState;

    public Transform DeathPos;
    public Transform RespawnPos;
    public Rigidbody monster;

    public float hp = 100;
    public float hpmax = 100;
    public float atk = 30;
    public int exp = 50;

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

    public float m_fMinDist = 2;
    public float m_fDist = 0;


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
          

        }
        if (hp <= 0)
        {
            isDie = true;
            itembox.GiveItem(GameManager.GetInstance().m_cPlayer);
            if (itembox.Drop)
            {
                Instantiate(IngredientPrefab,transform.position,transform.rotation);
                Instantiate(DeathEffect, transform.position, transform.rotation);
            }
        }
        Dead();
    }

    void Dead()
    {
        if (isDie==true)
        {
            isDie = false;
            GetComponent<NavMeshAgent>().enabled = false;
            
            hp = hpmax;
            m_fMinDist = 2;
            GameManager.GetInstance().m_cPlayer.exp = GameManager.GetInstance().m_cPlayer.exp + exp;
            RespawnMonster();
            
            //   Instantiate(Bone, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    IEnumerator Attack()
    {
        if (GetComponent<NavMeshAgent>().enabled==true)
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
    }


    IEnumerator UpdatePath()
    {
        if (GetComponent<NavMeshAgent>().enabled == true)
        {
            float refreshRate = .25f;

            while (target != null)
            {
                if (currentState == State.Chasing)
                {

                    //Vector3 dirToTarget = (target.position - transform.position).normalized;
                    //Vector3 targetPosition = target.position - dirToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2);
                    //if (hp >= 0)
                    //{
                    //    pathfinder.SetDestination(targetPosition);
                    //}
                    Vector3 vTargetPos = target.position;
                    Vector3 vPos = transform.position;
                    m_fDist = Vector3.Distance(vTargetPos, vPos);
                    if (m_fDist < m_fMinDist)
                        pathfinder.SetDestination(vTargetPos);
                }

                yield return new WaitForSeconds(refreshRate);
            }
        }
    }

    void RespawnMonster()
    {
        transform.position = DeathPos.transform.position;
        monster.isKinematic = false;
        monster.isKinematic = true;
        RespawnDone = 1;

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            m_fMinDist = 100;
        }
    }
}
