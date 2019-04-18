namespace StateMachines.HeroStates {
	public sealed class Dead : State<Hero> {
		public override string ShortDescription => "Dead";
		public override string Description => "Dead";

		public Dead(Hero character) : base(character) { }

		public override State<Hero> Update() => this;
	}
}