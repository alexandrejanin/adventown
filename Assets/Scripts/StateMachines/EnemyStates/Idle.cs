﻿namespace StateMachines.EnemyStates {
	public sealed class Idle : State<Enemy> {
		public override string ShortDescription => "Idle";
		public override string Description => "Idle";

		public bool Taken { get; set; }

		public Idle(Enemy character) : base(character) { }

		public override State<Enemy> Update() => this;
	}
}