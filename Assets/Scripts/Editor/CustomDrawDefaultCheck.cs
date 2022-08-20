using Checks;
using UnityEditor;

namespace Editor
{
	[CustomEditor(typeof(DrawDefaultCheck))]
	public class CustomDrawDefaultCheck : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			EditorGUILayout.HelpBox("This is a help box that comes after standard properties", MessageType.Info);
		}
	}
}