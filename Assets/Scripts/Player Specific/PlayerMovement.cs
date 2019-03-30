using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public TurnSystem turnSystem;
	public TurnClass turnClass;
    public GameManager gameManager;
	public bool isTurn = false;
    public bool passTurn = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    	turnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
        foreach(TurnClass tc in turnSystem.playersGroup) {
        	if (tc.playerGameObject.name == gameObject.name) {
        		turnClass = tc;
        	}
        }
    }

    // Update is called once per frame
    void Update()
    {
        isTurn = turnClass.isTurn;
        if (passTurn && isTurn)
        {
        	isTurn = false;
        	turnClass.isTurn = isTurn;
        	turnClass.wasTurnPrev = true;
            passTurn = false;
            gameManager.TurnPassed();
        }
    }

    public void PassTurnClick() {
        if (isTurn) {
            passTurn = true;
        }
    }

    public bool currentTurn() {
        return isTurn;
    }
}
