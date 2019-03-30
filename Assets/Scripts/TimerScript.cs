using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
	public TurnClass turnClass;
	public int totalTime = 10;
    // Start is called beforethe first frame update

    // Update is called once per frame
    void Update()
    {
		if (turnClass.timer != 0) {
			GetComponent<Text>().enabled = true;
			GetComponent<Text>().text = "Timer : " + (totalTime - (int)turnClass.timer).ToString();
		} else {
			GetComponent<Text>().enabled = false;
		}        
    }
}
