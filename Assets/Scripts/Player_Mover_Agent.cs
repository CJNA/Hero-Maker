using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mover_Agent : MonoBehaviour
{
	public float gravity = 5.0F;
	public float speedOffset = 5.0F;
    public float applyAgilityOffset = 0.05f;
	
	private Vector3 moveDirection = Vector3.zero;

   	public Transform target;
    public float _turnSpeed = 1;
	public PlayerStatistics playerStat;

    private UnityEngine.AI.NavMeshAgent _agent;
    private Vector3 _desVelocity;
    private CharacterController _charControl;
    private Animator anim;

    void Start() {

        this._agent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        this._charControl = this.gameObject.GetComponent<CharacterController>();

        this._agent.destination = this.target.position;

      	this._agent.updatePosition = true;
        this._agent.updateRotation = true;

        anim = GetComponent<Animator>();
		if (anim == null) {
			anim = GetComponentInParent<Animator>();
		}

		playerStat = GetComponent<AIBehaviorExamples.PlayerStats>().playerStat;

        return;
    }

    void Update() {

    	moveDirection.y -= gravity * Time.deltaTime;
		_charControl.Move(moveDirection * Time.deltaTime);

        // Vector3 lookPos;
        // Quaternion targetRot;

        // this._agent.destination = this.target.position;
        // this._desVelocity = this._agent.desiredVelocity;

        // lookPos = this.target.position - this.transform.position;
        // lookPos.y = 0;
        // // Debug.Log(lookPos);
        // targetRot = Quaternion.LookRotation(lookPos);
       	
        // this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * this._turnSpeed);

        if (anim.GetFloat("Speed") > 0.01) {
			// Vector3 directionalForce = Quaternion.AngleAxis(anim.GetFloat("Direction"), Vector3.up) * Vector3.forward;
			// // controller.Move(directionalForce * Time.deltaTime * (playerStat.agility + 1) * anim.GetFloat("Speed"));
			// // controller.Move(directionalForce * Time.deltaTime * speedOffset * anim.GetFloat("Speed"));
	  //       // this._charControl.Move(directionalForce.normalized * speedOffset * Time.deltaTime);
	  //       this._charControl.Move(_desVelocity.normalized * (speedOffset + (float)playerStat.agility * applyAgilityOffset) * Time.deltaTime);
		}

        // this._agent.velocity = this._charControl.velocity;

        return;
    }
}
