namespace HeroStates {
	public class Roaming : HeroState {
		private float RoamDuration { get; }
		private float Timer { get; set; }

		public Roaming(Hero hero, float roamDuration) : base(hero) {
			RoamDuration = roamDuration;
		}

		public override HeroState Update(float deltaTime) {
			Timer += deltaTime;
			if (Timer > RoamDuration)
				return new Combat(Hero, new Enemy(Hero.Level));

			return this;
		}

		public override string ToString() {
			return $"Roaming";
		}
	}
}