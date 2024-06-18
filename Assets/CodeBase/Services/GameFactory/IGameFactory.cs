using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

namespace CodeBase.Services.GameFactory
{
    public interface IGameFactory : IService
    {
        GameObject HeroObject { get; }
        VirtualJoystick VirtualJoystick { get; }
        FollowCamera FollowCamera { get; }
        HeroHealth HeroHealth { get; }

        GameObject CreateHero(Vector3 position, Quaternion rotation);
        VirtualJoystick CreateVirtualJoystick();
        FollowCamera CreateFollowCamera();
        GameObject CreateEnemy(string path, Vector3 position);
    }
}
