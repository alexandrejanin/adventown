using UnityEngine;

namespace StateMachines.EnemyStates {
	public sealed class Combat : State<Enemy> {
		private Hero Hero { get; }
		private float AttackTimer { get; set; }

		public override string ShortDescription => "In combat";
		public override string Description => $"Fighting {Hero}";

		public Combat(Enemy character, Hero hero) : base(character) => Hero = hero;

		public override State<Enemy> Update() {
			if (character.Health.Empty)
				return new Dead(character);

			if (Hero == null || Hero.Health.Empty || Hero.Stamina.Empty)
				return new Idle(character);

			AttackTimer += Time.deltaTime;

			if (AttackTimer >= character.Speed) {
				Hero.Hit(character);
				AttackTimer = 0;
			}

			return this;
		}
	}
}