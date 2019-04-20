using UnityEngine;

public abstract class Character : MonoBehaviour {
	[SerializeField] private Transform textPosition;

	public Transform TextPosition => textPosition;

	public ResourceBar Health { get; protected set; }
	protected abstract int AttackDamage { get; }

	public delegate void EntitySpawned(Character character);

	public static event EntitySpawned OnEntitySpawned;

	protected void OnSpawned() {
		OnEntitySpawned?.Invoke(this);
	}

	public void Hit(Character attacker) => Health -= attacker.AttackDamage;
}