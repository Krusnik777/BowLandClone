using CodeBase.Infrastructure.ServiceLocator;
using UnityEngine;

namespace CodeBase.Services.Input
{
    public interface IInputService : IService
    {
        bool Enabled { get; set; }
        Vector2 MovementAxis { get; }
    }
}