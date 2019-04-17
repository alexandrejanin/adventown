﻿namespace StateMachines.HeroStates {
	public sealed class GoingHome : State<Hero> {
		public override string ShortDescription => "Going back to town";
		public override string Description => "Going back to town";

		public GoingHome(Hero owner) : base(owner) { }

		public override State<Hero> Update() {
			return new Roaming(owner);
		}
	}
}