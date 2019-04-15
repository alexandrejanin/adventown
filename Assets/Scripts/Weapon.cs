public class Weapon : Item {
	public float Speed { get; }
	public int Damage { get; }

	public Weapon(string name, ItemRarity rarity, float speed, int damage) : base(name, rarity) {
		Speed = speed;
		Damage = damage;
	}
}