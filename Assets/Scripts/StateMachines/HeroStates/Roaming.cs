using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace StateMachines.HeroStates {
	public sealed class Roaming : State<Hero> {
		private const int MaxLevelDifference = 5;
		private const float WanderRange = 5;
		private const float WanderCooldown = 3;
		private const float CombatDist = 2;

		private float wanderTimer;
		private readonly NavMeshAgent agent;
		private Enemy nearestEnemy;

		public override string ShortDescription => "Roaming";
		public override string Description => "Roaming";

		public Roaming(Hero owner) : base(owner) {
			agent = owner.GetComponent<NavMeshAgent>();
			agent.stoppingDistance = CombatDist;
		}

		public override State<Hero> Update() {
			// Look for nearest valid enemy
			if (nearestEnemy == null)
				foreach (var enemy in Object.FindObjectsOfType<Enemy>().Where(IsValid))
					if (nearestEnemy == null || (owner.transform.position - enemy.transform.position).magnitude < (owner.transform.position - nearestEnemy.transform.position).magnitude)
						nearestEnemy = enemy;

			// if enemy found
			if (nearestEnemy != null) {
				wanderTimer = 0;

				agent.SetDestination(nearestEnemy.transform.position);
				if ((owner.transform.position - nearestEnemy.transform.position).magnitude > CombatDist)
					return this;

				// if close enough, start combat
				nearestEnemy.State = new EnemyStates.Combat(nearestEnemy, owner);
				return new Combat(owner, nearestEnemy);
			}

			// No enemy found, wander

			// already moving
			if (agent.velocity.magnitude > .1f) return this;

			// Increase timer when not moving
			wanderTimer += Time.deltaTime;
			if (wanderTimer < WanderCooldown) return this;

			// When timer is complete, wander
			wanderTimer = 0;
			agent.SetDestination(WanderRange * Random.insideUnitSphere);

			return this;
		}

		private bool IsValid(Enemy enemy) {
			return !(enemy.State is EnemyStates.Dead) && Mathf.Abs(owner.Level - enemy.Level) < MaxLevelDifference;
		}
	}
}