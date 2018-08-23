using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GunController))]
public class Gun : MonoBehaviour {

    Camera viewCamera;
    GunController controller;
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
}
