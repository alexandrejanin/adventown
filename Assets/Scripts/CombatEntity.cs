using UnityEngine;

public abstract class CombatEntity : MonoBehaviour {
	public ResourceBar Health { get; protected set; }
	protected abstract int AttackDamage { get; }

	public void Hit(CombatEntity attacker) => Health -= attacker.AttackDamage;
}