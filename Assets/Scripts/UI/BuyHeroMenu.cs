using UnityEngine;

namespace UI {
	public class BuyHeroMenu : Closable {
		[SerializeField] private Hero heroPrefab;
		[SerializeField] private BuyHeroButton buttonPrefab;
		[SerializeField] private Transform spawnPoint;
		[SerializeField] private RectTransform buttonParent;

		private void Start() {
			for (var i = 0; i < 3; i++) {
				var button = Instantiate(buttonPrefab, buttonParent);
				var hero = Instantiate(heroPrefab);
				button.Init(hero, spawnPoint.position);
			}
		}

		public void Open() => gameObject.SetActive(true);

		public override void Close() => gameObject.SetActive(false);
	}
}