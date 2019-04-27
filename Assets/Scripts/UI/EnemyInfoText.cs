using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI {
	public class EnemyInfoText : MonoBehaviour {
		[SerializeField] private Text text;

		[SerializeField] private RectTransform healthBar;

		private float healthBarWidth;

		public Enemy Enemy { private get; set; }

		private void Awake() {
			healthBarWidth = healthBar.sizeDelta.x;
		}

		private void Update() {
			if (!Enemy) {
				Destroy(gameObject);
				return;
			}

			transform.position = Camera.main.WorldToScreenPoint(Enemy.TextPosition.position);

			text.text = Enemy.name;
			SetBar(Enemy.Health, healthBar, healthBarWidth);
		}

		private static void SetBar(ResourceBar resourceBar, RectTransform barTransform, float barWidth) {
			var barSize = barTransform.sizeDelta;
			barSize.x = resourceBar.Ratio * barWidth;
			barTransform.sizeDelta = barSize;
		}
	}
}