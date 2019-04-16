using UnityEngine;

public class Test : MonoBehaviour {
	private void Start() {
		NameGenerator.Save();

		var enemy = new Enemy(1);
		Debug.Log(enemy.Name);
	}
}