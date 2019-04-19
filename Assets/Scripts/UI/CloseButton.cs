using UnityEngine;
using UnityEngine.EventSystems;

namespace UI {
	public class CloseButton : MonoBehaviour, IPointerDownHandler {
		[SerializeField] private Closable closable;

		public void OnPointerDown(PointerEventData eventData) {
			closable.Close();
		}
	}
}