using UnityEngine;
using System.Collections;
public class LookAt : MonoBehaviour
{
    private Transform Monster;
    private Vector3 targetPosition;
    void Start()
    {
        Monster = GameObject.FindGameObjectWithTag("Monster").transform;
    }
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Dummy").transform);
    }
}
