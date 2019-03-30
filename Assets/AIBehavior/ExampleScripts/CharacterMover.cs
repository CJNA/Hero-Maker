using UnityEngine;
using System.Collections;

namespace AIBehaviorExamples
{
	public class CharacterMover : MonoBehaviour
	{
		public float gravity = 20.0F;
		public float speedOffset = 5.0F;
		
		private Vector3 moveDirection = Vector3.zero;
		private CharacterController controller;
		private Animator anim;

		void Start ()
		{	
			controller = GetComponent<CharacterController>();
			if (controller == null)
				controller = GetComponentInParent<CharacterController> ();

			anim = GetComponent<Animator>();
			if (anim == null) {
				anim = GetComponentInParent<Animator>();
			}
		}

		void Update()
		{
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);

			if (anim.GetFloat("Speed") > 0.01) {
				Vector3 directionalForce = Quaternion.AngleAxis(anim.GetFloat("Direction"), Vector3.up) * Vector3.forward;
				controller.Move(directionalForce * Time.deltaTime * speedOffset * anim.GetFloat("Speed"));
			}
		}
	}
}