using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GunController))]
public class Gun : MonoBehaviour {

    Camera viewCamera;
    GunController controller;
    public AudioClip Sound;
    public Transform muzzle;
    public Projectile projectile;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;
    float nextShotTime;


    // Use this for initialization
    void Start () {
        controller = GetComponent<GunController>();
        viewCamera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            controller.LookAt(point);
        }
       
    }

    public void SoundPlay()
    {
        GetComponent<AudioSource>().clip = Sound;
        GetComponent<AudioSource>().Play();
    }

    public void Shoot()
    {

        if (Time.time > nextShotTime)
        {
            SoundPlay();
            nextShotTime = Time.time + msBetweenShots / 1000;
          
            
                Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
                newProjectile.SetSpeed(muzzleVelocity);
             
        }
    }

}
