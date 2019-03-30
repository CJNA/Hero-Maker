﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
	public List<TurnClass> playersGroup = new List<TurnClass>(2);
    public float timeLimit;
    // Start is called before the first frame update
    void Start()
    {
    	ResetTurns();   
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTurns();
    }

    void ResetTurns() {
    	for (int i = 0; i< playersGroup.Count; i++) {
    		if (i == 0) {
    			playersGroup[i].isTurn = true;
    			playersGroup[i].wasTurnPrev = false;
    		} else {
    			playersGroup[i].isTurn = false;
    			playersGroup[i].wasTurnPrev = false;
    		}
    	}
    }

    void UpdateTurns() {
    	for (int i = 0; i < playersGroup.Count; i++) {
    		if (!playersGroup[i].wasTurnPrev) {
    			playersGroup[i].isTurn = true;
                playersGroup[i].timeAttackWrappper(timeLimit);
    			break;
    		} else if (i == playersGroup.Count - 1 && playersGroup[i].wasTurnPrev) {
    			ResetTurns();
    		}
    	}
    }
}
