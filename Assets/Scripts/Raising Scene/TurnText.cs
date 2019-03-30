using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnText : MonoBehaviour
{
	public GameManager gameManager;

    // Update is called once per frame

    void Start() {
    	gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        GetComponent<Text>().text = "Fight in:" + (gameManager.TotalTurnUntilFight() - gameManager.CurrentTotalTurn()).ToString();
    }
}
