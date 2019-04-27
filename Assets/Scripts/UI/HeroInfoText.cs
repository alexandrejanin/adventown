using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI {
	public class HeroInfoText : MonoBehaviour {
		[SerializeField] private Text text;

		[SerializeField] private RectTransform healthBar;
		[SerializeField] private RectTransform staminaBar;

		private float healthBarWidth, staminaBarWidth;

		public Hero Hero { private get; set; }

		private void Awake() {
			healthBarWidth = healthBar.sizeDelta.x;
			staminaBarWidth = staminaBar.sizeDelta.x;
		}

		private void Update() {
			if (!Hero) {
				Destroy(gameObject);
				return;
			}

			transform.position = Camera.main.WorldToScreenPoint(Hero.TextPosition.position);

			text.text = Hero.name;
			SetBar(Hero.Health, healthBar, healthBarWidth);
			SetBar(Hero.Stamina, staminaBar, staminaBarWidth);
		}

		private static void SetBar(ResourceBar resourceBar, RectTransform barTransform, float barWidth) {
			var barSize = barTransform.sizeDelta;
			barSize.x = resourceBar.Ratio * barWidth;
			barTransform.sizeDelta = barSize;
		}
	}
}