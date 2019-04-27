using UnityEngine;

namespace StateMachines.HeroStates {
	public sealed class GoingHome : State<Hero> {
		public override string ShortDescription => "Going back to town";
		public override string Description => "Going back to town";

		public GoingHome(Hero character) : base(character) { }

		public override State<Hero> Update() {
			Debug.Log($"{character} going home");
			return new Roaming(character);
		}
	}
}