using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShield : MonoBehaviour
{
    public float Speed = 60f;
    public Vector3 Axe;

    void Start()
    {
        Axe = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Axe, Speed * Time.deltaTime);
    }
}
