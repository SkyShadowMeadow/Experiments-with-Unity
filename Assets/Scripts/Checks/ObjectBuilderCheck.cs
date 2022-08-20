using UnityEngine;

namespace Checks
{
	public class ObjectBuilderCheck : MonoBehaviour
	{
		public static int BuiltObjects;
		public GameObject ObjectToBuild;
		public Vector3 StartBuildingPoint = Vector3.zero;
		public Vector3 NextBuildingPoint = Vector3.zero;

		public void BuildObject()
		{
			if (BuiltObjects == 0)
			{
				Instantiate(ObjectToBuild, StartBuildingPoint, Quaternion.identity);
				NextBuildingPoint += Vector3.left;
				BuiltObjects++;
			}
			else
			{
				Instantiate(ObjectToBuild, NextBuildingPoint, Quaternion.identity);
				NextBuildingPoint += Vector3.left;
				BuiltObjects++;
			}
		}
	}
}