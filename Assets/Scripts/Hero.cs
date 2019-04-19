using StateMachines;
using StateMachines.HeroStates;
using UnityEngine;

public sealed class Hero : Character {
	public int Level { get; private set; }
	public int Gold { get; set; }

	public ResourceBar Stamina { get; private set; }

	public Weapon Weapon { get; private set; }
	protected override int AttackDamage => Weapon.Damage;

	private State<Hero> state;

	private State<Hero> State {
		get => state;
		set {
			var oldState = state;
			state = value;
			if (oldState != state) OnStateChanged?.Invoke(this, state);
		}
	}

	public int Cost => 2 * Level;

	public delegate void OnStateChange(Hero hero, State<Hero> state);

	public event OnStateChange OnStateChanged;

	public void Awake() {
		name = NameGenerator.HeroName();
		SetStats(1);
		gameObject.SetActive(false);
	}

	public void Update() {
		State = State.Update();
	}

	public void Spawn(Vector3 position) {
		transform.position = position;
		State = new Roaming(this);
		gameObject.SetActive(true);
		OnSpawned();
	}

	private void SetStats(int level) {
		Level = level;
		Health = new ResourceBar(StatsGenerator.GetHeroHealth(level));
		Stamina = new ResourceBar(StatsGenerator.GetHeroStamina(level));
		Weapon = new Weapon(level);
	}

	public override string ToString() {
		return $"Level {Level} {name}";
	}
}