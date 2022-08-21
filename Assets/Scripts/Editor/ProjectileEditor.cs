using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(Projectile))]
	public class ProjectileEditor : UnityEditor.Editor
	{
		[DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
		static void DrawGizmosSelected(Projectile projectile, GizmoType gizmoType)
		{
			Gizmos.DrawSphere(projectile.transform.position, 0.5f);
		}

		void OnGUIScene()
		{
			var projectile = target as Projectile;
			var transform = projectile.transform;
			projectile.DamageRadius = Handles.RadiusHandle(transform.rotation, transform.position, projectile.DamageRadius);
		}
	}
}