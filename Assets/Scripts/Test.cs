using UnityEngine;

public class Test : MonoBehaviour {
	private Hero hero;

	private void Start() {
		hero = new Hero(1);
		hero.OnStateChanged += (hero, state) => Debug.Log(hero + " switched to " + state);
	}

	private void Update() {
		hero.Update(Time.deltaTime);
	}
}