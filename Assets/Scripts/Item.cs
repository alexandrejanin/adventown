public enum ItemRarity {
	Basic,
	Common,
	Rare,
	Legendary
}

public abstract class Item {
	public string Name { get; }
	public ItemRarity rarity { get; }

	protected Item(string name, ItemRarity rarity) {
		Name = name;
		this.rarity = rarity;
	}
}