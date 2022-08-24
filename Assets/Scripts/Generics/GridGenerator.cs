using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridGenerator : MonoBehaviour
{
	[SerializeField] private List<GameObject> _prefabs;

	[SerializeField] private float _spacing = 8f;
	[SerializeField] private int _number = 10;

	private Vector3 position = Vector3.zero;

	public void GenerateRandomPrefabs()
	{
		for (int i = 0; i < _number; i++)
		{
			for (int j = 0; j < _number; j++)
			{
				Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], position, quaternion.identity);
				if (j < _number - 1)
				{
					position = new Vector3(position.x + _spacing, position.y, position.z);
				}
			}

			position = new Vector3(0, position.y, position.z + _spacing);
		}
	}
}