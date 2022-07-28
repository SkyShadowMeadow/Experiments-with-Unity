using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "LevelCobfig", menuName = "Configs/LevelGonfig", order = 0)]
    public class LevelConfig : ObjectConfiguration<LevelConfig>
    {
        [field: SerializeField] public GameObject LevelPrefab { get; private set; }
    }
}