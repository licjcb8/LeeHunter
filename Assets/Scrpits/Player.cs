using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GunController))]
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    public float moveSpeed = 5;
    PlayerController controller;
    GunController gunController;

    public float hp = 100;
    public float dmg;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
    }

    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);
        if (Input.GetMouseButton(0))
        {

            gunController.Shoot();

        }
        Dead();
    }

    void Dead()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Monster")
        {
            dmg = collision.gameObject.GetComponent<Monster>().atk;
            if (dmg <= 0)
            {
                dmg = 0;
            }
            hp = hp - dmg;
        }

        if (collision.collider.tag == "Item")
        {
            Destroy(collision.gameObject);
        }

    }

}

