using UnityEngine;

namespace StateMachines.EnemyStates {
	public sealed class Combat : State<Enemy> {
		private Hero Hero { get; }
		private float AttackTimer { get; set; }

		public override string ShortDescription => "In combat";
		public override string Description => "Combat";

		public Combat(Enemy owner, Hero hero) : base(owner) => Hero = hero;

		public override State<Enemy> Update() {
			if (owner.Health.Empty)
				return new Dead(owner);

			if (Hero == null || Hero.Health.Empty || Hero.Stamina.Empty)
				return new Idle(owner);

			AttackTimer += Time.deltaTime;

			if (AttackTimer >= owner.Speed) {
				Hero.Hit(owner);
				AttackTimer = 0;
			}

			return this;
		}
	}
}