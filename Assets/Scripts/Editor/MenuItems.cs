using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MenuItems
{
	[MenuItem("Tools/Clear Player Prefs")]
	[MenuItem("Assets/Clear PlayerPrefs ")]
	private static void ClearPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

	[MenuItem("Window/New option %#a")]
	private static void Option1()
	{
	}

	[MenuItem("Assets/Create/New Configuration")]
	private static void CreateConfiguration()
	{
	}

	[MenuItem("Tools/Visuals/Change material color")]
	private static void ChangeColorToGreen()
	{
		Selection.activeObject.GetComponent<MeshRenderer>().material.color = Color.green;
	}

	[MenuItem("Tools/Visuals/Change material color", true)]
	private static bool ValidateMeshRenderer()
	{
		return Selection.activeObject.GetComponent<MeshRenderer>();
	}

	[MenuItem("CONTEXT/BoxCollider/Activate trigger")]
	private static void ActivateTrigger()
	{
		Selection.activeObject.GetComponent<BoxCollider>().isTrigger = true;
	}

	[MenuItem("CONTEXT/MeshRenderer/ChangeColor")]
	private static void ActivateTrigger(MenuCommand command)
	{
		var meshRenderer = command.context as MeshRenderer;
		meshRenderer.material.color = Random.ColorHSV(1, 255);
	}
}