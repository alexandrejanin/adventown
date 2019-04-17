public class Weapon : Item {
	public float Speed { get; }
	public int Damage { get; }

	public Weapon(int level) : base(ItemRarity.Epic) {
		Speed = StatsGenerator.GetWeaponSpeed(level);
		Damage = StatsGenerator.GetWeaponDamage(level);
	}

	public override string ToString() {
		return $"{Rarity} {Name} (Damage: {Damage}, Speed: {Speed})";
	}
}