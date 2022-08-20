using UnityEngine;

namespace Level
{
	public class LevelExperience : MonoBehaviour
	{
		public int Level
		{
			get { return (int) Experience / 750; }
		}

		public float Experience;
	}
}