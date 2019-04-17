using UnityEngine;

public static class StatsGenerator {
	private const int HeroHealthBase = 18;
	private const int HeroHealthPerLevel = 2;
	private const int HeroStaminaBase = 8;
	private const int HeroStaminaPerLevel = 2;

	private const int WeaponDamageBase = 2;
	private const int WeaponDamagePerLevel = 1;
	private const float WeaponSpeedBase = 3;
	private const float WeaponSpeedPerLevel = -.025f;

	private const int EnemyHealthBase = 4;
	private const int EnemyHealthPerLevel = 2;
	private const float EnemySpeedBase = 3;
	private const float EnemySpeedPerLevel = -.025f;
	private const int EnemyDamageBase = 1;
	private const int EnemyDamagePerLevel = 1;

	private static float RandomFactor() => Random.Range(0.85f, 1.15f);

	public static int GetHeroHealth(int level) => Mathf.RoundToInt((HeroHealthBase + HeroHealthPerLevel * level) * RandomFactor());
	public static int GetHeroStamina(int level) => Mathf.RoundToInt((HeroStaminaBase + HeroStaminaPerLevel * level) * RandomFactor());

	public static int GetWeaponDamage(int level) => Mathf.RoundToInt((WeaponDamageBase + WeaponDamagePerLevel * level) * RandomFactor());
	public static float GetWeaponSpeed(int level) => (WeaponSpeedBase + WeaponSpeedPerLevel * level) * RandomFactor();

	public static int GetEnemyHealth(int level) => Mathf.RoundToInt((EnemyHealthBase + EnemyHealthPerLevel * level) * RandomFactor());
	public static float GetEnemySpeed(int level) => (EnemySpeedBase + EnemySpeedPerLevel * level) * RandomFactor();
	public static int GetEnemyDamage(int level) => Mathf.RoundToInt((EnemyDamageBase + EnemyDamagePerLevel * level) * RandomFactor());
}