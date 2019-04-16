namespace HeroStates {
	public class Dead : HeroState {
		public Dead(Hero hero) : base(hero) { }

		public override HeroState Update(float deltaTime) => this;

		public override string ToString() {
			return "Dead";
		}
	}
}