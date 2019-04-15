using UnityEngine;

public class Test : MonoBehaviour {
	private void Start() {
		var test = new ResourceBar(10) {CurrentValue = 4};
		test.CurrentValue--;
		Debug.Log(test);
		Debug.Log(test.Ratio);
	}
}