using UnityEngine;

namespace StateMachines.EnemyStates {
	public sealed class Dead : State<Enemy> {
		private const float DeathDelay = 2;
		private float timer;

		public override string ShortDescription => "Dead";
		public override string Description => "Dead";

		public Dead(Enemy character) : base(character) { }

		public override State<Enemy> Update() {
			timer += Time.deltaTime;
			if (timer > DeathDelay)
				Object.Destroy(character.gameObject);

			return this;
		}
	}
}