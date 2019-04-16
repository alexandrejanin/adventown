using UnityEngine;

public sealed class Enemy {
	public string Name { get; }

	public int Level { get; }
	public ResourceBar Health { get; private set; }

	public float Speed { get; }
	public int Damage { get; }

	public Enemy(int level) {
		Name = NameGenerator.EnemyName();
		Level = level;
		Health = new ResourceBar(GetHealth(level));
		Speed = GetSpeed(level);
		Damage = GetDamage(level);
	}

	public void Hit(Weapon weapon) {
		Health -= weapon.Damage;
	}

	public override string ToString() {
		return $"Level {Level} {Name} {Health}HP";
	}

	private static int GetHealth(int level) => Mathf.RoundToInt((4 + level) * Random.Range(0.85f, 1.15f));
	private static float GetSpeed(int level) => (3 - 2 * level / 100f) * Random.Range(0.85f, 1.15f);
	private static int GetDamage(int level) => Mathf.RoundToInt((1 + level) * Random.Range(0.85f, 1.15f));
}