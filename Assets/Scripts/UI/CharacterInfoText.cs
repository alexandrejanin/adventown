using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class CharacterInfoText : MonoBehaviour {
		private const float Offset = 50;
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

			var charPos = Camera.main.WorldToScreenPoint(Character.transform.position);
			charPos.y += Offset;
			transform.position = charPos;

			text.text = Character.name;

			var barSize = bar.sizeDelta;
			barSize.x = Character.Health.Ratio * barWidth;
			bar.sizeDelta = barSize;
		}
	}
}