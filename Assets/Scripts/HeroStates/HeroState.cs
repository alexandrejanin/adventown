namespace HeroStates {
	public abstract class HeroState {
		public Hero Hero { get; }

		protected HeroState(Hero hero) => Hero = hero;

		public abstract HeroState Update(float deltaTime);
	}
}