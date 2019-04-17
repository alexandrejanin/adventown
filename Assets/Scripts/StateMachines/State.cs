namespace StateMachines {
	public abstract class State<T> {
		protected readonly T owner;
		public abstract string ShortDescription { get; }
		public abstract string Description { get; }

		protected State(T owner) => this.owner = owner;

		public abstract State<T> Update();
	}
}