using CodeBase.Gameplay.Enemy;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        public EnemyId EnemyId;
        public float AttackCooldown;
        public float AttackRadius;
        public float Damage;
        public float MovementSpeed;
        public float StopDistance;
        public float MaxHealth;
        public AssetReferenceGameObject PrefabReference;
    }
}
