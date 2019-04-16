using HeroStates;
using UnityEngine;

public sealed class Hero {
	public string Name { get; private set; }

	public int Level { get; }
	public int Gold { get; }

	public ResourceBar Health { get; }
	public ResourceBar Stamina { get; }

	public Weapon Weapon { get; }

	public HeroState State { get; private set; }

	public delegate void OnStateChange(Hero hero, HeroState state);

	public event OnStateChange OnStateChanged;

	public Hero(int level) {
		Name = NameGenerator.HeroName();
		Level = level;
		Gold = 0;
		Health = new ResourceBar(GetHealth(level));
		Stamina = new ResourceBar(GetStamina(level));
		Weapon = new Weapon(level);
		State = new Roaming(this, 2);
	}

	public void Update(float deltaTime) {
		var newState = State.Update(deltaTime);
		if (newState != State) OnStateChanged?.Invoke(this, newState);
		State = newState;
	}

	public override string ToString() {
		return $"Level {Level} {Name} {Health}HP";
	}

	private static int GetHealth(int level) => Mathf.RoundToInt((18 + 2 * level) * Random.Range(0.85f, 1.15f));
	private static int GetStamina(int level) => Mathf.RoundToInt((10 + 2 * level) * Random.Range(0.85f, 1.15f));
}