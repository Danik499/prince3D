using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public GameObject axis;
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(axis.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
