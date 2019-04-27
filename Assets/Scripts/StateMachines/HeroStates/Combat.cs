using UnityEngine;

namespace StateMachines.HeroStates {
	public sealed class Combat : State<Hero> {
		private readonly Enemy enemy;
		private float attackTimer;

		public override string ShortDescription => "In combat";
		public override string Description => $"Fighting {enemy}";

		public Combat(Hero character, Enemy enemy) : base(character) {
			this.enemy = enemy;
		}

		public override State<Hero> Update() {
			// somehow no enemy? roam
			if (enemy == null)
				return new Roaming(character);

			// Enemy dead, loot and lose stamina
			if (enemy.Health.Empty) {
				character.Gold += enemy.Gold;
				character.Stamina -= 1;
				return new Roaming(character);
			}

			// Somehow no weapon ? roam
			if (character.Weapon == null)
				return new Roaming(character);

			// Health empty, die
			if (character.Health.Empty)
				return new Dead(character);


			attackTimer += Time.deltaTime;
			if (attackTimer < character.Weapon.Speed) return this;

			enemy.Hit(character);
			attackTimer = 0;

			return this;
		}
	}
}