using UnityEngine;

public class Enemy {
	public string Name { get; private set; }

	public int Level { get; }
	private ResourceBar Health { get; }

	public float Speed { get; }
	public int Damage { get; }

	public Enemy(int level) {
		Name = NameGenerator.EnemyName();
		Level = level;
		Health = new ResourceBar(GetHealth(level));
		Speed = GetSpeed(level);
		Damage = GetDamage(level);
	}

	private static int GetHealth(int level) => (int) ((40 + 10 * level) * Random.Range(0.85f, 1.15f));
	private static float GetSpeed(int level) => (3 - 2 * level / 100f) * Random.Range(0.85f, 1.15f);
	private static int GetDamage(int level) => (int) ((4 + 1 * level) * Random.Range(0.85f, 1.15f));
}