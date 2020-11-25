using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerFeature : MonoBehaviour
{
    public GameObject go;
    private SkinnedMeshRenderer smr;
    public bool activatedShield = false;
    public int usingShields = 0;

    void Start()
    {
        smr = go.GetComponent<SkinnedMeshRenderer>();    
    }
    //Death by thorns
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Thorns")){
            if(!activatedShield){
                GameEvents.current.ChangeHealth();
                if(Health.healthCount > 0){
                    GameEvents.current.RestartLevel();
                }
            }
            
        }

        if(other.gameObject.CompareTag("Princess")){
            GameEvents.current.InTouchPrincess();
        }

        if(other.gameObject.CompareTag("Shield")){
            GameEvents.current.GetShield();
            activatedShield = true;
            usingShields++;
            StartCoroutine(Waiter());
            StartCoroutine(Blinking());
        }
    }
    
    IEnumerator Waiter(){
        yield return new WaitForSeconds(10f);
        usingShields--;
        if(usingShields >= 1)  {
            yield return new WaitForSeconds(10f);
        }  
        activatedShield = false;
    }

    IEnumerator Blinking ()
    {
        while (activatedShield)
        {
            smr.enabled = !smr.enabled;
            yield return new WaitForSeconds(0.2f);
        }
        smr.enabled = true;
    }
}