using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

namespace CodeBase.Services
{
    public interface IInputService : IService
    {
        bool Enabled { get; set; }
        Vector2 MovementAxis { get; }
    }
}