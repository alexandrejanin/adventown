namespace StateMachines {
	public abstract class State<T> where T : Character {
		protected readonly T character;
		public abstract string ShortDescription { get; }
		public abstract string Description { get; }

		protected State(T character) => this.character = character;

		public abstract State<T> Update();
	}
}