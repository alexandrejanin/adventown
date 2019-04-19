using UnityEngine;

public class PanCamera : MonoBehaviour {
	private Vector3 startPosition;
	private Vector3 startGroundPosition;

	private static readonly Plane GroundPlane = new Plane(Vector3.up, Vector3.zero);

	private void Update() {
		// First touch
		if (Input.GetMouseButtonDown(0)) {
			startPosition = transform.position;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (GroundPlane.Raycast(ray, out var dist))
				startGroundPosition = ray.GetPoint(dist);
		}

		// Touch held
		if (Input.GetMouseButton(0)) {
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (!GroundPlane.Raycast(ray, out var dist)) return;
			var groundPosition = ray.GetPoint(dist);
			var offset = startGroundPosition - groundPosition;
			transform.position = startPosition + offset;
		}
	}
}