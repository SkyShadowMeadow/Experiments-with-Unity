using Checks;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(ObjectBuilderCheck))]
	public class CustomObjectBuilder : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			ObjectBuilderCheck myObjectBuilder = (ObjectBuilderCheck) target;

			if (GUILayout.Button("Build object"))
			{
				myObjectBuilder.BuildObject();
			}
		}
	}
}