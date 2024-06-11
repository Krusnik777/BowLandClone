using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

namespace CodeBase.Services.GameFactory
{
    public interface IGameFactory : IService
    {
        GameObject Hero { get; }
        VirtualJoystick VirtualJoystick { get; }
        FollowCamera FollowCamera { get; }

        GameObject CreateHero(Vector3 position, Quaternion rotation);
        VirtualJoystick CreateVirtualJoystick();
        FollowCamera CreateFollowCamera();
    }
}
