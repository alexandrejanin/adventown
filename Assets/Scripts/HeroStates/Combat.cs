namespace HeroStates {
	public sealed class Combat : HeroState {
		private Enemy Enemy { get; }
		private float Timer { get; set; }

		public Combat(Hero hero, Enemy enemy) : base(hero) {
			Enemy = enemy;
		}

		public override HeroState Update(float deltaTime) {
			if (Enemy.Health.Empty)
				return new Roaming(Hero, 2);

			if (Hero.Weapon == null)
				return new Roaming(Hero, 2);

			if (Hero.Health.Empty)
				return new Dead(Hero);


			Timer += deltaTime;

			if (Timer >= Hero.Weapon.Speed) {
				Enemy.Hit(Hero.Weapon);
				Timer = 0;
			}

			return this;
		}

		public override string ToString() {
			return $"Fighting {Enemy}";
		}
	}
}