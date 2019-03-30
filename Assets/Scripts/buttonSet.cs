using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonSet : MonoBehaviour
{
	public Button thisButton;
	public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
    	gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (thisButton.name == "Play_Button") {
	        thisButton.onClick.AddListener(gameManager.PlayButtonClick);
        } else {
        	thisButton.onClick.AddListener(gameManager.PlayTutorialText);
        }

    }
}
