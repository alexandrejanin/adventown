using UnityEngine;

public class PanZoom : MonoBehaviour {
	[SerializeField] private float minX = -20;
	[SerializeField] private float maxX = 0;
	[SerializeField] private float minZ = -20;
	[SerializeField] private float maxZ = 0;
	[SerializeField] private float zoomOutMin = 1;
	[SerializeField] private float zoomOutMax = 8;
	[SerializeField] private float mouseWheelSensitivity = 5;
	private Vector3 touchStart;
	private Camera camera;

	private void Start() {
		camera = GetComponent<Camera>();
	}

	// Update is called once per frame
	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			touchStart = camera.ScreenToWorldPoint(Input.mousePosition);
		}

		if (Input.touchCount == 2) {
			var touchZero = Input.GetTouch(0);
			var touchOne = Input.GetTouch(1);

			var touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			var touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			var prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			var currentMagnitude = (touchZero.position - touchOne.position).magnitude;

			var difference = currentMagnitude - prevMagnitude;

			zoom(difference * 0.01f);
		}
		else if (Input.GetMouseButton(0)) {
			var direction = touchStart - camera.ScreenToWorldPoint(Input.mousePosition);

			var position = camera.transform.position + direction;
			camera.transform.position = position;
		}

		zoom(mouseWheelSensitivity * Input.GetAxis("Mouse ScrollWheel"));
	}

	void zoom(float increment) {
		camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - increment, zoomOutMin, zoomOutMax);
	}
}