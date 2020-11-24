using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
     void Start()
    {
        GameEvents.current.getShield += GetShield;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Object.Destroy(gameObject);
        }
    }

    private void GetShield(){
        Debug.Log("Shield is activated");    
    }
        
}
