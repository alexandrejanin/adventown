using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class BuyHeroButton : MonoBehaviour {
		[SerializeField] private Text nameText, levelText, statsText, costText;
		private Hero hero;
		private Vector3 spawnPos;

		public void Init(Hero hero, Vector3 spawnPos) {
			this.hero = hero;
			this.spawnPos = spawnPos;
			nameText.text = hero.name;
			levelText.text = $"Level {hero.Level}";
			statsText.text = $"Health: {hero.Health.Size}\nStamina: {hero.Stamina.Size}\nDamage: {hero.Weapon.Damage}\nSpeed: {hero.Weapon.Speed}";
			costText.text = hero.Cost.ToString();
		}

		public void Buy() {
			hero.Spawn(spawnPos);
		}

		private void Update() {
			if (hero.gameObject.activeInHierarchy)
				Destroy(gameObject);
		}
	}
}