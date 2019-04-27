using UnityEngine;
using UnityEngine.Serialization;

namespace UI {
	public class InterfaceManager : MonoBehaviour {
		[SerializeField] private HeroInfoText heroInfoTextPrefab;
		[SerializeField] private EnemyInfoText enemyInfoTextPrefab;

		[SerializeField] private RectTransform uiParent;

		private void Awake() {
			Character.OnEntitySpawned += OnEntitySpawned;
		}

		private void OnEntitySpawned(Character character) {
			switch (character) {
				case Hero hero: {
					var characterInfoText = Instantiate(heroInfoTextPrefab, uiParent);
					characterInfoText.Hero = hero;
					break;
				}
				case Enemy enemy: {
					var characterInfoText = Instantiate(enemyInfoTextPrefab, uiParent);
					characterInfoText.Enemy = enemy;
					break;
				}
			}
		}
	}
}