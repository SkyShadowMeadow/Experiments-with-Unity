using UnityEngine;

namespace Projectiles
{
	public class Launcher : MonoBehaviour
	{
		public Rigidbody Projectile;
		public Vector3 Offset = Vector3.forward;
		[Range(0, 100)] public float Velocity = 10;

		[ContextMenu("Fire")]
		public void Fire()
		{
			var currentProjectile = Instantiate(Projectile, transform.TransformPoint(Offset), transform.rotation);
			currentProjectile.velocity = Vector3.forward * Velocity;
		}
	}
}