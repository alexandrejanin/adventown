using StateMachines;
using StateMachines.EnemyStates;
using UnityEngine;

public sealed class Enemy : Character {
	public int Level { get; private set; }
	public int Gold { get; private set; }


	public float Speed { get; private set; }
	public int Damage { get; private set; }
	protected override int AttackDamage => Damage;


	private State<Enemy> state;

	public State<Enemy> State {
		get => state;
		set {
			if (value != state) OnStateChanged?.Invoke(this, value);
			state = value;
		}
	}


	public delegate void OnStateChange(Enemy enemy, State<Enemy> state);

	public event OnStateChange OnStateChanged;

	public void Start() {
		name = NameGenerator.EnemyName();
		SetStats(1);

		OnStateChanged += (enemy, state) => Debug.Log($"{enemy} is now {state.Description}");
		State = new Idle(this);
	}

	public void Update() {
		State = State.Update();
	}

	private void SetStats(int level) {
		Level = level;
		Health = new ResourceBar(StatsGenerator.GetEnemyHealth(level));
		Speed = StatsGenerator.GetEnemySpeed(level);
		Damage = StatsGenerator.GetEnemyDamage(level);
	}

	public override string ToString() {
		return $"Level {Level} {name} {Health}HP";
	}
}