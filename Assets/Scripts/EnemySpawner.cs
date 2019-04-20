using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] private float spawnCooldown;
	[SerializeField] private Enemy enemyPrefab;
	[SerializeField] private BoxCollider[] spawnAreas;

	private float spawnTimer;

	private void Update() {
		spawnTimer += Time.deltaTime;
		if (spawnTimer < spawnCooldown) return;

		var point = GetSpawnPoint();
		Instantiate(enemyPrefab, point, Quaternion.identity);
		spawnTimer = 0;
	}

	private Vector3 GetSpawnPoint() {
		var bounds = spawnAreas[Random.Range(0, spawnAreas.Length)].bounds;
		return new Vector3(
			Random.Range(bounds.min.x, bounds.max.x),
			Random.Range(bounds.min.y, bounds.max.y),
			Random.Range(bounds.min.z, bounds.max.z)
		);
	}
}