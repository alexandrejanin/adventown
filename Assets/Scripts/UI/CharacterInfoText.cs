using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class CharacterInfoText : MonoBehaviour {
		[SerializeField] private Text text;
		[SerializeField] private RectTransform bar;
		private float barWidth;

		public Character Character { private get; set; }

		private void Awake() {
			barWidth = bar.sizeDelta.x;
		}

		private void Update() {
			if (!Character) {
				Destroy(gameObject);
				return;
			}

			transform.position = Camera.main.WorldToScreenPoint(Character.TextPosition.position);

			text.text = Character.name;

			var barSize = bar.sizeDelta;
			barSize.x = Character.Health.Ratio * barWidth;
			bar.sizeDelta = barSize;
		}
	}
}