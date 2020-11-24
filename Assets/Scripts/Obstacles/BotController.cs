using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public Vector3 a;
    public Vector3 b;
    private Vector3 currentDirection;

    private Animator anim;
    public float speed;
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = a;
        transform.LookAt(b);
        currentDirection = b;
    }
     
    void Update()
    {
        anim.SetFloat("Speed", speed);

        transform.position += transform.forward * speed * Time.deltaTime;
        if (currentDirection == b && (Mathf.Abs(currentDirection.x - transform.position.x) < 0.05f))
        { 
                transform.LookAt(a);
                currentDirection = a;
        }
        else
        {
            if (Mathf.Abs(currentDirection.x - transform.position.x) < 0.05f)
            {
                transform.LookAt(b);
                currentDirection = b;
            }
        }
    }
}
