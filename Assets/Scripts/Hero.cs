public class Hero {
	public string Name { get; private set; }

	public int Level { get; private set; }
	public int Gold { get; private set; }
	private ResourceBar Health { get; }
	private ResourceBar Stamina { get; }

	public Weapon Weapon { get; private set; }

	public Hero(int level) {
		
	}
}