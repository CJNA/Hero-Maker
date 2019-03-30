using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPanel : MonoBehaviour
{
    // Update is called once per frame
    void OnEnable()
    {
        Time.timeScale = 0.0f;
    }

  	public void disablePanel() {
  		Time.timeScale = 1.0f;
  		this.gameObject.SetActive(false);
  	}
}
