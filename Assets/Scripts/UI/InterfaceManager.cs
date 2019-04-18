using UnityEngine;

namespace UI {
	public class InterfaceManager : MonoBehaviour {
		[SerializeField] private CharacterInfoText characterInfoTextPrefab;
		[SerializeField] private Canvas canvas;

		private void Awake() {
			Character.OnEntitySpawned += OnEntitySpawned;
		}

		private void OnEntitySpawned(Character character) {
			var characterInfoText = Instantiate(characterInfoTextPrefab, canvas.transform);
			characterInfoText.Character = character;
		}
	}
}