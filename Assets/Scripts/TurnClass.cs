using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class TurnClass : MonoBehaviour
{
	public GameObject playerGameObject;
	public bool isTurn = false;
	public bool wasTurnPrev = false;
    public bool timerCheck = false;
    public float timer = 0;

    void Update() {
        if (isTurn) {
            timer += Time.deltaTime;
        } else {
            timer = 0;
        }
    }

    public void ResetBool() {
        isTurn = false;
        wasTurnPrev = false;
        timerCheck = false;
        timer = 0;
    }

    public void timeAttackWrappper(float timeLimit) {
        if (!timerCheck) {
            StartCoroutine(timeAttack(timeLimit));
        }
    }

    IEnumerator timeAttack(float timeLimit) {
        timerCheck = true;
        if (!isTurn) {
            yield return null;
        } else {
            yield return new WaitForSeconds(timeLimit);
        }
        timerCheck = false;
        timer = 0;
        playerGameObject.GetComponent<PlayerMovement>().PassTurnClick();
        Debug.Log("TIME OUT");
    }
}