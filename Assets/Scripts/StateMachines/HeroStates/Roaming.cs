using System.Linq;
using StateMachines.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace StateMachines.HeroStates {
	// Hero is idle, looking for their next fight
	public sealed class Roaming : State<Hero> {
		private const int MaxLevelDifference = 3;

		private const float WanderRange = 5;
		private const float WanderCooldown = 3;
		private const float CombatDist = 2;

		private float wanderTimer;
		private readonly NavMeshAgent agent;
		private Enemy nearestEnemy;

		public override string ShortDescription => "Roaming";
		public override string Description => "Roaming";

		public Roaming(Hero character) : base(character) {
			agent = character.GetComponent<NavMeshAgent>();
			agent.stoppingDistance = CombatDist;
		}

		public override State<Hero> Update() {
			if (character.Stamina.Empty)
				return new GoingHome(character);

			// Look for nearest valid enemy
			if (nearestEnemy == null)
				foreach (var enemy in Object.FindObjectsOfType<Enemy>().Where(IsValid))
					if (
						nearestEnemy == null ||
						(character.transform.position - enemy.transform.position).magnitude
						< (character.transform.position - nearestEnemy.transform.position).magnitude
					)
						nearestEnemy = enemy;

			// if enemy found
			if (nearestEnemy != null) {
				wanderTimer = 0;

				// Set enemy as taken, walk towards them
				((Idle) nearestEnemy.State).Taken = true;
				agent.SetDestination(nearestEnemy.transform.position);
				// too far, still return Roaming
				if ((character.transform.position - nearestEnemy.transform.position).magnitude > CombatDist)
					return this;

				// if close enough, start combat
				nearestEnemy.StartCombat(character);
				return new Combat(character, nearestEnemy);
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
			if (!(enemy.State is Idle state) || state.Taken) {
				return false;
			}

			if (Mathf.Abs(character.Level - enemy.Level) > MaxLevelDifference)
				return false;

			return true;
		}
	}
}