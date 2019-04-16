public abstract class Item {
	public string Name { get; }
	public ItemRarity Rarity { get; }

	protected Item(ItemRarity rarity) {
		Name = NameGenerator.WeaponName();
		Rarity = rarity;
	}

	public enum ItemRarity {
		Basic,
		Common,
		Rare,
		Epic,
		Legendary
	}
}