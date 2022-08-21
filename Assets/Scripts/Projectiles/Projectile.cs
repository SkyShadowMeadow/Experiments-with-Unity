using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	[HideInInspector] public Rigidbody Rigidbody;
	public float DamageRadius = 3;

	void Reset()
	{
		Rigidbody = GetComponent<Rigidbody>();
	}
}