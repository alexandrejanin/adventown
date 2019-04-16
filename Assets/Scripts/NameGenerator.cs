using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public static class NameGenerator {
	private static readonly string[] EnemyNames = {"Rat", "Bat", "Goblin"};
	private static readonly string[] HeroNames = {"John", "Tom", "Bob"};
	private static readonly string[] WeaponNames = {"Sword", "Axe", "Staff"};

	public static void Save() {
		var xml = new XmlSerializer(typeof(string[]));
		xml.Serialize(new FileStream(Application.streamingAssetsPath + "/NameGen/enemies.json", FileMode.Create), EnemyNames);
	}

	public static string EnemyName() => EnemyNames[Random.Range(0, EnemyNames.Length)];
}