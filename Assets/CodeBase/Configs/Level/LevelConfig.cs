using CodeBase.Gameplay.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        public string SceneName;
        public Vector3 HeroSpawnPosition;
        public Vector3 FinishPoint;

        public List<EnemySpawnerData> EnemySpawnerDatas;

        public List<Vector3> CoinPositions;
    }

    [System.Serializable]
    public class EnemySpawnerData
    {
        public EnemyId Id;
        public Vector3 Position;
    }
}
