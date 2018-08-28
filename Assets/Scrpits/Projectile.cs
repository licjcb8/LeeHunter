using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

   public float speed = 1;
    float bulletdmg = 30;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Monster")
        {
            //Rigidbody rigidbodyTarget = other.gameObject.GetComponent<Rigidbody>();
            other.gameObject.GetComponent<Monster>().hp = other.gameObject.GetComponent<Monster>().hp - bulletdmg;
         //   other.gameObject.GetComponent<Monster>().hit = 1;
            //rigidbodyTarget.AddForce(transform. * (speed - 500));
            Destroy(gameObject);

        }
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}

