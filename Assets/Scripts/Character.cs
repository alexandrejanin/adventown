using UnityEngine;

public abstract class Character : MonoBehaviour {
	public ResourceBar Health { get; protected set; }
	protected abstract int AttackDamage { get; }

	public delegate void EntitySpawned(Character character);

	public static event EntitySpawned OnEntitySpawned;

	private void Awake() {
		OnEntitySpawned?.Invoke(this);
	}

	public void Hit(Character attacker) => Health -= attacker.AttackDamage;
}