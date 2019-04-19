using UnityEngine;

namespace UI {
	public class InterfaceManager : MonoBehaviour {
		[SerializeField] private CharacterInfoText characterInfoTextPrefab;
		[SerializeField] private RectTransform uiParent;

		private void Awake() {
			Character.OnEntitySpawned += OnEntitySpawned;
		}

		// Spawn entity names/bars
		private void OnEntitySpawned(Character character) {
			var characterInfoText = Instantiate(characterInfoTextPrefab, uiParent);
			characterInfoText.Character = character;
		}
	}
}