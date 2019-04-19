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
			if (enemy == null)
				return new Roaming(character);

			if (enemy.Health.Empty) {
				character.Gold += enemy.Gold;
				return new Roaming(character);
			}

			if (character.Weapon == null)
				return new Roaming(character);

			if (character.Health.Empty)
				return new Dead(character);

			if (character.Stamina.Empty)
				return new GoingHome(character);

			attackTimer += Time.deltaTime;
			if (attackTimer < character.Weapon.Speed) return this;

			enemy.Hit(character);
			attackTimer = 0;

			return this;
		}
	}
}