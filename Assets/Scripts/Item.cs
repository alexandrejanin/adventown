public abstract class Item {
	public string Name { get; }
	public ItemRarity Rarity { get; }

	protected Item(string name, ItemRarity rarity) {
		Name = name;
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