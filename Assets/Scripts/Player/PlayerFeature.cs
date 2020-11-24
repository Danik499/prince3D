using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerFeature : MonoBehaviour
{
    public bool activatedShield = false;
    public int usingShields = 0;

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
        }
    }
    
    IEnumerator Waiter(){
        yield return new WaitForSeconds(10f);
        usingShields--;
        if(usingShields >= 1)  {
            yield return new WaitForSeconds(10f);
        }  
        activatedShield = false;
        Debug.Log("deactivated");
    }
}
