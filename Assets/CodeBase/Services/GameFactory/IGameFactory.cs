using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.Services.GameFactory
{
    public interface IGameFactory : IService
    {
        GameObject HeroObject { get; }
        VirtualJoystick VirtualJoystick { get; }
        FollowCamera FollowCamera { get; }
        HeroHealth HeroHealth { get; }
        HeroCondition HeroCondition { get; }

        GameObject CreateHero(Vector3 position, Quaternion rotation);
        VirtualJoystick CreateVirtualJoystick();
        FollowCamera CreateFollowCamera();
        GameObject CreateEnemy(EnemyId id, Vector3 position);
        GameObject CreateCoin(Vector3 position);
    }
}
