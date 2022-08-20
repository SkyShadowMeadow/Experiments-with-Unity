using Level;
using UnityEditor;

namespace Editor
{
	[CustomEditor(typeof(LevelExperience))]
	public class LevelExperienceEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			LevelExperience myLevelScript = (LevelExperience) target;
			myLevelScript.Experience = EditorGUILayout.IntField("Experience", (int) myLevelScript.Experience);
			EditorGUILayout.LabelField("Level", myLevelScript.Level.ToString());
		}
	}
}