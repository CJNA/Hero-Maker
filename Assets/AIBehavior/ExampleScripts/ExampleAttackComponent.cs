using UnityEngine;
using AIBehavior;


namespace AIBehaviorExamples
{
	public class ExampleAttackComponent : MonoBehaviour
	{
		public GameObject projectilePrefab;
		public Transform launchPointWeapon;
		public float aimMetersAboveTarget = 1.5f;
		public PlayerStatistics playerStat;

		void Start() {
			playerStat = GetComponent<AIBehaviorExamples.PlayerStats>().playerStat;
		}

		public void MeleeAttack(AttackData attackData)
		{
			Debug.Log ("Melee attack");
			// attackData.target.SendMessage("Damage", CalculateDamage(attackData));
			attackData.target.SendMessage("Damage", CalculateDamage(attackData));
		}

		float CalculateDamage(AttackData attackData)
		{
			float minDamage = playerStat.attackPower;
			float maxDamage = playerStat.attackPower;

			return Random.Range (minDamage, maxDamage);
		}
	}
}