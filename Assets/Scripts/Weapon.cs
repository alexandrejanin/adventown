using UnityEngine;

public class Weapon : Item {
	public float Speed { get; }
	public int Damage { get; }

	public Weapon(int level) : base(ItemRarity.Epic) {
		Speed = GetSpeed(level);
		Damage = GetDamage(level);
	}

	public override string ToString() {
		return $"{Rarity} {Name} (Damage: {Damage}, Speed: {Speed})";
	}

	private static float GetSpeed(int level) => (3 - 2 * level / 100f) * Random.Range(0.85f, 1.15f);
	private static int GetDamage(int level) => Mathf.RoundToInt((2 + level) * Random.Range(0.85f, 1.15f));
}