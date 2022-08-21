using System.Collections.Generic;
using Projectiles;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(Launcher))]
	public class CustomLauncher : UnityEditor.Editor
	{
		void OnSceneGUI()
		{
			var launcher = target as Launcher;
			var transform = launcher.transform;
			launcher.Offset = transform.InverseTransformPoint(Handles.PositionHandle(transform.TransformPoint(launcher.Offset), transform.rotation));
			Handles.BeginGUI();
			var rectMin = Camera.current.WorldToScreenPoint(
				launcher.transform.position +
				launcher.Offset);
			var rect = new Rect();
			rect.xMin = rectMin.x;
			rect.yMin = SceneView.currentDrawingSceneView.position.height -
			            rectMin.y;
			rect.width = 64;
			rect.height = 18;
			GUILayout.BeginArea(rect);
			using (new EditorGUI.DisabledGroupScope(!Application.isPlaying))
			{
				if (GUILayout.Button("Fire"))
					launcher.Fire();
			}

			GUILayout.EndArea();
			Handles.EndGUI();
		}

		[DrawGizmo(GizmoType.Pickable | GizmoType.Selected)]
		static void DrawGizmosSelected(Launcher launcher, GizmoType gizmoType)
		{
			{
				var offsetPosition = launcher.transform.TransformPoint(launcher.Offset);
				Handles.DrawDottedLine(launcher.transform.position, offsetPosition, 3);
				Handles.Label(offsetPosition, "Offset");
				if (launcher.Projectile != null)
				{
					var positions = new List<Vector3>();
					var velocity = launcher.transform.forward *
					               launcher.Velocity /
					               launcher.Projectile.mass;
					var position = offsetPosition;
					var physicsStep = 0.1f;
					for (var i = 0f; i <= 1f; i += physicsStep)
					{
						positions.Add(position);
						position += velocity * physicsStep;
						velocity += Physics.gravity * physicsStep;
					}

					using (new Handles.DrawingScope(Color.yellow))
					{
						Handles.DrawAAPolyLine(positions.ToArray());
						Gizmos.DrawWireSphere(positions[positions.Count - 1], 0.125f);
						Handles.Label(positions[positions.Count - 1], "Estimated Position (1 sec)");
					}
				}
			}
		}
	}
}