using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTurn : MonoBehaviour
{
	public PlayerMovement playerMovement;
    public GameObject Star;

    // Update is called once per frame
    void Update()
    {
    	if (playerMovement.currentTurn()) {
            GetComponent<Text>().enabled = true;
            Star.SetActive(true);
    		// GetComponent<Text>().text = "Your Turn";
    	} else {
            GetComponent<Text>().enabled = false;
            Star.SetActive(false);
    		// GetComponent<Text>().text = "Enemy Turn";
    	}
    }
}
