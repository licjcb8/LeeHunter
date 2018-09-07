using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public ItemBox itembox;
    public GameObject IngredientPrefab;
    public GameObject DeathEffect;

    public Transform DeathPos;
    public Transform RespawnPos;
    public float accumulator = 0.0f;

    public float Respawn = 5.0f;
    public int RespawnDone = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (RespawnDone == 1)
        {
            accumulator += Time.deltaTime;
        }
        if (accumulator >= Respawn)
        {
            transform.position = RespawnPos.transform.position;
            RespawnDone = 0;
            accumulator = 0.0f;
        }
        }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            
            itembox.GiveItem(GameManager.GetInstance().m_cPlayer);
            if (itembox.Drop)
            {
                Instantiate(IngredientPrefab, transform.position, transform.rotation);
                Instantiate(DeathEffect, transform.position, transform.rotation);
            }
            RespawnBox();
        }
    }


    void RespawnBox()
    {
        transform.position = DeathPos.transform.position;
        RespawnDone = 1;
    }

}
