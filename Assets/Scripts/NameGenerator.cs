using UnityEngine;

public static class NameGenerator {
	private static readonly string[] HeroNames = {"John", "Tom", "Bob"};
	private static readonly string[] WeaponNames = {"Sword", "Axe", "Staff"};
	private static readonly string[] EnemyNames = {"Rat", "Bat", "Goblin"};

	public static string HeroName() => HeroNames[Random.Range(0, HeroNames.Length)];
	public static string WeaponName() => WeaponNames[Random.Range(0, WeaponNames.Length)];
	public static string EnemyName() => EnemyNames[Random.Range(0, EnemyNames.Length)];
}