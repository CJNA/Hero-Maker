using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCharacter : MonoBehaviour
{
	public int hpRecovery;
    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
    	if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "P2") {
    		Debug.Log("This runs?");
	     	collider.gameObject.GetComponent<AIBehaviorExamples.PlayerStats>().HealHP(hpRecovery);
     		Destroy(this.gameObject);	   
    	}
    }
}
	