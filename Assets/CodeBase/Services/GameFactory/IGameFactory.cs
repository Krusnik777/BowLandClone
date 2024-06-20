using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Elements;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Services
{
    public interface IGameFactory : IService
    {
        GameObject HeroObject { get; }
        VirtualJoystick VirtualJoystick { get; }
        FollowCamera FollowCamera { get; }
        HeroHealth HeroHealth { get; }
        HeroCondition HeroCondition { get; }

        Task WarmUp();
        Task<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation);
        Task<VirtualJoystick> CreateVirtualJoystickAsync();
        Task<FollowCamera> CreateFollowCameraAsync();
        Task<GameObject> CreateCoinAsync(Vector3 position);
        Task<GameObject> CreateEnemyAsync(EnemyId id, Vector3 position);
    }
}
