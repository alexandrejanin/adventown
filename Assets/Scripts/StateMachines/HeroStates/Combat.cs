using UnityEngine;

namespace StateMachines.HeroStates {
	public sealed class Combat : State<Hero> {
		private readonly Enemy enemy;
		private float attackTimer;

		public override string ShortDescription => "In combat";
		public override string Description => $"Fighting {enemy}";

		public Combat(Hero owner, Enemy enemy) : base(owner) {
			this.enemy = enemy;
		}

		public override State<Hero> Update() {
			if (enemy == null)
				return new Roaming(owner);

			if (enemy.Health.Empty) {
				owner.Gold += enemy.Gold;
				return new Roaming(owner);
			}

			if (owner.Weapon == null)
				return new Roaming(owner);

			if (owner.Health.Empty)
				return new Dead(owner);

			if (owner.Stamina.Empty)
				return new GoingHome(owner);


			attackTimer += Time.deltaTime;
			if (attackTimer < owner.Weapon.Speed) return this;

			enemy.Hit(owner);
			attackTimer = 0;

			return this;
		}
	}
}